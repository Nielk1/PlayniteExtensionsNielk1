using Playnite;
using Playnite.Common;
using Playnite.SDK;
using Playnite.SDK.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Playnite.SDK.Plugins;

namespace RobotCacheLibrary
{
    public class RobotCacheInstallController : InstallController
    {
        private CancellationTokenSource watcherToken;

        public RobotCacheInstallController(Game game) : base(game)
        {
            Name = "Install using RobotCache";
        }

        public override void Install(InstallActionArgs args)
        {
            //if (!RobotCache.IsInstalled)
            //{
            //    throw new Exception("RobotCache installation not found.");
            //}

            ProcessStarter.StartUrl($"robotcache://rungameid/{Game.GameId}");
            StartInstallWatcher();
        }
        public override void Dispose()
        {
            watcherToken?.Cancel();
        }

        private async void StartInstallWatcher()
        {
            watcherToken = new CancellationTokenSource();
            var id = Game.GameId;
            await Task.Run(async () =>
            {
                while (true)
                {
                    if (watcherToken.IsCancellationRequested)
                    {
                        return;
                    }

                    var installed = RobotCacheLibrary.GetInstalledGames();
                    if (installed.TryGetValue(id, out var installedGame))
                    {
                        var installInfo = new GameInstallationData
                        {
                            InstallDirectory = installedGame.InstallDirectory
                        };

                        InvokeOnInstalled(new GameInstalledEventArgs(installInfo));
                        return;
                    }

                    await Task.Delay(10000);
                }
            });
        }
    }

    public class RobotCacheUninstallController : UninstallController
    {
        private CancellationTokenSource watcherToken;

        public RobotCacheUninstallController(Game game) : base(game)
        {
            Name = "Uninstall using RobotCache";
        }

        public override void Uninstall(UninstallActionArgs args)
        {
            //if (!RobotCache.IsInstalled)
            //{
            //    throw new Exception("RobotCache installation not found.");
            //}

            ProcessStarter.StartUrl($"robotcache://uninstall/{Game.GameId}");
            StartUninstallWatcher();
        }
        public override void Dispose()
        {
            watcherToken?.Cancel();
        }

        private async void StartUninstallWatcher()
        {
            watcherToken = new CancellationTokenSource();
            var id = Game.GameId;
            await Task.Run(async () =>
            {
                while (true)
                {
                    if (watcherToken.IsCancellationRequested)
                    {
                        return;
                    }

                    var installed = RobotCacheLibrary.GetInstalledGames();
                    if (installed.ContainsKey(id))
                    {
                        if (installed.TryGetValue(id, out var installedGame) && !installedGame.IsInstalled)
                        {
                            // we have a record, but it's not installed, or at least it appears to not be
                            InvokeOnUninstalled(new GameUninstalledEventArgs());
                            return;
                        }
                    }
                    else
                    {
                        // if we have no record, it's clearly not installed anymore
                        InvokeOnUninstalled(new GameUninstalledEventArgs());
                        return;
                    }

                    await Task.Delay(10000);
                }
            });
        }
    }

    public class RobotCachePlayController : PlayController
    {
        private ProcessMonitor procMon;
        private Stopwatch stopWatch;

        public RobotCachePlayController(Game game) : base(game)
        {
            Name = string.Format(ResourceProvider.GetString(LOC.RobotCacheStartUsingClient), "RobotCache");
        }

        public override void Dispose()
        {
            procMon?.Dispose();
        }

        public override void Play(PlayActionArgs args)
        {
            Dispose();

            var installDirectory = Game.InstallDirectory;

            ProcessStarter.StartUrl($"robotcache://rungameid/{Game.GameId}");
            procMon = new ProcessMonitor();
            procMon.TreeStarted += ProcMon_TreeStarted;
            procMon.TreeDestroyed += Monitor_TreeDestroyed;
            if (Directory.Exists(installDirectory))
            {
                procMon.WatchDirectoryProcesses(installDirectory, false);
            }
            else
            {
                InvokeOnStopped(new GameStoppedEventArgs());
            }
        }

        private void ProcMon_TreeStarted(object sender, ProcessMonitor.TreeStartedEventArgs args)
        {
            stopWatch = Stopwatch.StartNew();
            InvokeOnStarted(new GameStartedEventArgs());
        }

        private void Monitor_TreeDestroyed(object sender, EventArgs args)
        {
            stopWatch?.Stop();
            InvokeOnStopped(new GameStoppedEventArgs(Convert.ToUInt64(stopWatch?.Elapsed.TotalSeconds ?? 0)));
        }
    }
}
