using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Commons.Input.Touch;
using Match.Core.Board.UI;
using Match.Core.Grid;
using Match.Core.Leaderboard;
using Match.Core.Scoring;
using Match.Core.Tiles;
using Match.Popups;
using VContainer.Unity;

namespace Match.Core.Board
{
    public class GameBootstrap : IAsyncStartable
    {
        private readonly ITilePoolController _tilePoolController;
        private readonly IAvailableTilesRepository _availableTilesRepository;
        private readonly BoardPresenter _boardPresenter;
        private readonly IPopupController _popupController;
        private readonly ITouchInputController _touchInputController;
        private readonly IGridInitializer _gridInitializer;
        private readonly IScoringTimerTracker _timerTracker;
        private readonly ILeaderboardController _leaderboardController;

        public GameBootstrap(
            ITilePoolController tilePoolController,
            IAvailableTilesRepository availableTilesRepository,
            IGridInitializer gridInitializer,
            IScoringTimerTracker timerTracker,
            ILeaderboardController leaderboardController,
            BoardPresenter boardPresenter,
            IPopupController popupController,
            ITouchInputController touchInputController)
        {
            _tilePoolController = tilePoolController;
            _availableTilesRepository = availableTilesRepository;
            _gridInitializer = gridInitializer;
            _timerTracker = timerTracker;
            _leaderboardController = leaderboardController;
            _boardPresenter = boardPresenter;
            _popupController = popupController;
            _touchInputController = touchInputController;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            InitializePool();
            _gridInitializer.Initialize();
            _boardPresenter.CreateTiles();
            await CheckPlayerName();
            StartGame();
        }

        private UniTask CheckPlayerName()
        {
            var completionSource = new UniTaskCompletionSource();
            var playerName = _leaderboardController.GetPlayerName();
            if (string.IsNullOrEmpty(playerName))
                OpenChangeNamePopup(completionSource);
            else
                completionSource.TrySetResult();
            return completionSource.Task;
        }

        private void OpenChangeNamePopup(IResolvePromise completionSource)
        {
            _popupController.OpenPopup(PopupType.ChangeNamePopup);
            _leaderboardController.PlayerNameChanged += _ => completionSource.TrySetResult();
        }

        private void StartGame()
        {
            _touchInputController.Enable();
            _timerTracker.ResetTimer();
        }

        private void InitializePool()
        {
            var tileTypes = _availableTilesRepository.Get();
            foreach (var tileType in tileTypes)
                _tilePoolController.InitializePool(tileType);
        }
    }
}