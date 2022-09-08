using System;

namespace Match.Core.Scoring
{
    public interface IScoringTimerTracker
    {
        event Action<int> TimeRemainingChanged;
        event Action TimerEnded;
        void ResetTimer();
    }
}