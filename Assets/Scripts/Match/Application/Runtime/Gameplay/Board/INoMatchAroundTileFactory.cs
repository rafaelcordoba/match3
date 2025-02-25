using Commons.Runtime.Grid;

namespace Match.Application.Gameplay.Board
{
    public interface INoMatchAroundTileFactory
    {
        Tile Create(GridPosition gridPosition);
    }
}