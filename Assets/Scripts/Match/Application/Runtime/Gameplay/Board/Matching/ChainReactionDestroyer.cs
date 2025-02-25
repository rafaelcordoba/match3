using System;
using System.Collections.Generic;
using Commons.Runtime.Grid;

namespace Match.Application.Gameplay.Board.Matching
{
    public class ChainReactionDestroyer : IChainReactionDestroyer
    {
        public event Action<int> TilesDestroyed;
        
        private readonly IGrid<Tile> _grid;
        private readonly IMatcher _matcher;

        public ChainReactionDestroyer(IGrid<Tile> grid, IMatcher matcher)
        {
            _grid = grid;
            _matcher = matcher;
        }

        public bool ChainDestroy()
        {
            var tilesWereDestroyed = false; 
            foreach (var tile in _grid.Items)
            {
                if (tile == null || tile.Destroyed)
                    continue;
                
                var matchingTiles = _matcher.Get(tile);
                DestroyTiles(matchingTiles);

                if (matchingTiles.Count < 1) 
                    continue;
                
                tilesWereDestroyed = true;
                TilesDestroyed?.Invoke(matchingTiles.Count);
            }
            return tilesWereDestroyed;
        }

        private void DestroyTiles(IEnumerable<Tile> matchingTiles)
        {
            foreach (var matchingTile in matchingTiles)
            {
                matchingTile.Destroyed = true;
                _grid.SetItem(matchingTile.GridPosition, null);
            }
        }
    }
}