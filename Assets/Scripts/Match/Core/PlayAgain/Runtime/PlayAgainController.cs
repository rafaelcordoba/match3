using System;
using Match.Core.Grid;
using Match.Core.Pausing;
using Match.Core.Scoring;

namespace Match.Core.PlayAgain
{
    public class PlayAgainController : IPlayAgainController
    {
        public event Action PlayAgainRequested;
        private readonly IScoringTimerTracker _timerTracker;
        private readonly IScoringPointsTracker _pointsTracker;
        private readonly IPauseController _pauseController;
        private readonly IGridInitializer _gridInitializer;

        public PlayAgainController(
            IScoringTimerTracker timerTracker, 
            IScoringPointsTracker pointsTracker,
            IPauseController pauseController,
            IGridInitializer gridInitializer)
        {
            _timerTracker = timerTracker;
            _pointsTracker = pointsTracker;
            _pauseController = pauseController;
            _gridInitializer = gridInitializer;
        }

        public void PlayAgain()
        {
            _timerTracker.ResetTimer();
            _pointsTracker.ResetPoints();
            _pauseController.UnPause();
            _gridInitializer.Initialize();
            PlayAgainRequested?.Invoke();
        }
    }
}