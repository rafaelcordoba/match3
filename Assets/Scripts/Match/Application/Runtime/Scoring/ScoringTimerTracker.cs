using System;
using UnityEngine;
using VContainer.Unity;

namespace Match.Application.Scoring
{
    public class ScoringTimerTracker : IScoringTimerTracker, ITickable 
    {
        public event Action<int> TimeRemainingChanged;
        public event Action TimerEnded;

        private readonly IScoringConfiguration _configuration;
        private float _timeRemaining;
        private bool _started;
        private bool _timerEndedSent;

        public ScoringTimerTracker(IScoringConfiguration configuration)
            => _configuration = configuration;

        public void ResetTimer()
        {
            _started = true;
            _timerEndedSent = false;
            _timeRemaining = _configuration.GameTimeSeconds;
        }

        public void Tick()
        {
            if (!_started)
                return;
            
            if (_timeRemaining <= 1)
            {
                if (!_timerEndedSent)
                    TimerEnded?.Invoke();
                _timerEndedSent = true;
                return;
            }
            
            _timeRemaining -= Time.deltaTime;
            _timeRemaining = Math.Max(0, _timeRemaining);
            TimeRemainingChanged?.Invoke((int) _timeRemaining);
        }
    }
}