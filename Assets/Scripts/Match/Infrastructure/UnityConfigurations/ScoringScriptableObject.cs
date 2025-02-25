using Match.Application.Scoring;
using UnityEngine;

namespace Match.Infrastructure.UnityConfigurations
{
    [CreateAssetMenu(fileName = nameof(ScoringScriptableObject), menuName = "Match/New " + nameof(ScoringScriptableObject))]
    public class ScoringScriptableObject : ScriptableObject, IScoringConfiguration
    {
        [field: SerializeField] public int PointsPow { get; set; }
        [field: SerializeField] public int PointsDivider { get; set; }
        [field: SerializeField] public int GameTimeSeconds { get; set; }
    }
}