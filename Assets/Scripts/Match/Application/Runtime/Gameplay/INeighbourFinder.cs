using Commons.Runtime.Grid;
using Commons.Runtime.Input.Swipe;
using Match.Application.Gameplay.Board;

namespace Match.Application.Gameplay
{
    public interface INeighbourFinder
    {
        Tile Find(SwipeDirection swipeDirection, GridPosition originPosition);
    }
}