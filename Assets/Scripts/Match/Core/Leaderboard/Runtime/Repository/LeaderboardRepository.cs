using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace Match.Core.Leaderboard.Repository
{
    [CreateAssetMenu(fileName = nameof(LeaderboardRepository), menuName = "Match/New " + nameof(LeaderboardRepository))]
    public class LeaderboardRepository : ScriptableObject, ILeaderboardRepository
    {
        [SerializeField] private string _playerName;
        [SerializeField] private List<LeaderboardEntryEntity> _entries;

        public string GetPlayerName()
            => _playerName;

        public void SetPlayerName(string value)
            => _playerName = value;

        public IReadOnlyList<LeaderboardEntryEntity> GetEntries()
            => _entries;

        public void SetEntries(IEnumerable<LeaderboardEntryEntity> value)
            => _entries = value.ToList();
    }
}