using System.Collections.Generic;

namespace Match.Core.SpecialTiles.Runtime.Configuration
{
    public interface ISpecialTilesConfiguration
    {
        List<SpecialTileConfiguration> Configurations { get; set; }
    }
}