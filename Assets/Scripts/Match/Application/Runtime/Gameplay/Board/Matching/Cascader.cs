using Commons.Runtime.Grid;
using Cysharp.Threading.Tasks;

namespace Match.Application.Gameplay.Board.Matching
{
    public class Cascader : ICascader
    {
        private readonly IGrid<Tile> _grid;
        private readonly IBoardPresenter _boardPresenter;
        private readonly IGridRefiller _gridRefiller;
        private readonly IChainReactionDestroyer _chainReactionDestroyer;

        public Cascader(IGrid<Tile> grid, 
            IBoardPresenter boardPresenter, 
            IGridRefiller gridRefiller, 
            IChainReactionDestroyer chainReactionDestroyer)
        {
            _grid = grid;
            _boardPresenter = boardPresenter;
            _gridRefiller = gridRefiller;
            _chainReactionDestroyer = chainReactionDestroyer;
        }

        public async UniTask Cascade()
        {
            var inProgress = true;
            while (inProgress)
            {
                MoveTileDown();
                await _boardPresenter.MoveTilesAsync();
                _gridRefiller.Refill();
                _boardPresenter.Refill();
                await _boardPresenter.MoveTilesAsync();
                var success = _chainReactionDestroyer.ChainDestroy();
                if (success)
                    await _boardPresenter.DestroyTilesAsync();
                inProgress = success;
            }
        }

        private void MoveTileDown()
        {
            for (uint x = 0; x < _grid.Width; x++)
            for (uint y = 0; y < _grid.Height; y++)
            {
                var position = new GridPosition(x, y);
                var tile = _grid.GetItem(position);
                if (tile == null || tile.Destroyed) 
                    continue;
                MoveTileDown(y, x, tile);
            }
        }

        private void MoveTileDown(uint y, uint x, Tile tile)
        {
            var downY = y;
            while (downY > 0)
            {
                downY--;
                var downPosition = new GridPosition(x, downY);
                var tileDown = _grid.GetItem(downPosition);
                if (tileDown != null)
                    break;

                _grid.SetItem(tile.GridPosition, null);
                tile.GridPosition = downPosition;
                _grid.SetItem(downPosition, tile);
            }
        }
    }
}