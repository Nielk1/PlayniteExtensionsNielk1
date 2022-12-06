using Playnite.SDK;
using Playnite.SDK.Data;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotCacheLibrary.Services;

namespace RobotCacheLibrary
{
    public class RobotCacheLibrarySettings : ObservableObject
    {
        public int Version { get; set; }
        public bool ImportInstalledGames { get; set; } //= RobotCacheLauncher.IsInstalled;
        public bool ConnectAccount { get; set; } = false;
        public bool ImportUninstalledGames { get; set; } = false;
    }

    public class RobotCacheLibrarySettingsViewModel : ObservableObject, ISettings
    {
        private readonly RobotCacheLibrary plugin;
        private RobotCacheLibrarySettings editingClone { get; set; }

        private RobotCacheLibrarySettings settings;
        public RobotCacheLibrarySettings Settings
        {
            get => settings;
            set
            {
                settings = value;
                OnPropertyChanged();
            }
        }

        public readonly ILogger Logger = LogManager.GetLogger();

        public bool IsUserLoggedIn
        {
            get
            {
                using (var view = plugin.PlayniteApi.WebViews.CreateOffscreenView())
                {
                    var api = new RobotCacheAccountClient(view);
                    return api.GetIsUserLoggedIn();
                }
            }
        }
        public RelayCommand<object> LoginCommand
        {
            get => new RelayCommand<object>((a) =>
            {
                Login();
            });
        }

        public RobotCacheLibrarySettingsViewModel(RobotCacheLibrary plugin)
        {
            // Injecting your plugin instance is required for Save/Load method because Playnite saves data to a location based on what plugin requested the operation.
            this.plugin = plugin;

            // Load saved settings.
            var savedSettings = plugin.LoadPluginSettings<RobotCacheLibrarySettings>();

            // LoadPluginSettings returns null if no saved data is available.
            if (savedSettings != null)
            {
                Settings = savedSettings;
            }
            else
            {
                Settings = new RobotCacheLibrarySettings();
            }
        }

        public void BeginEdit()
        {
            // Code executed when settings view is opened and user starts editing values.
            editingClone = Serialization.GetClone(Settings);
        }

        public void CancelEdit()
        {
            // Code executed when user decides to cancel any changes made since BeginEdit was called.
            // This method should revert any changes made to Option1 and Option2.
            Settings = editingClone;
        }

        public void EndEdit()
        {
            // Code executed when user decides to confirm changes made since BeginEdit was called.
            // This method should save settings made to Option1 and Option2.
            plugin.SavePluginSettings(Settings);
        }

        public bool VerifySettings(out List<string> errors)
        {
            // Code execute when user decides to confirm changes made since BeginEdit was called.
            // Executed before EndEdit is called and EndEdit is not called if false is returned.
            // List of errors is presented to user if verification fails.
            errors = new List<string>();
            return true;
        }

        private void Login()
        {
            try
            {
                using (var view = plugin.PlayniteApi.WebViews.CreateView(490, 670))
                {
                    var clientApi = new RobotCacheAccountClient(view);
                    clientApi.Login();
                }

                OnPropertyChanged(nameof(IsUserLoggedIn));

            }
            catch (Exception e) when (!Debugger.IsAttached)
            {
                plugin.PlayniteApi.Dialogs.ShowErrorMessage(plugin.PlayniteApi.Resources.GetString(LOC.RobotCacheNotLoggedInError), "");
                Logger.Error(e, "Failed to authenticate user.");
            }
        }
    }
}