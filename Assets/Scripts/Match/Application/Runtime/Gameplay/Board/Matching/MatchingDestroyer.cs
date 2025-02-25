using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Runtime.Grid;
using Cysharp.Threading.Tasks;

namespace Match.Application.Gameplay.Board.Matching
{
    public class MatchingDestroyer : IMatchingDestroyer
    {
        public event Action<int> TilesDestroyed;
        
        private readonly IMatcher _matcher;
        private readonly IGrid<Tile> _grid;
        private readonly IBoardPresenter _boardPresenter;

        public MatchingDestroyer(IMatcher matcher, IGrid<Tile> grid, IBoardPresenter boardPresenter)
        {
            _matcher = matcher;
            _grid = grid;
            _boardPresenter = boardPresenter;
        }

        public async UniTask<bool> TryDestroy(Tile[] tiles)
        {
            IEnumerable<UniTask<bool>> tasks = tiles.Select(TryDestroy);
            var results = await UniTask.WhenAll(tasks);
            return results.Any(result => result);
        }

        public async UniTask<bool> TryDestroy(Tile tile)
        {
            var matchingTiles = _matcher.Get(tile);
            if (matchingTiles.Count == 0)
                return false;
            var tilesDestroyed = DestroyTiles(matchingTiles);
            await _boardPresenter.DestroyTilesAsync();
            TilesDestroyed?.Invoke(tilesDestroyed);
            return tilesDestroyed > 0;
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