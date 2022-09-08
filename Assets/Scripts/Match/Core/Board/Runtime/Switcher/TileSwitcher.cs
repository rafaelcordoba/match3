using System;
using Game.Commons.Grid;
using Game.Commons.Input.Swipe;
using Match.Core.Tiles;
using UnityEngine;

namespace Match.Core.Board.Switcher
{
    public class TileSwitcher : ITileSwitcher
    {
        private readonly IGrid<Tile> _grid;

        public TileSwitcher(IGrid<Tile> grid)
        {
            _grid = grid;
        }

        public SwitcherResult TrySwitch(Vector2 worldStartPosition, SwipeDirection swipeDirection)
        {
            var originTile = _grid.GetItem(worldStartPosition);
            if (originTile == null)
                return null;
            
            var neighbourTile = GetNeighbourTile(swipeDirection, originTile.GridPosition);
            if (neighbourTile == null)
                return null;
            
            SwitchTiles(originTile, neighbourTile);
            return new SwitcherResult
            {
                OriginTile = originTile,
                NeighbourTile = neighbourTile
            };
        }

        public void SwitchBack(SwitcherResult switcherResult)
            => SwitchTiles(switcherResult.OriginTile, switcherResult.NeighbourTile);

        private Tile GetNeighbourTile(SwipeDirection swipeDirection, GridPosition originPosition)
        {
            var neighbourPosition = GetNeighbourPosition(swipeDirection, originPosition);
            return _grid.GetItem(neighbourPosition);
        }

        private static GridPosition GetNeighbourPosition(SwipeDirection swipeDirection, GridPosition originPosition)
        {
            return swipeDirection switch
            {
                SwipeDirection.None => originPosition,
                SwipeDirection.Up => new GridPosition(originPosition.X, originPosition.Y + 1),
                SwipeDirection.Down => new GridPosition(originPosition.X, originPosition.Y - 1),
                SwipeDirection.Left => new GridPosition(originPosition.X - 1, originPosition.Y),
                SwipeDirection.Right => new GridPosition(originPosition.X + 1, originPosition.Y),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void SwitchTiles(Tile origin, Tile neighbour)
        {
            var originPosition = origin.GridPosition;
            var neighbourPosition = neighbour.GridPosition;
            
            _grid.SetItem(originPosition, neighbour);
            _grid.SetItem(neighbourPosition, origin);
            
            neighbour.GridPosition = originPosition;
            origin.GridPosition = neighbourPosition;
        }
    }
}