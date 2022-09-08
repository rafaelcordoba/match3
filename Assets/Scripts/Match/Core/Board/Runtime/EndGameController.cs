using System;
using Cysharp.Threading.Tasks;
using Game.Commons.Input.Touch;
using Match.Core.Leaderboard;
using Match.Core.Pausing;
using Match.Core.Scoring;
using Match.Popups;
using VContainer.Unity;

namespace Match.Core.Board
{
    public class EndGameController : IStartable, IDisposable
    {
        private readonly IScoringTimerTracker _scoringTimerTracker;
        private readonly IScoringPointsTracker _scoringPointsTracker;
        private readonly IBoardFlowController _boardFlowController;
        private readonly ILeaderboardController _leaderboardController;
        private readonly IPauseController _pauseController;
        private readonly IPopupController _popupController;
        private readonly ITouchInputController _inputController;

        public EndGameController(
            IScoringTimerTracker scoringTimerTracker, 
            IScoringPointsTracker scoringPointsTracker,
            IBoardFlowController boardFlowController, 
            ILeaderboardController leaderboardController,
            IPauseController pauseController, 
            IPopupController popupController, 
            ITouchInputController inputController)
        {
            _scoringTimerTracker = scoringTimerTracker;
            _scoringPointsTracker = scoringPointsTracker;
            _boardFlowController = boardFlowController;
            _leaderboardController = leaderboardController;
            _pauseController = pauseController;
            _popupController = popupController;
            _inputController = inputController;
        }


        public void Start()
            => _scoringTimerTracker.TimerEnded += OnTimerTrackerEnded;

        public void Dispose()
            => _scoringTimerTracker.TimerEnded -= OnTimerTrackerEnded;

        private void OnTimerTrackerEnded()
        {
            EndGame().Forget();
        }

        private async UniTaskVoid EndGame()
        {
            _inputController.Disable();
            await UniTask.WaitWhile(() => _boardFlowController.FlowInProgress);
            _pauseController.Pause();
            _leaderboardController.SetPoints(_scoringPointsTracker.Points);
            _popupController.OpenPopup(PopupType.LeaderboardPopup);
        }
    }
}