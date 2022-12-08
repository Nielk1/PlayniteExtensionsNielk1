using Microsoft.Win32;
using Playnite.Common;
using Playnite.SDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotCacheLibrary
{
    public class RobotCacheClient : LibraryClient
    {
        private static readonly ILogger logger = LogManager.GetLogger();
        private static readonly string robotCacheExeName = "RobotCacheClient.exe";
        public override string Icon => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", @"robotcacheicon.png");

        public override bool IsInstalled => GetIsClientInstalled();

        public override void Open()
        {
            if (IsInstalled)
            {
                ProcessStarter.StartProcess(Path.Combine(GetClientInstallPath(), robotCacheExeName));
            }
            else
            {
                throw new Exception("RobotCache installation not found.");
            }
        }

        public override void Shutdown()
        {
            var mainProc = Process.GetProcessById(GetClientPid());
            if (mainProc == null || mainProc.ProcessName.ToLowerInvariant() + ".exe" != robotCacheExeName.ToLowerInvariant())
            {
                logger.Info("RobotCache client is no longer running, no need to shut it down.");
                return;
            }
            mainProc.CloseMainWindow();
            mainProc.Close();
        }



        public static string GetClientInstallPath()
        {
            string getInstallPath(RegistryView view)
            {
                string path = null;
                using (var root = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, view))
                using (var installKey = root.OpenSubKey(@"SOFTWARE\RobotCache\RobotCacheClient\ActiveProcess"))
                {
                    path = installKey?.GetValue("RobotCacheDll")?.ToString();
                }

                if (path.IsNullOrEmpty())
                {
                    using (var root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view))
                    using (var installKey = root.OpenSubKey(@"SOFTWARE\RobotCache\RobotCacheClient\ActiveProcess"))
                    {
                        path = installKey?.GetValue("RobotCacheDll")?.ToString();
                    }
                }

                if (!string.IsNullOrWhiteSpace(path))
                {
                    path = Path.GetDirectoryName(path);
                }

                return path;
            }

            var installPath = getInstallPath(RegistryView.Registry32);
            if (installPath.IsNullOrEmpty())
            {
                installPath = getInstallPath(RegistryView.Registry64);
            }

            return installPath;
        }

        public static int GetClientPid()
        {
            int? getInstallPath(RegistryView view)
            {
                object rawPid = null;
                using (var root = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, view))
                using (var installKey = root.OpenSubKey(@"SOFTWARE\RobotCache\RobotCacheClient\ActiveProcess"))
                {
                    rawPid = installKey?.GetValue("pid");
                }

                if (rawPid == null)
                {
                    using (var root = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view))
                    using (var installKey = root.OpenSubKey(@"SOFTWARE\RobotCache\RobotCacheClient\ActiveProcess"))
                    {
                        rawPid = installKey?.GetValue("pid");
                    }
                }

                if (rawPid != null)
                    return (int)(long)rawPid;
                return null;
            }

            var pid = getInstallPath(RegistryView.Registry32);
            if (pid == null)
            {
                pid = getInstallPath(RegistryView.Registry64);
            }

            return pid ?? 0;
        }

        public static bool GetIsClientInstalled()
        {
            var installDir = GetClientInstallPath();
            if (installDir.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                return File.Exists(Path.Combine(installDir, robotCacheExeName));
            }
        }
    }
}