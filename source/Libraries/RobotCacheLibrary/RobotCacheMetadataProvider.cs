
using Playnite.Common.Web;
using Playnite.SDK.Models;
using Playnite.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCacheLibrary
{
    public class RobotCacheMetadataProvider : LibraryMetadataProvider
    {
        private static readonly ILogger logger = LogManager.GetLogger();
        private readonly RobotCacheLibrary library;

        public RobotCacheMetadataProvider(RobotCacheLibrary library)
        {
            this.library = library;
        }

        public override GameMetadata GetMetadata(Game game)
        {
            return library.GetFullGameMetadata(game);
        }
    }
}
