using System;
using Game.Commons.Grid;
using Match.Core.Matching.Strategies;
using Match.Core.Tiles;

namespace Match.Core.Matching
{
    public class MatchingDestroyer : IMatchingDestroyer
    {
        public event Action<int> TilesDestroyed;
        
        private readonly IMatcher _matcher;
        private readonly IGrid<Tile> _grid;

        public MatchingDestroyer(IMatcher matcher, IGrid<Tile> grid)
        {
            _matcher = matcher;
            _grid = grid;
        }

        public int Destroy(Tile origin)
        {
            var matchingTiles = _matcher.Get(origin);
            if (matchingTiles.Count == 0)
                return 0;
            
            foreach (var tile in matchingTiles)
            {
                tile.Destroyed = true;
                _grid.SetItem(tile.GridPosition, null);
            }

            var tilesDestroyed = matchingTiles.Count;
            TilesDestroyed?.Invoke(tilesDestroyed);
            return tilesDestroyed;
        }
    }
}