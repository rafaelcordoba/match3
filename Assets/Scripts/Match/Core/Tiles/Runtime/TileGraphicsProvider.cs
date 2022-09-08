using System.Collections.Generic;
using Match.Core.Tiles.Configuration;
using Match.Core.Tiles.UI;

namespace Match.Core.Tiles
{
    public class TileGraphicsProvider : ITileGraphicsProvider
    {
        private readonly ITilesConfiguration _tilesConfiguration;
        private Dictionary<TileType, GraphicView> _cache;

        public TileGraphicsProvider(ITilesConfiguration tilesConfiguration)
        {
            _tilesConfiguration = tilesConfiguration;
            CacheData(tilesConfiguration);
        }

        public TileView GetTileViewPrefab()
            => _tilesConfiguration.TileViewPrefab;

        public GraphicView GetGraphicPrefab(TileType tileType)
            => _cache[tileType];

        private void CacheData(ITilesConfiguration tilesConfiguration)
        {
            _cache = new Dictionary<TileType, GraphicView>();
            foreach (var tileTypeView in tilesConfiguration.TilePrefabs)
            {
                _cache[tileTypeView.Type] = tileTypeView.Graphic;
            }
        }
    }
}