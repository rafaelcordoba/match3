using System.Threading;
using Cysharp.Threading.Tasks;
using Match.Application.Gameplay.Board;
using Match.Application.Gameplay.Board.Matching;
using VContainer;

namespace Match.Application.Gameplay
{
    public class GameplayManager : IGameplayManager
    {
        [Inject] private readonly ISwapper _swapper;
        [Inject] private readonly IMatchingDestroyer _matchingDestroyer;
        [Inject] private readonly ICascader _cascader;
        [Inject] private readonly IPlayerInputListener _playerInputListener;

        private CancellationTokenSource _cancellationTokenSource = new();
        
        public bool IsRunning { get; private set; }

        public async UniTask MoveTilesAsync(Tile origin, Tile target)
        {
            IsRunning = true;
            
            _cancellationTokenSource = new CancellationTokenSource();
            
            await _swapper.SwapAsync(origin, target);
            
            var success = await _matchingDestroyer.TryDestroy(new []{ origin, target });
            if (!success)
            {
                await _swapper.SwapAsync(origin, target);
                IsRunning = false;
                return;
            }

            _playerInputListener.Enabled = false;
            await _cascader.Cascade();
            _playerInputListener.Enabled = true;
            
            IsRunning = false;
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}