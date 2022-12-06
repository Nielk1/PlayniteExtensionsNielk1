
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
        public string ageRatings { get; set; }
        public string baseGameName { get; set; }
        public string baseGameURN { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public string urn { get; set; }
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
                releaseDate = SystemReleaseDate,
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

    public class RobotCacheStash_Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public int companyType { get; set; }
        public int[] companyTypeArray { get; set; }
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
}
