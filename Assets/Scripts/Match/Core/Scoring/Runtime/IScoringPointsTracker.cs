using System;

namespace Match.Core.Scoring
{
    public interface IScoringPointsTracker
    {
        event Action<int> PointsChanged;
        int Points { get; }
        void ResetPoints();
    }
}