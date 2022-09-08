using UnityEngine;

namespace Match.Core.Matching.Configuration
{
    [CreateAssetMenu(fileName = nameof(MatchingConfiguration), menuName = "Match/New " + nameof(MatchingConfiguration))]
    public class MatchingConfiguration : ScriptableObject, IMatchingConfiguration
    {
        [field: SerializeField] public uint RequiredToMatch { get; set; }
    }
}