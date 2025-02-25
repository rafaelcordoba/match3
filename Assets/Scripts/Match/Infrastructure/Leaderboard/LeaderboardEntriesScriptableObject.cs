using System.Collections.Generic;
using Match.Application.Leaderboard;
using UnityEngine;

namespace Match.Infrastructure.Leaderboard
{
    [CreateAssetMenu(fileName = nameof(LeaderboardEntriesScriptableObject), menuName = "Match/New " + nameof(LeaderboardEntriesScriptableObject))]
    public class LeaderboardEntriesScriptableObject : ScriptableObject, ILeaderboardDefaultData
    {
        [field: SerializeField] public List<LeaderboardEntryEntity> DefaultEntries { get; set; }
    }
}