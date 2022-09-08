using System;
using System.Collections.Generic;
using Game.Commons.Grid;
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
            var tilesDestroyed = DestroyTiles(matchingTiles);
            TilesDestroyed?.Invoke(tilesDestroyed);
            return tilesDestroyed;
        }

        private int DestroyTiles(IReadOnlyCollection<Tile> matchingTiles)
        {
            foreach (var tile in matchingTiles)
            {
                tile.Destroyed = true;
                _grid.SetItem(tile.GridPosition, null);
            }
            return matchingTiles.Count;
        }
    }
}