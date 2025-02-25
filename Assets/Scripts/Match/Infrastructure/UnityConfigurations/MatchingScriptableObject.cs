using Match.Application.Gameplay.Board.Matching;
using UnityEngine;

namespace Match.Infrastructure.UnityConfigurations
{
    [CreateAssetMenu(fileName = nameof(MatchingScriptableObject), menuName = "Match/New " + nameof(MatchingScriptableObject))]
    public class MatchingScriptableObject : ScriptableObject, IMatchingConfiguration
    {
        [field: SerializeField] public uint RequiredToMatch { get; set; }
    }
}