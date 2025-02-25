using System.Collections.Generic;
using Commons.Runtime.Grid;

namespace Match.Application.Gameplay.Board.Matching.Strategies
{
    public class VerticalStrategy : IMatchingStrategy
    {
        private readonly IGrid<Tile> _grid;

        public VerticalStrategy(IGrid<Tile> grid)
        {
            _grid = grid;
        }
        
        public IReadOnlyList<Tile> GetMatches(Tile origin)
        {
            var matchingTiles = new List<Tile> { origin };
            SearchDown(origin, matchingTiles);
            SearchUp(origin, matchingTiles);
            return matchingTiles;
        }

        private void SearchDown(Tile origin, List<Tile> matchingTiles)
        {
            var searchY = origin.GridPosition.Y;
            while (searchY > 0)
            {
                searchY--;
                var gridPosition = new GridPosition(origin.GridPosition.X, searchY);
                var neighbour = _grid.GetItem(gridPosition);
                if (neighbour == null || neighbour.TileType != origin.TileType)
                    break;
                matchingTiles.Add(neighbour);
            }
        }

        private void SearchUp(Tile origin, List<Tile> matchingTiles)
        {
            var searchY = origin.GridPosition.Y;
            while (searchY < _grid.Height - 1)
            {
                searchY++;
                var gridPosition = new GridPosition(origin.GridPosition.X, searchY);
                var neighbour = _grid.GetItem(gridPosition);
                if (neighbour == null || neighbour.TileType != origin.TileType)
                    break;
                matchingTiles.Add(neighbour);
            }
        }
    }
}