using System.Collections.Generic;
using Match.Core.Tiles.UI;

namespace Match.Core.Tiles.Configuration
{
    public interface ITilesConfiguration
    {
        List<TileGraphicPrefab> TilePrefabs { get; }
        TileView TileViewPrefab { get; }
        int PoolSize { get; }
    }
}