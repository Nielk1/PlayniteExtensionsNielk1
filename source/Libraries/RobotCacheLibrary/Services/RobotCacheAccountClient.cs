using Playnite.SDK;
using Playnite.SDK.Data;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RobotCacheLibrary.Services
{
    public class RobotCacheAccountClient
    {
        private static ILogger logger = LogManager.GetLogger();
        private readonly IWebView webView;
        private const string localizeEnApiUrl = @"https://store.robotcache.com/i18n/en.json";
        private const string tagsApiUrl = @"https://store.robotcache.com/api/tags";
        private const string gameApiUrl = @"https://store.robotcache.com/api/game/{0}";
        private const string stashApiUrl = @"https://store.robotcache.com/api/user/stash";
        private const string stashNavUrl = @"https://store.robotcache.com/user/stash";
        private const string stashUrl = @"https://store.robotcache.com/user/stash#!/";
        private const string crudeLoginCheckUrl = @"https://store.robotcache.com/api/gamification/miningRewards/past/";
        public RobotCacheAccountClient(IWebView webView)
        {
            this.webView = webView;
        }

        public void Login()
        {
            webView.LoadingChanged += (s, e) =>
            {
                var address = webView.GetCurrentAddress();
                if (address == stashUrl)
                {
                    webView.Close();
                }
            };

            // webView.DeleteDomainCookies isn't working here for some reason, so let's just clean the 3 key cookies manually and hope that's good enough
            webView.DeleteCookies("store.robotcache.com", ".AspNetCore.RCCookie");
            webView.DeleteCookies("store.robotcache.com", ".AspNetCore.RCCookieC1");
            webView.DeleteCookies("store.robotcache.com", ".AspNetCore.RCCookieC2");

            webView.Navigate(stashNavUrl);
            webView.OpenDialog();
        }

        public bool GetIsUserLoggedIn()
        {
            webView.NavigateAndWait(crudeLoginCheckUrl);
            string rawText = webView.GetPageText();

            // quick detect not logged in
            if (rawText.Trim() == "\"Past_Reward_Set_Does_Not_Exist\"")
            {
                return false;
            }

            // in theory this call should always succeed if logged in, if it ever gives data but says isSuccessful is false they probably changed the system, so trust isSuccessful
            try
            {
                RobotCacheStateInfo_MiningRewards rewards = Serialization.FromJson<RobotCacheStateInfo_MiningRewards>(rawText);
                return rewards.isSuccessful;
            }
            catch { }

            return false;
        }

        public List<RobotCacheStash_Item> GetStash()
        {
            if (!GetIsUserLoggedIn())
            {
                throw new Exception("User is not authenticated.");
            }

            Dictionary<int, RobotCacheStash_Item> cacheItemMap = new Dictionary<int, RobotCacheStash_Item>();

            // gather clean JSON data of the stash
            webView.NavigateAndWait(stashApiUrl);
            string stashApiRaw = webView.GetPageText();
            RobotCacheStash_Item[] stashItems = Serialization.FromJson<RobotCacheStash_Item[]>(stashApiRaw);
            foreach(var stashItem in stashItems)
            {
                if (!cacheItemMap.ContainsKey(stashItem.gameId))
                {
                    cacheItemMap[stashItem.gameId] = stashItem;
                }
            }

            // gather some JS data from the stash webpage, for some reason the game TRAPPED doesn't appear in the JSON stash data for me, so there might be a way to get it to appear but I just don't know it
            webView.NavigateAndWait(stashUrl);
            string stashHtmlRaw = webView.GetPageSource();
            // search the HTML to find the JS representation of stash data
            string[] stashExtractedJson = stashHtmlRaw.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries).Where(dr => dr.Trim().StartsWith(@"var data = ")).FirstOrDefault()?.Split(new char[] { '=' }, 2);
            if(stashExtractedJson != null && stashExtractedJson.Length == 2)
            {
                try
                {
                    // Note: The casing of the JSON above was cammel-case, but here it's full-case, so we get around any possible deserializer issues by making seperate schema with a conversion function
                    RobotCacheStash_ItemJS[] stashWebItems = Serialization.FromJson<RobotCacheStash_ItemJS[]>(stashExtractedJson[1].Trim().TrimEnd(';'));

                    foreach (var stashWebItem in stashWebItems)
                    {
                        if (!cacheItemMap.ContainsKey(stashWebItem.GameId))
                        {
                            cacheItemMap[stashWebItem.GameId] = stashWebItem.ToJsonApiFormat();
                        }
                    }
                }
                catch
                {
                    logger.Warn("Failed to parse JS stash data, some problematic games might not be detected.");
                }
            }

            return cacheItemMap.Values.ToList();
        }

        public Tuple<T, string> DownloadMetadata<T>(string url) where T : class
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers["cache-control"] = "no-cache";
                    client.Headers["accept-language"] = "en-US,en;q=0.9";
                    var cookieString = string.Join(";", webView.GetCookies()?.Select(a => $"{a.Name}={a.Value}"));
                    client.Headers.Add(HttpRequestHeader.Cookie, cookieString);
                    byte[] rawData = null;
                    rawData = client.DownloadData(url);
                    if (rawData != null)
                    {
                        string rawText = Encoding.UTF8.GetString(rawData);

                        T gameData = Serialization.FromJson<T>(rawText);

                        return new Tuple<T, string>(gameData, rawText);
                    }
                }
            }
            catch (Exception e) when (!Debugger.IsAttached)
            {
                logger.Error(e, $"Failed to get metadata {typeof(T)} from \"{url}\".");
            }
            return null;
        }

        internal static string GetGameMetadataUrl(string gameId)
        {
            return string.Format(gameApiUrl, gameId);
        }

        internal static string GetLocalizeUrl()
        {
            return localizeEnApiUrl;
        }

        internal static string GetTagDataUrl()
        {
            return tagsApiUrl;
        }
    }
}