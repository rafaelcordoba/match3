using System.Collections.Generic;
using Commons.Runtime.Grid;

namespace Match.Application.Gameplay.Board.Matching.Strategies
{
    public class HorizontalStrategy : IMatchingStrategy
    {
        private readonly IGrid<Tile> _grid;

        public HorizontalStrategy(IGrid<Tile> grid)
        {
            _grid = grid;
        }
        
        public IReadOnlyList<Tile> GetMatches(Tile origin)
        {
            var matchingTiles = new List<Tile> { origin };
            SearchLeft(origin, matchingTiles);
            SearchRight(origin, matchingTiles);
            return matchingTiles;
        }

        private void SearchLeft(Tile origin, ICollection<Tile> matchingTiles)
        {
            var searchX = origin.GridPosition.X;
            while (searchX > 0)
            {
                searchX--;
                var gridPosition = new GridPosition(searchX, origin.GridPosition.Y);
                var neighbour = _grid.GetItem(gridPosition);
                if (neighbour == null || neighbour.TileType != origin.TileType)
                    break;
                matchingTiles.Add(neighbour);
            }
        }

        private void SearchRight(Tile origin, ICollection<Tile> matchingTiles)
        {
            var searchX = origin.GridPosition.X;
            while (searchX < _grid.Width - 1)
            {
                searchX++;
                var gridPosition = new GridPosition(searchX, origin.GridPosition.Y);
                var neighbour = _grid.GetItem(gridPosition);
                if (neighbour == null || neighbour.TileType != origin.TileType)
                    break;
                matchingTiles.Add(neighbour);
            }
        }
    }
}