using Game.Commons.Grid;
using Match.Core.Tiles;

namespace Match.Core.Matching
{
    public class CascadeController : ICascadeController
    {
        private readonly IGrid<Tile> _grid;

        public CascadeController(IGrid<Tile> grid)
            => _grid = grid;

        public void Cascade()
        {
            for (uint x = 0; x < _grid.Width; x++)
            for (uint y = 0; y < _grid.Height; y++)
            {
                var position = new GridPosition(x, y);
                var tile = _grid.GetItem(position);
                if (tile == null || tile.Destroyed) 
                    continue;
                MoveTileDown(y, x, tile);
            }
        }

        private void MoveTileDown(uint y, uint x, Tile tile)
        {
            var downY = y;
            while (downY > 0)
            {
                downY--;
                var downPosition = new GridPosition(x, downY);
                var tileDown = _grid.GetItem(downPosition);
                if (tileDown != null)
                    break;

                _grid.SetItem(tile.GridPosition, null);
                tile.GridPosition = downPosition;
                _grid.SetItem(downPosition, tile);
            }
        }
    }
}