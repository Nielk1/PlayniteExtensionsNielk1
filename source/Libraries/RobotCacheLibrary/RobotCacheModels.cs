
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCacheLibrary
{
    internal class RobotCacheModels
    {
        public List<int> gameOrders { get; set; }
        public List<string> libraries { get; set; }
    }
    public class RobotCacheStash_Item
    {
        public bool currentUserOwns { get; set; }
        public RobotCacheStash_Asset background { get; set; }
        public RobotCacheStash_Asset gameLogoLarge { get; set; }
        public RobotCacheStash_Asset gameLogoSmall { get; set; }
        public RobotCacheStash_Asset horizontal { get; set; }
        public RobotCacheStash_Asset mainSmall { get; set; }
        public RobotCacheStash_Asset mainSingle { get; set; }
        public RobotCacheStash_Asset mainLarge { get; set; }
        public RobotCacheStash_Asset mainDouble { get; set; }
        public RobotCacheStash_Asset mainQuad { get; set; }
        public RobotCacheStash_Asset mainHalf { get; set; }
        public RobotCacheStash_Asset video { get; set; }
        public RobotCacheStash_Asset videoPoster { get; set; }
        //public RobotCacheStash_MainBundle mainBundle { get; set; }
        public DateTime releaseDate { get; set; } // check this parses right
        public RobotCacheStash_Tag gameMainGenreTag { get; set; }
        public RobotCacheStash_Company[] gameCompanies { get; set; }
        public RobotCacheStash_Tag[] gameTags { get; set; }
        public RobotCacheStash_Asset[] screenshots { get; set; }
        public bool isDemoVersion { get; set; }
        public int gameId { get; set; }
        public int id { get; set; } // not sure what this is for, but it seems useless
        public int itemType { get; set; }
        public int releaseStateType { get; set; }
        public string ageRatings { get; set; }
        public int? baseGameId { get; set; }
        public string baseGameName { get; set; }
        public string baseGameURN { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public string urn { get; set; }
    }
    public class RobotCacheStash_FullItem
    {
        public int id { get; set; }
        public int itemId { get; set; } // not sure what this is for, but it seems useless
        public string name { get; set; }
        public string urn { get; set; }
        public int itemType { get; set; }
        public bool isDemoVersion { get; set; }
        public int releaseStateType { get; set; }
        public string shortDescription { get; set; }
        public string updateNotes { get; set; }
        public string legal { get; set; } // untested
        public string description { get; set; }
        public int mainBundleId { get; set; }

        //"mainBundlePrice": {
        //    "price": 19.99,
        //    "discountPrice": null,
        //    "discountPercent": null,
        //    "currencyType": 10,
        //    "convertTo": null,
        //    "countryId": 234,
        //    "discountStart": null,
        //    "discountEnd": null,
        //    "payableAmount": 19.99,
        //    "outOfCountry": false
        //},
        public string color1 { get; set; }
        public string color2 { get; set; }
        public string forumUrl { get; set; }
        //public string[] hashTags { get; set; } // untested
        public RobotCacheStash_MainGenreTag mainGenre { get; set; }
        public int? baseGameId { get; set; }
        public string baseGameName { get; set; }
        public string baseGameURN { get; set; }
        public DateTime releaseDate { get; set; } // check this parses right
        public DateTime systemReleaseDate { get; set; }
        public int releaseDateDisplayType { get; set; }
        public string ageRatings { get; set; }
        public UInt64 size { get; set; }
        public string sizeFriendly { get; set; }
        public int PlatformType { get; set; }
        public UInt64 languageType { get; set; } // bitfield
        public string languageTypeFriendly { get; set; }
        //"localizationTable": "[{\"LanguageType\":2,\"Interface\":true,\"FullAudio\":false,\"Subtitles\":true},{\"LanguageType\":8,\"Interface\":true,\"FullAudio\":false,\"Subtitles\":true},{\"LanguageType\":32,\"Interface\":true,\"FullAudio\":false,\"Subtitles\":true},{\"LanguageType\":256,\"Interface\":true,\"FullAudio\":true,\"Subtitles\":true},{\"LanguageType\":2048,\"Interface\":true,\"FullAudio\":true,\"Subtitles\":true},{\"LanguageType\":4096,\"Interface\":true,\"FullAudio\":true,\"Subtitles\":true},{\"LanguageType\":131072,\"Interface\":true,\"FullAudio\":true,\"Subtitles\":true},{\"LanguageType\":262144,\"Interface\":true,\"FullAudio\":false,\"Subtitles\":true},{\"LanguageType\":2097152,\"Interface\":true,\"FullAudio\":false,\"Subtitles\":true},{\"LanguageType\":33554432,\"Interface\":true,\"FullAudio\":true,\"Subtitles\":true},{\"LanguageType\":67108864,\"Interface\":true,\"FullAudio\":true,\"Subtitles\":true}]",
        //"richPresence": "null",
        //"minimumRequirements": "[{\"PlatformType\":8,\"OS\":\"Windows 7, Windows 8, Windows 10 (64bit)\",\"Processor\":\"Intel or AMD Dual Core CPU 2.5 GHz\",\"Memory\":\"4 GB RAM\",\"Graphics\":\"DirectX 10 Feature Level AMD or NVIDIA Card with 1 GB VRAM\",\"DirectX\":\"Version 11\",\"Storage\":\"32 GB available space\",\"Sound\":null,\"Notes\":null},{\"PlatformType\":2,\"OS\":null,\"Processor\":null,\"Memory\":null,\"Graphics\":null,\"DirectX\":null,\"Storage\":null,\"Sound\":null,\"Notes\":null},{\"PlatformType\":4,\"OS\":null,\"Processor\":null,\"Memory\":null,\"Graphics\":null,\"DirectX\":null,\"Storage\":null,\"Sound\":null,\"Notes\":null}]",
        //"recommendedRequirements": "[{\"PlatformType\":8,\"OS\":\"Windows 7, Windows 8, Windows 10 (64bit)\",\"Processor\":\"Intel or AMD Quad Core CPU 3 GHz\",\"Memory\":\"8 GB RAM\",\"Graphics\":\"DirectX 11 Feature Level AMD or NVIDIA Card with 2 GB VRAM\",\"DirectX\":\"Version 11\",\"Storage\":\"32 GB available space\",\"Sound\":null,\"Notes\":null},{\"PlatformType\":2,\"OS\":null,\"Processor\":null,\"Memory\":null,\"Graphics\":null,\"DirectX\":null,\"Storage\":null,\"Sound\":null,\"Notes\":null},{\"PlatformType\":4,\"OS\":null,\"Processor\":null,\"Memory\":null,\"Graphics\":null,\"DirectX\":null,\"Storage\":null,\"Sound\":null,\"Notes\":null}]",
        public string version { get; set; }
        public int? suggestedAge { get; set; }
        public RobotCacheStash_FullCompany[] companies { get; set; }
        public RobotCacheStash_FullTag[] tags { get; set; }
        public RobotCacheStash_FullAsset[] assets { get; set; }
        //"bundleItems": null,
        public RobotCacheStash_FullLink[] itemLinks { get; set; }
        //"reviewSummary": null
    }
    public class RobotCacheStash_ItemJS
    {
        public RobotCacheStash_Asset Background { get; set; }
        public RobotCacheStash_Asset GameLogoLarge { get; set; }
        public RobotCacheStash_Asset GameLogoSmall { get; set; }
        public RobotCacheStash_Asset MainSmall { get; set; }
        public RobotCacheStash_Asset MainSingle { get; set; }
        public RobotCacheStash_Asset MainLarge { get; set; }
        public DateTime SystemReleaseDate { get; set; } // check this parses right
        public int[] GameTags { get; set; }
        public int GameId { get; set; }
        public string BaseGameName { get; set; }
        public string BaseGameURN { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string GameURN { get; set; }

        internal RobotCacheStash_Item ToJsonApiFormat()
        {
            return new RobotCacheStash_Item()
            {
                background = Background,
                gameLogoLarge = GameLogoLarge,
                gameLogoSmall = GameLogoSmall,
                mainSmall = MainSmall,
                mainSingle = MainSingle,
                mainLarge = MainLarge,
                gameId = GameId,
                baseGameName = BaseGameName,
                baseGameURN = BaseGameURN,
                name = Name,
                urn = GameURN,
            };
        }
    }

    public class RobotCacheStash_Asset
    {
        public int assetType { get; set; }
        public string title { get; set; }
        public string mimeType { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class RobotCacheStash_FullAsset
    {
        public string title { get; set; }
        public string url { get; set; }
        public string mimeType { get; set; }
        public int type { get; set; }
    }
    public class RobotCacheStash_FullLink
    {
        public int itemId { get; set; }
        public int itemLinkType { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
        public int? displayOrder { get; set; }
        public int id { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modificationDate { get; set; }
    }

    /*internal class RobotCacheStash_MainBundle
    {
        public string title { get; set; }
    }*/

    public class RobotCacheStash_Tag
    {
        public int id { get; set; }
        public int gameTagType { get; set; }
        public string name { get; set; }
    }
    public class RobotCacheStash_FullTag
    {
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
    }
    public class RobotCacheStash_MainGenreTag
    {
        public int id { get; set; }
        public int gameTagType { get; set; }
        public string name { get; set; }
        //"displayOrder": null,
        public DateTime? creationDate { get; set; }
        public DateTime? modificationDate { get; set; }
    }

    public class RobotCacheStash_Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public int companyType { get; set; }
        public int[] companyTypeArray { get; set; }
    }
    public class RobotCacheStash_FullCompany
    {
        public int id { get; set; }
        public string name { get; set; }
        public string webSite { get; set; }
        public string email { get; set; }
        public int type { get; set; }
    }
    internal class RobotCacheStateInfo
    {
        public int gameId { get; set; }
        public RobotCacheStateInfo_State State { get; set; }
        public RobotCacheStateInfo_Execution[] Execution { get; set; }
    }
    internal class RobotCacheStateInfo_State
    {
        public int currentState { get; set; }
    }
    internal class RobotCacheStateInfo_Execution
    {
        public string title { get; set; }
        public string path { get; set; }
    }

    internal class RobotCacheStateInfo_MiningRewards
    {
        public bool isSuccessful { get; set; }
    }

    public enum RobotCacheAssetType
    {
        mainSmall = 10, // box art with no logo?
        mainLarge = 11, // box art with no logo?
        horizontal = 12, // old steam style (check dimensions
        background = 14,
        gameLogoSmall = 15,
        gameLogoLarge = 16,
        mainDouble = 18, // also old steam style, maybe takes up 2 slots?
        screenshot = 20,
        video = 21,
        videoPoster = 22, // video thumbnailss
        mainQuad = 23, // box art with logo (large) ?
        mainSingle = 24, // box art with logo?
    }

    public enum RobotCacheLinkType
    {
        Developer = 5,
        Publisher = 6,
        Title = 7, // unconfirmed
        Support = 9,
    }
}
