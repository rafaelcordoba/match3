using Game.Commons.Grid;
using Match.Core.Tiles;

namespace Match.Core.Grid
{
    public interface IRandomTileFactory
    {
        Tile Create(GridPosition gridPosition);
    }
}