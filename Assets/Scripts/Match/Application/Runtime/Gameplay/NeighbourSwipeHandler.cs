using System;
using System.Threading;
using Commons.Runtime.Grid;
using Commons.Runtime.Input.Swipe;
using Cysharp.Threading.Tasks;
using Match.Application.Gameplay.Board;
using VContainer.Unity;

namespace Match.Application.Gameplay
{
    public class NeighbourSwipeHandler : IInitializable, IDisposable
    {
        private readonly IGrid<Tile> _grid;
        private readonly IGameplayManager _gameplayManager;
        private readonly IPlayerInputListener _playerInputListener;
        private readonly INeighbourFinder _neighbourFinder;

        private CancellationTokenSource _cancellationTokenSource;

        public NeighbourSwipeHandler(IGrid<Tile> grid, 
            IGameplayManager gameplayManager, 
            IPlayerInputListener playerInputListener, 
            INeighbourFinder neighbourFinder)
        {
            _grid = grid;
            _gameplayManager = gameplayManager;
            _playerInputListener = playerInputListener;
            _neighbourFinder = neighbourFinder;
        }
        
        public void Initialize()
        {
            _playerInputListener.Swiped += HandleSwipe;
        }

        public void Dispose()
        {
            _playerInputListener.Swiped -= HandleSwipe;
        }

        private void HandleSwipe(SwipeInfo swipeInfo)
        {
            var origin = _grid.GetItem(swipeInfo.StartWorldPosition);
            if (swipeInfo.SwipeDirection == SwipeDirection.None || origin == null)
            {
                return;
            }
            
            var target = _neighbourFinder.Find(swipeInfo.SwipeDirection, origin.GridPosition);
            if (target == null)
            {
                return;
            }

            _gameplayManager.MoveTilesAsync(origin, target).Forget();
        }
    }
}