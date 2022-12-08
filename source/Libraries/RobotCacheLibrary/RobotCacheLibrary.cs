using Playnite.Common;
using Playnite.SDK;
using Playnite.SDK.Data;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using RobotCacheLibrary.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Xml.Linq;

namespace RobotCacheLibrary
{
    public class RobotCacheLibrary : LibraryPlugin
    {
        private static readonly ILogger Logger = LogManager.GetLogger();


        private RobotCacheLibrarySettingsViewModel Settings { get; set; }

        public override Guid Id { get; } = Guid.Parse("4de579c6-7179-4229-b776-7a3a9e902052");
        public override string LibraryIcon { get; }

        // Change to something more appropriate
        public override string Name => "RobotCache";

        // Implementing Client adds ability to open it via special menu in playnite.
        public override LibraryClient Client { get; } = new RobotCacheClient();


        public string ImportErrorMessageId { get; }
        public RobotCacheLibrary(IPlayniteAPI api) : base(api)
        {
            Settings = new RobotCacheLibrarySettingsViewModel(this);
            Properties = new LibraryPluginProperties
            {
                HasSettings = true,
                CanShutdownClient = true,
            };
            LibraryIcon = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", @"robotcacheicon.png");
            ImportErrorMessageId = $"{Name}_libImportError";
        }

        public static Dictionary<string, GameMetadata> GetInstalledGames()
        {
            var games = new Dictionary<string, GameMetadata>();

            string appConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RobotCache", "RobotCacheClient", "config", "appConfig.json");
            RobotCacheModels appConfig = Serialization.FromJson<RobotCacheModels>(File.ReadAllText(appConfigPath));
            foreach(string libraryPathRaw in appConfig.libraries)
            {
                string libraryPath = libraryPathRaw.Replace('/', '\\');
                if(Directory.Exists(libraryPath))
                {
                    string gamesPath = Path.Combine(libraryPath, "rcdata", "games");
                    foreach(string gamePath in Directory.EnumerateDirectories(gamesPath))
                    {
                        string stateInfoPath = Path.Combine(gamePath, "stateInfo.json");
                        if (File.Exists(stateInfoPath))
                        {
                            RobotCacheStateInfo stateInfo = Serialization.FromJson<RobotCacheStateInfo>(File.ReadAllText(stateInfoPath));
                            if (stateInfo.State.currentState == 6)
                            {
                                string gameFolder = stateInfo.Execution.Where(dr => !string.IsNullOrWhiteSpace(dr.path)).FirstOrDefault()?.path;
                                var game = new GameMetadata()
                                {
                                    Source = new MetadataNameProperty("RobotCache"),
                                    GameId = stateInfo.gameId.ToString(),
                                    Name = stateInfo.Execution.Where(dr => !string.IsNullOrWhiteSpace(dr.title)).FirstOrDefault()?.title,
                                    InstallDirectory = Path.Combine(libraryPath, "library", gameFolder?.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, 2, StringSplitOptions.RemoveEmptyEntries)?.First()),
                                    IsInstalled = true,
                                    Platforms = new HashSet<MetadataProperty> { new MetadataSpecProperty("pc_windows") },
                                    //GameActions = new List<GameAction>(),
                                };
                                //game.GameActions.Add(new GameAction()
                                //{
                                //    IsPlayAction = true,
                                //    Path = $"robotcache://rungameid/{stateInfo.gameId}",
                                //});

                                game.Name = game.Name.RemoveTrademarks();
                                games.Add(game.GameId, game);
                            }
                        }
                    }
                }
            }

            return games;
        }

        internal List<GameMetadata> GetLibraryGames(CancellationToken cancelToken)
        {
            var cacheDir = GetCachePath("stashcache");
            var games = new List<GameMetadata>();
            using (var view = PlayniteApi.WebViews.CreateOffscreenView())
            {
                var accountApi = new RobotCacheAccountClient(view);
                if(accountApi.GetIsUserLoggedIn())
                {
                    var foundGames = accountApi.GetStash();

                    foreach (var gameData in foundGames)
                    {
                        if (cancelToken.IsCancellationRequested)
                        {
                            break;
                        }

                        var cacheFile = Paths.GetSafePathName($"{gameData.gameId}_short.json");
                        cacheFile = Path.Combine(cacheDir, cacheFile);
                        string stashJson = Serialization.ToJson(gameData, false);
                        FileSystem.WriteStringToFile(cacheFile, stashJson);

                        var game = new GameMetadata()
                        {
                            Source = new MetadataNameProperty("RobotCache"),
                            GameId = gameData.gameId.ToString(),
                            Name = gameData.name,
                            InstallDirectory = null,
                            Platforms = new HashSet<MetadataProperty> { new MetadataSpecProperty("pc_windows") },
                            //GameActions = new List<GameAction>(),
                        };
                        //game.GameActions.Add(new GameAction()
                        //{
                        //    IsPlayAction = true,
                        //    Path = $"robotcache://rungameid/{gameData.gameId}",
                        //});

                        game.Name = game.Name.RemoveTrademarks();
                        games.Add(game);
                    }
                }
            }

            return games;
        }

