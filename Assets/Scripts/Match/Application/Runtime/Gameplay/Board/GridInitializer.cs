using Commons.Runtime.Grid;

namespace Match.Application.Gameplay.Board
{
    public class GridInitializer : IGridInitializer
    {
        private readonly IGridConfiguration _configuration;
        private readonly INoMatchAroundTileFactory _noMatchAroundTileFactory;
        private readonly IGrid<Tile> _grid;

        public GridInitializer(
            IGridConfiguration configuration, 
            INoMatchAroundTileFactory noMatchAroundTileFactory, 
            IGrid<Tile> grid)
        {
            _configuration = configuration;
            _noMatchAroundTileFactory = noMatchAroundTileFactory;
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
                var tile = _noMatchAroundTileFactory.Create(gridPosition);
                _grid.SetItem(gridPosition, tile);
            }
        }
    }
}