using Commons.Runtime.Input.Touch;
using Cysharp.Threading.Tasks;
using Match.Application.Gameplay;
using Match.Application.Gameplay.Board;
using Match.Application.Pausing;
using Match.Application.Scoring;

namespace Match.Application.PlayAgain
{
    public class PlayAgainController : IPlayAgainController
    {
        private readonly IScoringTimerTracker _timerTracker;
        private readonly IScoringPointsTracker _pointsTracker;
        private readonly IPauseController _pauseController;
        private readonly IGridInitializer _gridInitializer;
        private readonly IBoardPresenter _boardPresenter;
        private readonly IGameplayManager _gameplayManager;
        private readonly ITouchInputController _touchInputController;

        public PlayAgainController(
            IScoringTimerTracker timerTracker, 
            IScoringPointsTracker pointsTracker,
            IPauseController pauseController,
            IGridInitializer gridInitializer, 
            IGameplayManager gameplayManager, 
            IBoardPresenter boardPresenter)
        {
            _timerTracker = timerTracker;
            _pointsTracker = pointsTracker;
            _pauseController = pauseController;
            _gridInitializer = gridInitializer;
            _gameplayManager = gameplayManager;
            _boardPresenter = boardPresenter;
        }

        public async UniTask PlayAgainAsync()
        {
            _pauseController.Unpause();
            _timerTracker.ResetTimer();
            _pointsTracker.ResetPoints();
            _gridInitializer.Initialize();
            _gameplayManager.Stop();
            await RecreateBoardAsync();
        }

        private async UniTask RecreateBoardAsync()
        {
            _boardPresenter.ClearBoard();
            await _boardPresenter.DestroyTilesAsync();
            _boardPresenter.CreateTiles();
        }
    }
}