using System;
using Match.Application.Scoring;
using VContainer.Unity;

namespace Match.Presentation.Scoring
{
    public class ScoringPresenter : IStartable, IDisposable
    {
        private readonly IScoringPointsTracker _pointsTracker;
        private readonly IScoringTimerTracker _timerTracker;
        private readonly IScoringView _scoringView;

        public ScoringPresenter(
            IScoringPointsTracker pointsTracker,
            IScoringTimerTracker timerTracker,
            IScoringView scoringView)
        {
            _pointsTracker = pointsTracker;
            _timerTracker = timerTracker;
            _scoringView = scoringView;
        }

        public void Start()
        {
            _pointsTracker.PointsChanged += OnPointsChanged;
            _timerTracker.TimeRemainingChanged += OnTimeRemainingChanged;
        }

        public void Dispose()
        {
            _pointsTracker.PointsChanged -= OnPointsChanged;
            _timerTracker.TimeRemainingChanged -= OnTimeRemainingChanged;
        }

        private void OnPointsChanged(int points)
            => _scoringView.SetPoints(points);

        private void OnTimeRemainingChanged(int timeRemaining)
            => _scoringView.SetCountdown(timeRemaining);
    }
}