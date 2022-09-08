using System.Collections.Generic;
using Game.Commons.Grid;
using Match.Core.Tiles;

namespace Match.Core.Matching.Strategies
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
            
            // search left
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
            
            // search right
            searchX = origin.GridPosition.X;
            while (searchX < _grid.Width - 1)
            {
                searchX++;
                var gridPosition = new GridPosition(searchX, origin.GridPosition.Y);
                var neighbour = _grid.GetItem(gridPosition);
                if (neighbour == null || neighbour.TileType != origin.TileType)
                    break;
                matchingTiles.Add(neighbour);
            }

            return matchingTiles;
        }
    }
}