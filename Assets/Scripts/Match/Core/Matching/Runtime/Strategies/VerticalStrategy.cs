using System.Collections.Generic;
using Game.Commons.Grid;
using Match.Core.Tiles;

namespace Match.Core.Matching.Strategies
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

            // search down
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
            
            // search up
            searchY = origin.GridPosition.Y;
            while (searchY < _grid.Height - 1)
            {
                searchY++;
                var gridPosition = new GridPosition(origin.GridPosition.X, searchY);
                var neighbour = _grid.GetItem(gridPosition);
                if (neighbour == null || neighbour.TileType != origin.TileType)
                    break;
                matchingTiles.Add(neighbour);
            }

            return matchingTiles;
        }
    }
}