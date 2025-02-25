using System;
using Commons.Runtime.Grid;
using Cysharp.Threading.Tasks;

namespace Match.Application.Gameplay.Board
{
    public class Swapper : ISwapper
    {
        private readonly IGrid<Tile> _grid;
        private readonly IBoardPresenter _boardPresenter;

        public Swapper(IGrid<Tile> grid, IBoardPresenter boardPresenter)
        {
            _grid = grid;
            _boardPresenter = boardPresenter;
        }

        public async UniTask SwapAsync(Tile origin, Tile target)
        {
            if (origin == null)
                throw new Exception("Origin tile is null");
            
            if (target == null)
                throw new Exception("Target tile is null");
            
            var originPosition = origin.GridPosition;
            var neighbourPosition = target.GridPosition;
            
            _grid.SetItem(originPosition, target);
            _grid.SetItem(neighbourPosition, origin);
            
            target.GridPosition = originPosition;
            origin.GridPosition = neighbourPosition;
            
            await _boardPresenter.MoveTilesAsync();
        }
    }
}