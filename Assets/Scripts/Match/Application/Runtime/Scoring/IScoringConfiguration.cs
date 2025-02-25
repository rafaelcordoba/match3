namespace Match.Application.Scoring
{
    public interface IScoringConfiguration
    {
        int PointsPow { get; }
        int PointsDivider { get; }
        int GameTimeSeconds { get; }
    }
}