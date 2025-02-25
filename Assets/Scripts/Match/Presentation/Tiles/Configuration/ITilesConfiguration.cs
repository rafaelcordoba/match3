using System.Collections.Generic;

namespace Match.Presentation.Tiles.Configuration
{
    public interface ITilesConfiguration
    {
        List<TileGraphicPrefab> TilePrefabs { get; }
        TileView TileViewPrefab { get; }
        int PoolSize { get; }
    }
}