        private T GetCachedData<T>(string cacheFile, string url) where T : class
        {
            bool DoDownload = true;
            if (FileSystem.FileExists(cacheFile))
            {
                DoDownload = FileSystem.FileGetLastWriteTime(cacheFile).AddDays(1) < DateTime.UtcNow;
            }

            T gameData = default(T);

            if (!DoDownload)
            {
                if (FileSystem.FileExists(cacheFile))
                {
                    string rawJson = FileSystem.ReadStringFromFile(cacheFile);
                    try
                    {
                        gameData = Serialization.FromJson<T>(rawJson);
                    }
                    catch
                    {
                        DoDownload = true;
                    }
                }
                else
                {
                    DoDownload = true;
                }
            }

            if (DoDownload)
            {
                var gameDataWrap = RobotCacheAccountClient.DownloadMetadata<T>(url);
                FileSystem.WriteStringToFile(cacheFile, gameDataWrap.Item2);
                gameData = gameDataWrap.Item1;
            }

            return gameData;
        }

        public GameMetadata GetFullGameMetadata(Game game)
        {
            var cacheDir = GetCachePath("stashcache");

            var cacheFile = Paths.GetSafePathName($"{game.GameId}_full.json");
            cacheFile = Path.Combine(cacheDir, cacheFile);
            
            //using (var view = PlayniteApi.WebViews.CreateOffscreenView())
            {
                //var accountApi = new RobotCacheAccountClient(view);
                //if (accountApi.GetIsUserLoggedIn())
                {

                    // TODO consider loading this less often, the cache prevents multi-downloads but we're going to thrash reading the disk here without a memo
                    Dictionary<string, string> localizeData = GetCachedData<Dictionary<string, string>>(cacheFile, RobotCacheAccountClient.GetLocalizeUrl());
                    RobotCacheStash_FullTag[] tagData = GetCachedData<RobotCacheStash_FullTag[]>(cacheFile, RobotCacheAccountClient.GetTagDataUrl());

                    RobotCacheStash_FullItem gameData = GetCachedData<RobotCacheStash_FullItem>(cacheFile, RobotCacheAccountClient.GetGameMetadataUrl(game.GameId));
                    if (gameData != null)
                    {
                        var metadata = new GameMetadata()
                        {
                            //Source = new MetadataNameProperty("RobotCache"),
                            //GameId = game.GameId,
                        };

                        string imageCover = gameData.assets.Where(dr => dr.type == (int)RobotCacheAssetType.mainQuad).FirstOrDefault()?.url ?? gameData.assets.Where(dr => dr.type == (int)RobotCacheAssetType.mainSmall).FirstOrDefault()?.url;
                        //string imageLogo = gameData.assets.Where(dr => dr.type == (int)RobotCacheAssetType.gameLogoLarge).FirstOrDefault()?.url ?? gameData.assets.Where(dr => dr.type == (int)RobotCacheAssetType.gameLogoSmall).FirstOrDefault()?.url;
                        string imageBackground = gameData.assets.Where(dr => dr.type == (int)RobotCacheAssetType.background).FirstOrDefault()?.url;
                        string imageIcon = gameData.assets.Where(dr => dr.type == (int)RobotCacheAssetType.icon).FirstOrDefault()?.url;
                        if (!string.IsNullOrWhiteSpace(imageCover))
                        {
                            metadata.CoverImage = new MetadataFile(@"https://cdn.robotcache.com/" + imageCover);
                        }
                        if (!string.IsNullOrWhiteSpace(imageBackground))
                        {
                            metadata.BackgroundImage = new MetadataFile(@"https://cdn.robotcache.com/" + imageBackground);
                        }
                        if (!string.IsNullOrWhiteSpace(imageIcon))
                        {
                            metadata.Icon = new MetadataFile(@"https://cdn.robotcache.com/" + imageIcon);
                        }

                        //var links = gameData.itemLinks.Where(dr => !string.IsNullOrWhiteSpace(dr.url) && !string.IsNullOrWhiteSpace(dr.title)).Select(dr => new Link(dr.title ?? dr.url, dr.url)).ToList();

                        //gameData.forumUrl // possible forum link, seems to often be to FAQs and stuff

                        var publisherLink = gameData.itemLinks.Where(dr => dr.itemLinkType == (int)RobotCacheLinkType.Publisher).FirstOrDefault();
                        var developerLink = gameData.itemLinks.Where(dr => dr.itemLinkType == (int)RobotCacheLinkType.Developer).FirstOrDefault();

                        var links = new List<Link>();
                        links.Add(new Link("RobotCache", $@"https://store.robotcache.com/#!/game/{gameData.id}/{gameData.urn}"));
                        if (publisherLink != null && !string.IsNullOrWhiteSpace(publisherLink.title))
                        {
                            if (metadata.Publishers == null)
                            {
                                metadata.Publishers = new HashSet<MetadataProperty>();
                            }
                            metadata.Publishers.Add(new MetadataNameProperty(publisherLink.title));
                            /*if (!string.IsNullOrWhiteSpace(publisherLink.url))
                            {
                                links.Add(new Link(publisherLink.title, publisherLink.url));
                            }*/
                        }
                        if (developerLink != null && !string.IsNullOrWhiteSpace(developerLink.title))
                        {
                            if (metadata.Developers == null)
                            {
                                metadata.Developers = new HashSet<MetadataProperty>();
                            }
                            metadata.Developers.Add(new MetadataNameProperty(developerLink.title));
                            /*if (!string.IsNullOrWhiteSpace(developerLink.url))
                            {
                                links.Add(new Link(developerLink.title, developerLink.url));
                            }*/
                        }
                        metadata.Links = links;

                        if (!string.IsNullOrWhiteSpace(gameData.description))
                        {
                            metadata.Description = gameData.description;
                        }
                        else if (!string.IsNullOrWhiteSpace(gameData.shortDescription))
                        {
                            metadata.Description = gameData.shortDescription;
                        }

                        if (gameData.size > 0)
                        {
                            metadata.InstallSize = gameData.size * 1024;
                        }

                        if (gameData.releaseDate != null)
                        {
                            metadata.ReleaseDate = new ReleaseDate(gameData.releaseDate);
                        }

                        metadata.Genres = new HashSet<MetadataProperty>();
                        metadata.Features = new HashSet<MetadataProperty>();
                        if (gameData.mainGenre != null && !string.IsNullOrWhiteSpace(gameData.mainGenre?.name))
                        {
                            string name = gameData.mainGenre.name;
                            if(string.IsNullOrWhiteSpace(name))
                            {
                                var TagItem = tagData.Where(dr => dr.id == gameData.mainGenre.id).FirstOrDefault();
                                if (TagItem != null)
                                {
                                    name = TagItem.name;
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(name))
                            {
                                if (localizeData.ContainsKey(name))
                                {
                                    name = localizeData[name];
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(name))
                            {
                                metadata.Genres.Add(new MetadataNameProperty(name));
                            }
                        }
                        bool VR = false;
                        bool KBM = false;
                        bool Gamepad = false;
                        foreach (var tag in gameData.tags)
                        {
                            if(tag != null)
                            {
                                var tagDatum = tagData.Where(dr => dr.id == tag.id).FirstOrDefault();
                                if (tagDatum != null)
                                {
                                    string name = tagDatum.name;

                                    if (!string.IsNullOrWhiteSpace(name))
                                    {
                                        if (localizeData.ContainsKey(name))
                                        {
                                            name = localizeData[name];
                                        }
                                    }

                                    if (!string.IsNullOrWhiteSpace(name))
                                    {
                                        switch((RobotCacheTagType)tagDatum.type)
                                        {
                                            case RobotCacheTagType.Genre:
                                                metadata.Genres.Add(new MetadataNameProperty(name));
                                                break;
                                            case RobotCacheTagType.VRMode:
                                                switch ((RobotCacheTags)tagDatum.id)
                                                {
                                                    case RobotCacheTags.VRMode_Seated:
                                                        metadata.Features.Add(new MetadataNameProperty("VR Seated"));
                                                        break;
                                                    case RobotCacheTags.VRMode_Standing:
                                                        metadata.Features.Add(new MetadataNameProperty("VR Standing"));
                                                        break;
                                                    case RobotCacheTags.VRMode_RoomScale:
                                                        metadata.Features.Add(new MetadataNameProperty("VR Room-Scale"));
                                                        break;
                                                }
                                                break;
                                            case RobotCacheTagType.ControlFeature:
                                                switch ((RobotCacheTags)tagDatum.id)
                                                {
                                                    case RobotCacheTags.ControlFeature_KeyboardMouse:
                                                        KBM = true;
                                                        break;
                                                    case RobotCacheTags.ControlFeature_Gamepad:
                                                        Gamepad = true;
                                                        break;
                                                    case RobotCacheTags.ControlFeature_TrackedMotionControllers:
                                                        metadata.Features.Add(new MetadataNameProperty("VR Motion Controllers"));
                                                        break;
                                                    case RobotCacheTags.ControlFeature_VRSupported:
                                                    case RobotCacheTags.ControlFeature_WindowsMixedReality: // does this imply Motion Controllers?
                                                    case RobotCacheTags.ControlFeature_HTCVive: // does this imply Motion Controllers?
                                                    case RobotCacheTags.ControlFeature_OculusRift: // does this imply Motion Controllers?
                                                        VR = true;
                                                        break;
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        if(VR)
                        {
                            metadata.Features.Add(new MetadataNameProperty("VR"));
                            if(KBM)
                            {
                                metadata.Features.Add(new MetadataNameProperty("VR Keyboard / Mouse"));
                            }
                            if (Gamepad)
                            {
                                metadata.Features.Add(new MetadataNameProperty("VR Gamepad"));
                            }
                        }

                        return metadata;
                    }
                    return null;
                }
            }
            //return null;
        }

        public string GetCachePath(string dirName)
        {
            return Path.Combine(GetPluginUserDataPath(), dirName);
        }

        public override LibraryMetadataProvider GetMetadataDownloader()
        {
            return new RobotCacheMetadataProvider(this);
        }

        public override IEnumerable<InstallController> GetInstallActions(GetInstallActionsArgs args)
        {
            if (args.Game.PluginId != Id)
            {
                yield break;
            }

            yield return new RobotCacheInstallController(args.Game);
        }

        public override IEnumerable<UninstallController> GetUninstallActions(GetUninstallActionsArgs args)
        {
            if (args.Game.PluginId != Id)
            {
                yield break;
            }

            yield return new RobotCacheUninstallController(args.Game);
        }

        public override IEnumerable<PlayController> GetPlayActions(GetPlayActionsArgs args)
        {
            if (args.Game.PluginId != Id)
            {
                yield break;
            }

            yield return new RobotCachePlayController(args.Game);
        }

        //public string GetCachePath(string dirName)
        //{
        //    return Path.Combine(GetPluginUserDataPath(), dirName);
        //}

        public override IEnumerable<GameMetadata> GetGames(LibraryGetGamesArgs args)
        {
            var allGames = new List<GameMetadata>();
            var installedGames = new Dictionary<string, GameMetadata>();
            Exception importError = null;

            if (Settings.Settings.ImportInstalledGames)
            {
                try
                {
                    installedGames = GetInstalledGames();
                    Logger.Debug($"Found {installedGames.Count} installed RobotCache games.");
                    allGames.AddRange(installedGames.Values.ToList());
                }
                catch (Exception e)
                {
                    Logger.Error(e, "Failed to import installed RobotCache games.");
                    importError = e;
                }
            }

            if (Settings.Settings.ConnectAccount)
            {
                try
                {
                    var libraryGames = GetLibraryGames(args.CancelToken);
                    Logger.Debug($"Found {libraryGames.Count} library RobotCache games.");

                    if (!Settings.Settings.ImportUninstalledGames)
                    {
                        libraryGames = libraryGames.Where(lg => installedGames.ContainsKey(lg.GameId)).ToList();
                    }

                    foreach (var game in libraryGames)
                    {
                        if (installedGames.TryGetValue(game.GameId, out var installed))
                        {
                            installed.Playtime = game.Playtime;
                            installed.LastActivity = game.LastActivity;
                            installed.Name = game.Name;
                        }
                        else
                        {
                            allGames.Add(game);
                        }
                    }
                }
                catch (Exception e)
                {
                    Logger.Error(e, "Failed to import linked account RobotCache games details.");
                    importError = e;
                }
            }

            if (importError != null)
            {
                PlayniteApi.Notifications.Add(new NotificationMessage(
                    ImportErrorMessageId,
                    string.Format(PlayniteApi.Resources.GetString("LOCLibraryImportError"), Name) +
                    System.Environment.NewLine + importError.Message,
                    NotificationType.Error,
                    () => OpenSettingsView()));
            }
            else
            {
                PlayniteApi.Notifications.Remove(ImportErrorMessageId);
            }

            return allGames;
        }

        public override ISettings GetSettings(bool firstRunSettings)
        {
            return Settings;
        }

        public override UserControl GetSettingsView(bool firstRunSettings)
        {
            return new RobotCacheLibrarySettingsView();
        }
    }
}