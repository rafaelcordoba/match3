using System.Threading;
using Commons.Runtime.Input.Touch;
using Cysharp.Threading.Tasks;
using Match.Application.Gameplay;
using Match.Application.Gameplay.Board;
using Match.Application.Leaderboard;
using Match.Application.Scoring;
using Match.Popups.Runtime;
using Match.Presentation.Tiles;
using VContainer.Unity;

namespace Match.Presentation.Game
{
    public class GameEntrypoint : IAsyncStartable
    {
        private readonly ITilePoolController _tilePoolController;
        private readonly ITileTypeRepository _tileTypeRepository;
        private readonly IBoardPresenter _boardPresenter;
        private readonly IPopupController _popupController;
        private readonly ITouchInputController _touchInputController;
        private readonly IGridInitializer _gridInitializer;
        private readonly IScoringTimerTracker _timerTracker;
        private readonly ILeaderboardController _leaderboardController;

        public GameEntrypoint(
            ITilePoolController tilePoolController,
            ITileTypeRepository tileTypeRepository,
            IGridInitializer gridInitializer,
            IScoringTimerTracker timerTracker,
            ILeaderboardController leaderboardController,
            IBoardPresenter boardPresenter,
            IPopupController popupController,
            ITouchInputController touchInputController)
        {
            _tilePoolController = tilePoolController;
            _tileTypeRepository = tileTypeRepository;
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
            var tileTypes = _tileTypeRepository.Get();
            foreach (var tileType in tileTypes)
                _tilePoolController.InitializePool(tileType);
        }
    }
}