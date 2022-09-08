using UnityEngine;

namespace Match.Core.Scoring.Configuration
{
    [CreateAssetMenu(fileName = nameof(ScoringConfiguration), menuName = "Match/New " + nameof(ScoringConfiguration))]
    public class ScoringConfiguration : ScriptableObject, IScoringConfiguration
    {
        [field: SerializeField] public int PointsPow { get; set; }
        [field: SerializeField] public int PointsDivider { get; set; }
        [field: SerializeField] public int GameTimeSeconds { get; set; }
    }
}