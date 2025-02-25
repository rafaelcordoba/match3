using System;

namespace Match.Application.Scoring
{
    public interface IScoringPointsTracker
    {
        event Action<int> PointsChanged;
        int Points { get; }
        void ResetPoints();
    }
}