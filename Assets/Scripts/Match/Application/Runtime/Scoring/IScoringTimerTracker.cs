using System;

namespace Match.Application.Scoring
{
    public interface IScoringTimerTracker
    {
        event Action<int> TimeRemainingChanged;
        event Action TimerEnded;
        void ResetTimer();
    }
}