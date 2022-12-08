
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
        public int? displayOrder { get; set; }
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
        icon = 1,
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

    public enum RobotCacheReleaseType
    {
        ComingSoon = 2,
        PreOrder = 3,
        EarlyAccess = 4,
        Released = 5,
    }

    // This enum is probably useless as the data can change, but maybe some parts of it might be important
    public enum RobotCacheTags
    {
		//                                                                                                                             =   0,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Unknown"                          )] Tag_Unknown                             =   1,
        [RobotCacheTag(RobotCacheTagType.ControlFeature, "Keyboard_Mouse"                   )] ControlFeature_KeyboardMouse            =   2,
        [RobotCacheTag(RobotCacheTagType.ControlFeature, "Gamepad"                          )] ControlFeature_Gamepad                  =   3,
        [RobotCacheTag(RobotCacheTagType.ControlFeature, "Tracked_Motion_Controllers"       )] ControlFeature_TrackedMotionControllers =   4,
        [RobotCacheTag(RobotCacheTagType.ControlFeature, "Windows_Mixed_Reality"            )] ControlFeature_WindowsMixedReality      =   5,
        [RobotCacheTag(RobotCacheTagType.ControlFeature, "VR_Supported"                     )] ControlFeature_VRSupported              =   6,
        [RobotCacheTag(RobotCacheTagType.ControlFeature, "HTC_Vive"                         )] ControlFeature_HTCVive                  =   7,
        [RobotCacheTag(RobotCacheTagType.ControlFeature, "Oculus_Rift"                      )] ControlFeature_OculusRift               =   8,
        [RobotCacheTag(RobotCacheTagType.Genre         , "Action"                           )] Genre_Action                            =   9,
		//                                                                                                                             =  10,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Building"                         )] Tag_Building                            =  11,
        [RobotCacheTag(RobotCacheTagType.Genre         , "Adventure"                        )] Genre_Adventure                         =  12,
        [RobotCacheTag(RobotCacheTagType.Genre         , "Casual"                           )] Genre_Casual                            =  13,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Card_Game"                        )] Tag_CardGame                            =  14,
        [RobotCacheTag(RobotCacheTagType.Tag           , "City_Builder"                     )] Tag_CityBuilder                         =  15,
		//                                                                                                                             =  16,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Driving"                          )] Tag_Driving                             =  17,
		//                                                                                                                             =  18,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Educational"                      )] Tag_Educational                         =  19,
		//                                                                                                                             =  20,
		//                                                                                                                             =  21,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Fighting"                         )] Tag_Fighting                            =  22,
        [RobotCacheTag(RobotCacheTagType.Tag           , "First_Person"                     )] Tag_FirstPerson                         =  23,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Historical"                       )] Tag_Historical                          =  24,
        [RobotCacheTag(RobotCacheTagType.Genre         , "Horror"                           )] Genre_Horror                            =  25,
        [RobotCacheTag(RobotCacheTagType.Genre         , "Indie"                            )] Genre_Indie                             =  26,
		//                                                                                                                             =  27,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Management"                       )] Tag_Management                          =  28,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Multi_Player"                     )] Tag_MultiPlayer                         =  29,
		//                                                                                                                             =  30,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Open_World"                       )] Tag_OpenWorld                           =  31,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Platformer"                       )] Tag_Platformer                          =  32,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Point_And_Click"                  )] Tag_PointAndClick                       =  33,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Post_Apocalyptic"                 )] Tag_PostApocalyptic                     =  34,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Puzzle"                           )] Tag_Puzzle                              =  35,
        [RobotCacheTag(RobotCacheTagType.Genre         , "Racing"                           )] Genre_Racing                            =  36,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Real_Time_Strategy"               )] Tag_RealTimeStrategy                    =  37,
		//                                                                                                                             =  38,
        [RobotCacheTag(RobotCacheTagType.Genre         , "Role_Playing"                     )] Genre_RolePlaying                       =  39,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Sandbox"                          )] Tag_Sandbox                             =  40,
		//                                                                                                                             =  41,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Shooter"                          )] Tag_Shooter                             =  42,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Side_Scroller"                    )] Tag_SideScroller                        =  43,
        [RobotCacheTag(RobotCacheTagType.Genre         , "Simulation"                       )] Genre_Simulation                        =  44,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Single_Player"                    )] Tag_SinglePlayer                        =  45,
        [RobotCacheTag(RobotCacheTagType.Genre         , "Sport"                            )] Genre_Sport                             =  46,
		//                                                                                                                             =  47,
		//                                                                                                                             =  48,
        [RobotCacheTag(RobotCacheTagType.Genre         , "Strategy"                         )] Genre_Strategy                          =  49,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Survival"                         )] Tag_Survival                            =  50,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Tactical"                         )] Tag_Tactical                            =  51,
		//                                                                                                                             =  52,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Tower_Defense"                    )] Tag_TowerDefense                        =  53,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Turn_Based"                       )] Tag_TurnBased                           =  54,
        [RobotCacheTag(RobotCacheTagType.Tag           , "War"                              )] Tag_War                                 =  55,
        [RobotCacheTag(RobotCacheTagType.VRMode        , "Seated"                           )] VRMode_Seated                           =  56,
        [RobotCacheTag(RobotCacheTagType.VRMode        , "Standing"                         )] VRMode_Standing                         =  57,
        [RobotCacheTag(RobotCacheTagType.VRMode        , "Room_Scale"                       )] VRMode_RoomScale                        =  58,
        [RobotCacheTag(RobotCacheTagType.PlayerMode    , "Single_Player"                    )] PlayerMode_SinglePlayer                 =  59,
        [RobotCacheTag(RobotCacheTagType.PlayerMode    , "Multi_Player"                     )] PlayerMode_MultiPlayer                  =  60,
        [RobotCacheTag(RobotCacheTagType.PlayerMode    , "MMO"                              )] PlayerMode_MMO                          =  61,
        [RobotCacheTag(RobotCacheTagType.PlayerMode    , "Online_Multi_Player"              )] PlayerMode_OnlineMultiPlayer            =  62,
        [RobotCacheTag(RobotCacheTagType.PlayerMode    , "Local_Multi_Player"               )] PlayerMode_LocalMultiPlayer             =  63,
        [RobotCacheTag(RobotCacheTagType.PlayerMode    , "Co_op"                            )] PlayerMode_CoOp                         =  64,
        [RobotCacheTag(RobotCacheTagType.PlayerMode    , "Online_Co_op"                     )] PlayerMode_OnlineCoOp                   =  65,
        [RobotCacheTag(RobotCacheTagType.PlayerMode    , "Local_Co_op"                      )] PlayerMode_LocalCoOp                    =  66,
        [RobotCacheTag(RobotCacheTagType.PlayerMode    , "Shared_Split_Screen"              )] PlayerMode_SharedSplitScreen            =  67,
        [RobotCacheTag(RobotCacheTagType.PlayerMode    , "Cross_Platform_Multiplayer"       )] PlayerMode_CrossPlatformMultiplayer     =  68,
        [RobotCacheTag(RobotCacheTagType.ControlFeature, "Full_Controller_Support"          )] ControlFeature_FullControllerSupport    =  69,
        [RobotCacheTag(RobotCacheTagType.Tag           , "DLC"                              )] Tag_DLC                                 =  70,
        [RobotCacheTag(RobotCacheTagType.ControlFeature, "Partial_Controller_Support"       )] ControlFeature_PartialControllerSupport =  71,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Early_Access"                     )] Tag_EarlyAccess                         =  72,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Free_to_Play"                     )] Tag_FreeToPlay                          =  73,
        [RobotCacheTag(RobotCacheTagType.Tag           , "2D"                               )] Tag_2D                                  =  74,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Violent"                          )] Tag_Violent                             =  75,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Massively_Multiplayer"            )] Tag_MassivelyMultiplayer                =  76,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Atmospheric"                      )] Tag_Atmospheric                         =  77,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Story_Rich"                       )] Tag_StoryRich                           =  78,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Gore"                             )] Tag_Gore                                =  79,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Fantasy"                          )] Tag_Fantasy                             =  80,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Nudity"                           )] Tag_Nudity                              =  81,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Sexual_Content"                   )] Tag_SexualContent                       =  82,
        [RobotCacheTag(RobotCacheTagType.Tag           , "3D"                               )] Tag_3D                                  =  83,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Anime"                            )] Tag_Anime                               =  84,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Colorful"                         )] Tag_Colorful                            =  85,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Pixel_Graphics"                   )] Tag_PixelGraphics                       =  86,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Great_Soundtrack"                 )] Tag_GreatSoundtrack                     =  87,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Funny"                            )] Tag_Funny                               =  88,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Cute"                             )] Tag_Cute                                =  89,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Sci_fi"                           )] Tag_SciFi                               =  90,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Exploration"                      )] Tag_Exploration                         =  91,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Arcade"                           )] Tag_Arcade                              =  92,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Retro"                            )] Tag_Retro                               =  93,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Family_Friendly"                  )] Tag_FamilyFriendly                      =  94,
        [RobotCacheTag(RobotCacheTagType.Tag           , "VR"                               )] Tag_VR                                  =  95,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Difficult"                        )] Tag_Difficult                           =  96,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Relaxing"                         )] Tag_Relaxing                            =  97,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Comedy"                           )] Tag_Comedy                              =  98,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Female_Protagonist"               )] Tag_FemaleProtagonist                   =  99,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Action_Adventure"                 )] Tag_ActionAdventure                     = 100,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Third_Person"                     )] Tag_ThirdPerson                         = 101,
        [RobotCacheTag(RobotCacheTagType.Tag           , "FPS"                              )] Tag_FPS                                 = 102,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Visual_Novel"                     )] Tag_VisualNovel                         = 103,
        [RobotCacheTag(RobotCacheTagType.Tag           , "PvP"                              )] Tag_PvP                                 = 104,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Stylized"                         )] Tag_Stylized                            = 105,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Realistic"                        )] Tag_Realistic                           = 106,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Physics"                          )] Tag_Physics                             = 107,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Combat"                           )] Tag_Combat                              = 108,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Choices_Matter"                   )] Tag_ChoicesMatter                       = 109,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Design_and_Illustration"          )] Tag_DesignAndIllustration               = 110,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Top_Down"                         )] Tag_TopDown                             = 111,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Utilities"                        )] Tag_Utilities                           = 112,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dark"                             )] Tag_Dark                                = 113,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Mystery"                          )] Tag_Mystery                             = 114,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Psychological_Horror"             )] Tag_PsychologicalHorror                 = 115,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Character_Customization"          )] Tag_CharacterCustomization              = 116,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Space"                            )] Tag_Space                               = 117,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Cartoony"                         )] Tag_Cartoony                            = 118,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Controller"                       )] Tag_Controller                          = 119,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Local_Multiplayer"                )] Tag_LocalMultiplayer                    = 120,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Point_and_Click"                  )] Tag_PointAndClick2                      = 121,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Multiple_Endings"                 )] Tag_MultipleEndings                     = 122,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Minimalist"                       )] Tag_Minimalist                          = 123,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Replay_Value"                     )] Tag_ReplayValue                         = 124,
        [RobotCacheTag(RobotCacheTagType.Tag           , "2D_Platformer"                    )] Tag_2DPlatformer                        = 125,
        [RobotCacheTag(RobotCacheTagType.Tag           , "PvE"                              )] Tag_PvE                                 = 126,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Action_RPG"                       )] Tag_ActionRPG                           = 127,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Futuristic"                       )] Tag_Futuristic                          = 128,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Crafting"                         )] Tag_Crafting                            = 129,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Magic"                            )] Tag_Magic                               = 130,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Mature"                           )] Tag_Mature                              = 131,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Survival_Horror"                  )] Tag_SurvivalHorror                      = 132,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Zombies"                          )] Tag_Zombies                             = 133,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Puzzle_Platformer"                )] Tag_PuzzlePlatformer                    = 134,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Procedural_Generation"            )] Tag_ProceduralGeneration                = 135,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Hand_Drawn"                       )] Tag_HandDrawn                           = 136,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Resource_Management"              )] Tag_ResourceManagement                  = 137,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Linear"                           )] Tag_Linear                              = 138,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Cartoon"                          )] Tag_Cartoon                             = 139,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Shoot_Em_Up"                      )] Tag_ShootEmUp                           = 140,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Classic"                          )] Tag_Classic                             = 141,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Medieval"                         )] Tag_Medieval                            = 142,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Memes"                            )] Tag_Memes                               = 143,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Roguelike"                        )] Tag_Roguelike                           = 144,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Turn_Based_Combat"                )] Tag_TurnBasedCombat                     = 145,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Web_Publishing"                   )] Tag_WebPublishing                       = 146,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Turn_Based_Strategy"              )] Tag_TurnBasedStrategy                   = 147,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Movie"                            )] Tag_Movie                               = 148,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Hack_and_Slash"                   )] Tag_HackAndSlash                        = 149,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Fast_Paced"                       )] Tag_FastPaced                           = 150,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dark_Fantasy"                     )] Tag_DarkFantasy                         = 151,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Roguelite"                        )] Tag_Roguelite                           = 152,
        [RobotCacheTag(RobotCacheTagType.Tag           , "JRPG"                             )] Tag_JRPG                                = 153,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Party_Based_RPG"                  )] Tag_PartyBasedRPG                       = 154,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Romance"                          )] Tag_Romance                             = 155,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Short"                            )] Tag_Short                               = 156,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dating_Sim"                       )] Tag_DatingSim                           = 157,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Walking_Simulator"                )] Tag_WalkingSimulator                    = 158,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Drama"                            )] Tag_Drama                               = 159,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Base_Building"                    )] Tag_BaseBuilding                        = 160,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Stealth"                          )] Tag_Stealth                             = 161,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Logic"                            )] Tag_Logic                               = 162,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Beautiful"                        )] Tag_Beautiful                           = 163,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Animation_and_Modeling"           )] Tag_AnimationAndModeling                = 164,
        [RobotCacheTag(RobotCacheTagType.Tag           , "3D_Platformer"                    )] Tag_3DPlatformer                        = 165,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Software"                         )] Tag_Software                            = 166,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Choose_Your_Own_Adventure"        )] Tag_ChooseYourOwnAdventure              = 167,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Surreal"                          )] Tag_Surreal                             = 168,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Experimental"                     )] Tag_Experimental                        = 169,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Turn_Based_Tactics"               )] Tag_TurnBasedTactics                    = 170,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Bullet_Hell"                      )] Tag_BulletHell                          = 171,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Interactive_Fiction"              )] Tag_InteractiveFiction                  = 172,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dungeon_Crawler"                  )] Tag_DungeonCrawler                      = 173,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Narration"                        )] Tag_Narration                           = 174,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Hidden_Object"                    )] Tag_HiddenObject                        = 175,
        [RobotCacheTag(RobotCacheTagType.Tag           , "RTS"                              )] Tag_RTS                                 = 176,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Military"                         )] Tag_Military                            = 177,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Score_Attack"                     )] Tag_ScoreAttack                         = 178,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Third_Person_Shooter"             )] Tag_ThirdPersonShooter                  = 179,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Team_Based"                       )] Tag_TeamBased                           = 180,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Isometric"                        )] Tag_Isometric                           = 181,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Cyberpunk"                        )] Tag_Cyberpunk                           = 182,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Music"                            )] Tag_Music                               = 183,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Audio_Production"                 )] Tag_AudioProduction                     = 184,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Robots"                           )] Tag_Robots                              = 185,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Top_Down_Shooter"                 )] Tag_TopDownShooter                      = 186,
        [RobotCacheTag(RobotCacheTagType.Tag           , "RPG_Maker"                        )] Tag_RPGMaker                            = 187,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dark_Humor"                       )] Tag_DarkHumor                           = 188,
        [RobotCacheTag(RobotCacheTagType.Tag           , "1990s"                            )] Tag_1990s                               = 189,
        [RobotCacheTag(RobotCacheTagType.Tag           , "4_Player_Local"                   )] Tag_4PlayerLocal                        = 190,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Text_Based"                       )] Tag_TextBased                           = 191,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Hentai"                           )] Tag_Hentai                              = 192,
        [RobotCacheTag(RobotCacheTagType.Tag           , "2_5D"                             )] Tag_2_5D                                = 193,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Aliens"                           )] Tag_Aliens                              = 194,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Economy"                          )] Tag_Economy                             = 195,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Competitive"                      )] Tag_Competitive                         = 196,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Emotional"                        )] Tag_Emotional                           = 197,
        [RobotCacheTag(RobotCacheTagType.Tag           , "1980s"                            )] Tag_1980s                               = 198,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Abstract"                         )] Tag_Abstract                            = 199,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Video_Production"                 )] Tag_VideoProduction                     = 200,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Flight"                           )] Tag_Flight                              = 201,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Moddable"                         )] Tag_Moddable                            = 202,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Perma_Death"                      )] Tag_PermaDeath                          = 203,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Nature"                           )] Tag_Nature                              = 204,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Immersive_Sim"                    )] Tag_ImmersiveSim                        = 205,
        [RobotCacheTag(RobotCacheTagType.Tag           , "LGBTQ"                            )] Tag_LGBTQ                               = 206,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Soundtrack"                       )] Tag_Soundtrack                          = 207,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Cinematic"                        )] Tag_Cinematic                           = 208,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Conversation"                     )] Tag_Conversation                        = 209,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Investigation"                    )] Tag_Investigation                       = 210,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Action_Roguelike"                 )] Tag_ActionRoguelike                     = 211,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Inventory_Management"             )] Tag_InventoryManagement                 = 212,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Board_Game"                       )] Tag_BoardGame                           = 213,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Tutorial"                         )] Tag_Tutorial                            = 214,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Detective"                        )] Tag_Detective                           = 215,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Arena_Shooter"                    )] Tag_ArenaShooter                        = 216,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Thriller"                         )] Tag_Thriller                            = 217,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Psychological"                    )] Tag_Psychological                       = 218,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Character_Action_Game"            )] Tag_CharacterActionGame                 = 219,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Beat_Em_Up"                       )] Tag_BeatEmUp                            = 220,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Destruction"                      )] Tag_Destruction                         = 221,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Nonlinear"                        )] Tag_Nonlinear                           = 222,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Real_Time_Tactics"                )] Tag_RealTimeTactics                     = 223,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Strategy_RPG"                     )] Tag_StrategyRPG                         = 224,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Demons"                           )] Tag_Demons                              = 225,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Modern"                           )] Tag_Modern                              = 226,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Metroidvania"                     )] Tag_Metroidvania                        = 227,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Loot"                             )] Tag_Loot                                = 228,
        [RobotCacheTag(RobotCacheTagType.Tag           , "NSFW"                             )] Tag_NSFW                                = 229,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Tabletop"                         )] Tag_Tabletop                            = 230,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Psychedelic"                      )] Tag_Psychedelic                         = 231,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Time_Management"                  )] Tag_TimeManagement                      = 232,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dystopian"                        )] Tag_Dystopian                           = 233,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Level_Editor"                     )] Tag_LevelEditor                         = 234,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Addictive"                        )] Tag_Addictive                           = 235,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Clicker"                          )] Tag_Clicker                             = 236,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Artifical_Intelligence"           )] Tag_ArtificalIntelligence               = 237,
        [RobotCacheTag(RobotCacheTagType.Tag           , "MMORPG"                           )] Tag_MMORPG                              = 238,
        [RobotCacheTag(RobotCacheTagType.Tag           , "World_War_II"                     )] Tag_WorldWarII                          = 239,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Alternate_History"                )] Tag_AlternateHistory                    = 240,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Game_Development"                 )] Tag_GameDevelopment                     = 241,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Life_Sim"                         )] Tag_LifeSim                             = 242,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Tactical_RPG"                     )] Tag_TacticalRPG                         = 243,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Wargame"                          )] Tag_Wargame                             = 244,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Lore_Rich"                        )] Tag_LoreRich                            = 245,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Supernatural"                     )] Tag_Supernatural                        = 246,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Crime"                            )] Tag_Crime                               = 247,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Precision_Platformer"             )] Tag_PrecisionPlatformer                 = 248,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Comic_Book"                       )] Tag_ComicBook                           = 249,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dark_Comedy"                      )] Tag_DarkComedy                          = 250,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Software_Training"                )] Tag_SoftwareTraining                    = 251,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Parkour"                          )] Tag_Parkour                             = 252,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Twin_Stick_Shooter"               )] Tag_TwinStickShooter                    = 253,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Blood"                            )] Tag_Blood                               = 254,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Gran_Strategy"                    )] Tag_GranStrategy                        = 255,
        [RobotCacheTag(RobotCacheTagType.Tag           , "2D_Fighter"                       )] Tag_2DFighter                           = 256,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Automobile_Sim"                   )] Tag_AutomobileSim                       = 257,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Co_op_Campaign"                   )] Tag_CoOpCampaign                        = 258,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Souls_Like"                       )] Tag_SoulsLike                           = 259,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Science"                          )] Tag_Science                             = 260,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Runner"                           )] Tag_Runner                              = 261,
        [RobotCacheTag(RobotCacheTagType.Tag           , "CRPG"                             )] Tag_CRPG                                = 262,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Mythology"                        )] Tag_Mythology                           = 263,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Illuminati"                       )] Tag_Illuminati                          = 264,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Philosophical"                    )] Tag_Philosophical                       = 265,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Split_Screen"                     )] Tag_SplitScreen                         = 266,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Grid_Based_Movement"              )] Tag_GridBasedMovement                   = 267,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Open_World_Survivial_Craft"       )] Tag_OpenWorldSurvivialCraft             = 268,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Space_Sim"                        )] Tag_SpaceSim                            = 269,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Lovecraftian"                     )] Tag_Lovecraftian                        = 270,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Rhythm"                           )] Tag_Rhythm                              = 271,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Class_Based"                      )] Tag_ClassBased                          = 272,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Episodic"                         )] Tag_Episodic                            = 273,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Swordplay"                        )] Tag_Swordplay                           = 274,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Real_Time"                        )] Tag_RealTime                            = 275,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Epic"                             )] Tag_Epic                                = 276,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Gun_Customization"                )] Tag_GunCustomization                    = 277,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Battle_Royale"                    )] Tag_BattleRoyale                        = 278,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Cult_Classic"                     )] Tag_CultClassic                         = 279,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Mouse_Only"                       )] Tag_MouseOnly                           = 280,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Match_3"                          )] Tag_Match3                              = 281,
        [RobotCacheTag(RobotCacheTagType.Tag           , "eSports"                          )] Tag_eSports                             = 282,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dragons"                          )] Tag_Dragons                             = 283,
        [RobotCacheTag(RobotCacheTagType.Tag           , "3D_Vision"                        )] Tag_3DVision                            = 284,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Parody"                           )] Tag_Parody                              = 285,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Photo_Editing"                    )] Tag_PhotoEditing                        = 286,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Satire"                           )] Tag_Satire                              = 287,
        [RobotCacheTag(RobotCacheTagType.Tag           , "6DOF"                             )] Tag_6DOF                                = 288,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Nior"                             )] Tag_Nior                                = 289,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Political"                        )] Tag_Political                           = 290,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Steampunk"                        )] Tag_Steampunk                           = 291,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Voxel"                            )] Tag_Voxel                               = 292,
        [RobotCacheTag(RobotCacheTagType.Tag           , "America"                          )] Tag_America                             = 293,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Vehicular_Combat"                 )] Tag_VehicularCombat                     = 294,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Bullet_Time"                      )] Tag_BulletTime                          = 295,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Deckbuilding"                     )] Tag_Deckbuilding                        = 296,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Cats"                             )] Tag_Cats                                = 297,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Trading"                          )] Tag_Trading                             = 298,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Collectathon"                     )] Tag_Collectathon                        = 299,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Conspiracy"                       )] Tag_Conspiracy                          = 300,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Card_Battler"                     )] Tag_CardBattler                         = 301,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Hunting"                          )] Tag_Hunting                             = 302,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Mining"                           )] Tag_Mining                              = 303,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Mechs"                            )] Tag_Mechs                               = 304,
        [RobotCacheTag(RobotCacheTagType.Tag           , "MOBA"                             )] Tag_MOBA                                = 305,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Capitalism"                       )] Tag_Capitalism                          = 306,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Tanks"                            )] Tag_Tanks                               = 307,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Remake"                           )] Tag_Remake                              = 308,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Time_Manipulation"                )] Tag_TimeManipulation                    = 309,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Gothic"                           )] Tag_Gothic                              = 310,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Colony_Sim"                       )] Tag_ColonySim                           = 311,
        [RobotCacheTag(RobotCacheTagType.Tag           , "3D_Fighter"                       )] Tag_3DFighter                           = 312,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Politics"                         )] Tag_Politics                            = 313,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Hacking"                          )] Tag_Hacking                             = 314,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Ninja"                            )] Tag_Ninja                               = 315,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Pirates"                          )] Tag_Pirates                             = 316,
        [RobotCacheTag(RobotCacheTagType.Tag           , "4X"                               )] Tag_4X                                  = 317,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Otome"                            )] Tag_Otome                               = 318,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Time_Travel"                      )] Tag_TimeTravel                          = 319,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Real_Time_with_Pause"             )] Tag_RealTimeWithPause                   = 320,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Idler"                            )] Tag_Idler                               = 321,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Agriculture"                      )] Tag_Agriculture                         = 322,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Underground"                      )] Tag_Underground                         = 323,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Hex_Grid"                         )] Tag_HexGrid                             = 324,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Quick_Time_Events"                )] Tag_QuickTimeEvents                     = 325,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Cold_War"                         )] Tag_ColdWar                             = 326,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Mystery_Dungeon"                  )] Tag_MysteryDungeon                      = 327,
        [RobotCacheTag(RobotCacheTagType.Tag           , "God_Game"                         )] Tag_GodGame                             = 328,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Kickstarter"                      )] Tag_Kickstarter                         = 329,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Word_Game"                        )] Tag_WordGame                            = 330,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Martial_Arts"                     )] Tag_MartialArts                         = 331,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dynamic_Narration"                )] Tag_DynamicNarration                    = 332,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dog"                              )] Tag_Dog                                 = 333,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Superhero"                        )] Tag_Superhero                           = 334,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Farming_Sim"                      )] Tag_FarmingSim                          = 335,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Automation"                       )] Tag_Automation                          = 336,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Trains"                           )] Tag_Trains                              = 337,
        [RobotCacheTag(RobotCacheTagType.Tag           , "FMV"                              )] Tag_FMV                                 = 338,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Spectacle_Fighter"                )] Tag_SpectacleFighter                    = 339,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dionsaurs"                        )] Tag_Dionsaurs                           = 340,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Fishing"                          )] Tag_Fishing                             = 341,
        [RobotCacheTag(RobotCacheTagType.Tag           , "GameMaker"                        )] Tag_GameMaker                           = 342,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Naval"                            )] Tag_Naval                               = 343,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Hero_Shooter"                     )] Tag_HeroShooter                         = 344,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Combat_Racing"                    )] Tag_CombatRacing                        = 345,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Assassin"                         )] Tag_Assassin                            = 346,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Western"                          )] Tag_Western                             = 347,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Programming"                      )] Tag_Programming                         = 348,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Trading_Card_Game"                )] Tag_TradingCardGame                     = 349,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Experience"                       )] Tag_Experience                          = 350,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Asynchronous_Multiplayer"         )] Tag_AsynchronousMultiplayer             = 351,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Touch_Friendly"                   )] Tag_TouchFriendly                       = 352,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Underwater"                       )] Tag_Underwater                          = 353,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Heist"                            )] Tag_Heist                               = 354,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Mod"                              )] Tag_Mod                                 = 355,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Minigames"                        )] Tag_Minigames                           = 356,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Immersive"                        )] Tag_Immersive                           = 357,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Solitare"                         )] Tag_Solitare                            = 358,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Documentary"                      )] Tag_Documentary                         = 359,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Archery"                          )] Tag_Archery                             = 360,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Vampire"                          )] Tag_Vampire                             = 361,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Looter_Shooter"                   )] Tag_LooterShooter                       = 362,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Dungeons_and_Dragons"             )] Tag_DungeonsAndDragons                  = 363,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Party"                            )] Tag_Party                               = 364,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Diplomacy"                        )] Tag_Diplomacy                           = 365,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Political_Sim"                    )] Tag_PoliticalSim                        = 366,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Narrative"                        )] Tag_Narrative                           = 367,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Sequel"                           )] Tag_Sequel                              = 368,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Faith"                            )] Tag_Faith                               = 369,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Sokoban"                          )] Tag_Sokoban                             = 370,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Party_Game"                       )] Tag_PartyGame                           = 371,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Games_Workshop"                   )] Tag_GamesWorkshop                       = 372,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Creature_Collector"               )] Tag_CreatureCollector                   = 373,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Naval_Combat"                     )] Tag_NavalCombat                         = 374,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Snow"                             )] Tag_Snow                                = 375,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Foreign"                          )] Tag_Foreign                             = 376,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Sailing"                          )] Tag_Sailing                             = 377,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Transportation"                   )] Tag_Transportation                      = 378,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Music_Based_Procedural_Generation")] Tag_MusicBasedProceduralGeneration      = 379,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Time_Attack"                      )] Tag_TimeAttack                          = 380,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Gaming"                           )] Tag_Gaming                              = 381,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Villan_Protagonist"               )] Tag_VillanProtagonist                   = 382,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Crowdfunded"                      )] Tag_Crowdfunded                         = 383,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Football"                         )] Tag_Football                            = 384,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Soccer"                           )] Tag_Soccer                              = 385,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Sniper"                           )] Tag_Sniper                              = 386,
        [RobotCacheTag(RobotCacheTagType.Tag           , "World_War_I"                      )] Tag_WorldWarI                           = 387,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Silent_Protagonist"               )] Tag_SilentProtagonist                   = 388,
        [RobotCacheTag(RobotCacheTagType.Tag           , "On_Rails_Shooter"                 )] Tag_OnRailsShooter                      = 389,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Offroad"                          )] Tag_Offroad                             = 390,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Horses"                           )] Tag_Horses                              = 391,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Typing"                           )] Tag_Typing                              = 392,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Mars"                             )] Tag_Mars                                = 393,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Transhumanism"                    )] Tag_Transhumanism                       = 394,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Gambling"                         )] Tag_Gambling                            = 395,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Auto_Battler"                     )] Tag_AutoBattler                         = 396,
        [RobotCacheTag(RobotCacheTagType.Tag           , "360_Video"                        )] Tag_360Video                            = 397,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Chess"                            )] Tag_Chess                               = 398,
        [RobotCacheTag(RobotCacheTagType.Tag           , "TrackIR"                          )] Tag_TrackIR                             = 399,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Werewolves"                       )] Tag_Werewolves                          = 400,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Cooking"                          )] Tag_Cooking                             = 401,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Trivia"                           )] Tag_Trivia                              = 402,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Pinball"                          )] Tag_Pinball                             = 403,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Boxing"                           )] Tag_Boxing                              = 404,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Unforgiving"                      )] Tag_Unforgiving                         = 405,
        [RobotCacheTag(RobotCacheTagType.Tag           , "LEGO"                             )] Tag_LEGO                                = 406,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Farming"                          )] Tag_Farming                             = 407,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Nostalgia"                        )] Tag_Nostalgia                           = 408,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Traditional_Roguelike"            )] Tag_TraditionalRoguelike                = 409,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Based_On_A_Novel"                 )] Tag_BasedOnANovel                       = 410,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Warhammer_40K"                    )] Tag_Warhammer40K                        = 411,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Rome"                             )] Tag_Rome                                = 412,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Motorbike"                        )] Tag_Motorbike                           = 413,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Roguelike_Deckbuilder"            )] Tag_RoguelikeDeckbuilder                = 414,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Golf"                             )] Tag_Golf                                = 415,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Ambient"                          )] Tag_Ambient                             = 416,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Electronic_Music"                 )] Tag_ElectronicMusic                     = 417,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Spaceships"                       )] Tag_Spaceships                          = 418,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Medical_Sim"                      )] Tag_MedicalSim                          = 419,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Jet"                              )] Tag_Jet                                 = 420,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Asymmetric_VR"                    )] Tag_AsymmetricVR                        = 421,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Bikes"                            )] Tag_Bikes                               = 422,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Outbreak_Sim"                     )] Tag_OutbreakSim                         = 423,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Action_RTS"                       )] Tag_ActionRTS                           = 424,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Submarine"                        )] Tag_Submarine                           = 425,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Basketball"                       )] Tag_Basketball                          = 426,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Spelling"                         )] Tag_Spelling                            = 427,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Intenionally_Awkward_Controls"    )] Tag_IntenionallyAwkwardControls         = 428,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Roguevania"                       )] Tag_Roguevania                          = 429,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Social_Deduction"                 )] Tag_SocialDeduction                     = 430,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Mini_Golf"                        )] Tag_MiniGolf                            = 431,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Pool"                             )] Tag_Pool                                = 432,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Steam_Machine"                    )] Tag_SteamMachine                        = 433,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Benchmark"                        )] Tag_Benchmark                           = 434,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Hardware"                         )] Tag_Hardware                            = 435,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Instrumental_Music"               )] Tag_InstrumentalMusic                   = 436,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Wrestling"                        )] Tag_Wrestling                           = 437,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Baseball"                         )] Tag_Baseball                            = 438,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Tennis"                           )] Tag_Tennis                              = 439,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Lemmings"                         )] Tag_Lemmings                            = 440,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Skateboarding"                    )] Tag_Skateboarding                       = 441,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Feature_Film"                     )] Tag_FeatureFilm                         = 442,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Hockey"                           )] Tag_Hockey                              = 443,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Cycling"                          )] Tag_Cycling                             = 444,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Bowling"                          )] Tag_Bowling                             = 445,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Voice_Control"                    )] Tag_VoiceControl                        = 446,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Motocross"                        )] Tag_Motocross                           = 447,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Electronic"                       )] Tag_Electronic                          = 448,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Skating"                          )] Tag_Skating                             = 449,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Rock_Music"                       )] Tag_RockMusic                           = 450,
        [RobotCacheTag(RobotCacheTagType.Tag           , "ATV"                              )] Tag_ATV                                 = 451,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Well_Written"                     )] Tag_WellWritten                         = 452,
        [RobotCacheTag(RobotCacheTagType.Tag           , "8_bit_music"                      )] Tag_8BitMusic                           = 453,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Skiing"                           )] Tag_Skiing                              = 454,
        [RobotCacheTag(RobotCacheTagType.Tag           , "BMX"                              )] Tag_BMX                                 = 455,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Snowboarding"                     )] Tag_Snowboarding                        = 456,
        [RobotCacheTag(RobotCacheTagType.Tag           , "Reboot"                           )] Tag_Reboot                              = 457,
    }

    public enum RobotCacheTagType
    {
        Tag            = 0,
        Genre          = 1,
        PlayerMode     = 2,
        ControlFeature = 3,
        VRMode         = 4,
    }

    public class RobotCacheTagAttribute : Attribute
    {
        public string Key { get; set; }
        public RobotCacheTagType TagType { get; set; }
        public RobotCacheTagAttribute(RobotCacheTagType TyTagTypepe, string Key)
        {
            this.TagType = TagType;
            this.Key = Key;
        }
    }
}
