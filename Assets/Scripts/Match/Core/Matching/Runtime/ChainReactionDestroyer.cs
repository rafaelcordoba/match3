using System;
using System.Collections.Generic;
using System.Linq;
using Game.Commons.Grid;
using Match.Core.Matching.Strategies;
using Match.Core.Tiles;

namespace Match.Core.Matching
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
                foreach (var matchingTile in matchingTiles)
                {
                    matchingTile.Destroyed = true;
                    _grid.SetItem(matchingTile.GridPosition, null);
                }

                if (matchingTiles.Count < 1) 
                    continue;
                
                tilesWereDestroyed = true;
                TilesDestroyed?.Invoke(matchingTiles.Count);
            }
            return tilesWereDestroyed;
        }
    }
}