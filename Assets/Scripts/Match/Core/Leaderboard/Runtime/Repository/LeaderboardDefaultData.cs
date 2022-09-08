using System.Collections.Generic;
using UnityEngine;

namespace Match.Core.Leaderboard.Repository
{
    [CreateAssetMenu(fileName = nameof(LeaderboardDefaultData), menuName = "Match/New " + nameof(LeaderboardDefaultData))]
    public class LeaderboardDefaultData : ScriptableObject, ILeaderboardDefaultData
    {
        [field: SerializeField] public List<LeaderboardEntryEntity> DefaultEntries { get; set; }
    }
}