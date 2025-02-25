using System;
using Match.Application.Leaderboard;
using Match.Application.Pausing;
using Match.Application.Scoring;
using Match.Popups.Runtime;
using VContainer.Unity;

namespace Match.Application.Gameplay
{
    public class EndGameController : IStartable, IDisposable
    {
        private readonly IScoringTimerTracker _scoringTimerTracker;
        private readonly IScoringPointsTracker _scoringPointsTracker;
        private readonly ILeaderboardController _leaderboardController;
        private readonly IPauseController _pauseController;
        private readonly IPopupController _popupController;

        public EndGameController(
            IScoringTimerTracker scoringTimerTracker, 
            IScoringPointsTracker scoringPointsTracker,
            ILeaderboardController leaderboardController,
            IPauseController pauseController, 
            IPopupController popupController)
        {
            _scoringTimerTracker = scoringTimerTracker;
            _scoringPointsTracker = scoringPointsTracker;
            _leaderboardController = leaderboardController;
            _pauseController = pauseController;
            _popupController = popupController;
        }


        public void Start()
            => _scoringTimerTracker.TimerEnded += OnTimerTrackerEnded;

        public void Dispose()
            => _scoringTimerTracker.TimerEnded -= OnTimerTrackerEnded;

        private void OnTimerTrackerEnded()
        {
            EndGame();
        }

        private void EndGame()
        {
            _pauseController.Pause();
            _leaderboardController.SetPoints(_scoringPointsTracker.Points);
            _popupController.OpenPopup(PopupType.LeaderboardPopup);
        }
    }
}