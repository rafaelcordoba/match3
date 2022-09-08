using Game.Commons.Grid;
using Match.Core.Grid.Configuration;
using Match.Core.Tiles;

namespace Match.Core.Grid
{
    public class GridInitializer : IGridInitializer
    {
        private readonly IGridConfiguration _configuration;
        private readonly IRandomTileFactory _randomTileFactory;
        private readonly IGrid<Tile> _grid;

        public GridInitializer(
            IGridConfiguration configuration, 
            IRandomTileFactory randomTileFactory, 
            IGrid<Tile> grid)
        {
            _configuration = configuration;
            _randomTileFactory = randomTileFactory;
            _grid = grid;
        }

        public void Initialize()
        {
            _grid.Init(
                _configuration.Width, 
                _configuration.Height, 
                _configuration.TileSize);
            
            for (uint x = 0; x < _grid.Width; x++)
            for (uint y = 0; y < _grid.Height; y++)
            {
                var gridPosition = new GridPosition(x, y);
                var tile = _randomTileFactory.Create(gridPosition);
                _grid.SetItem(gridPosition, tile);
            }
        }
    }
}