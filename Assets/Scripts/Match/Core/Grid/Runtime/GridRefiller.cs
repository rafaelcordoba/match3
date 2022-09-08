using Game.Commons.Grid;
using Match.Core.Tiles;

namespace Match.Core.Grid
{
    public class GridRefiller : IGridRefiller
    {
        private readonly IGrid<Tile> _grid;
        private readonly IRandomTileFactory _randomTileFactory;

        public GridRefiller(IGrid<Tile> grid, IRandomTileFactory randomTileFactory)
        {
            _grid = grid;
            _randomTileFactory = randomTileFactory;
        }

        public void Refill()
        {
            for (uint x = 0; x < _grid.Width; x++)
            for (uint y = 0; y < _grid.Height; y++)
            {
                var position = new GridPosition(x, y);
                var tile = _grid.GetItem(position);
                if (tile != null) 
                    continue;
                
                var newTile = _randomTileFactory.Create(position);
                newTile.Refilled = true;
                _grid.SetItem(position, newTile);
            }
        }
    }
}