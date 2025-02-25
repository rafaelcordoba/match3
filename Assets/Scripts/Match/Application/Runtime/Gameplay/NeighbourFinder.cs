using System;
using Commons.Runtime.Grid;
using Commons.Runtime.Input.Swipe;
using Match.Application.Gameplay.Board;

namespace Match.Application.Gameplay
{
    public class NeighbourFinder : INeighbourFinder
    {
        private readonly IGrid<Tile> _grid;

        public NeighbourFinder(IGrid<Tile> grid)
        {
            _grid = grid;
        }

        public Tile Find(SwipeDirection swipeDirection, GridPosition originPosition)
        {
            var neighbourPosition = GetNeighbourPosition(swipeDirection, originPosition);
            return _grid.GetItem(neighbourPosition);
        }

        private static GridPosition GetNeighbourPosition(SwipeDirection swipeDirection, GridPosition originPosition)
        {
            return swipeDirection switch
            {
                SwipeDirection.Up => new GridPosition(originPosition.X, originPosition.Y + 1),
                SwipeDirection.Down => new GridPosition(originPosition.X, originPosition.Y - 1),
                SwipeDirection.Left => new GridPosition(originPosition.X - 1, originPosition.Y),
                SwipeDirection.Right => new GridPosition(originPosition.X + 1, originPosition.Y),
                SwipeDirection.None => throw new ArgumentOutOfRangeException(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}