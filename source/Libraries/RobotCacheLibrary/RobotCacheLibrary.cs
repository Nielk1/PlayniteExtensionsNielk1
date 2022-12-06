using Playnite.SDK;
using Playnite.SDK.Data;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using RobotCacheLibrary.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        //public override LibraryClient Client { get; } = new RobotCacheLibraryClient();

        public string ImportErrorMessageId { get; }
        public RobotCacheLibrary(IPlayniteAPI api) : base(api)
        {
            Settings = new RobotCacheLibrarySettingsViewModel(this);
            Properties = new LibraryPluginProperties
            {
                HasSettings = true
            };
            LibraryIcon = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", @"robotcacheicon.png");
            ImportErrorMessageId = $"{Name}_libImportError";
        }

        public static Dictionary<string, GameMetadata> GetInstalledGames()
        {
            var games = new Dictionary<string, GameMetadata>();

            string appConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RobotCache", "RobotCacheClient", "config", "appConfig.json");
            RobotCacheModels appConfig = Serialization.FromJson<RobotCacheModels>(File.ReadAllText(appConfigPath));
            foreach(string libraryPath in appConfig.libraries)
            {
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
            //var cacheDir = GetCachePath("catalogcache");
            var games = new List<GameMetadata>();
            using (var view = PlayniteApi.WebViews.CreateOffscreenView())
            {
                var accountApi = new RobotCacheAccountClient(view);
                if(accountApi.GetIsUserLoggedIn())
                {
                    var foundGames = accountApi.GetStash();

                    foreach (var gameData in foundGames)
                    {
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