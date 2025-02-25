using Commons.Runtime.Grid;

namespace Match.Application.Gameplay.Board
{
    public class GridRefiller : IGridRefiller
    {
        private readonly IGrid<Tile> _grid;
        private readonly INoMatchAroundTileFactory _noMatchAroundTileFactory;

        public GridRefiller(IGrid<Tile> grid, INoMatchAroundTileFactory noMatchAroundTileFactory)
        {
            _grid = grid;
            _noMatchAroundTileFactory = noMatchAroundTileFactory;
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
                
                var newTile = _noMatchAroundTileFactory.Create(position);
                newTile.Refilled = true;
                _grid.SetItem(position, newTile);
            }
        }
    }
}