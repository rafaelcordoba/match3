namespace Match.Core.Scoring.Configuration
{
    public interface IScoringConfiguration
    {
        int PointsPow { get; }
        int PointsDivider { get; }
        int GameTimeSeconds { get; }
    }
}