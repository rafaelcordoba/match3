using System.Collections.Generic;
using Match.Application.Leaderboard;
using Newtonsoft.Json;
using UnityEngine;

namespace Match.Infrastructure.Leaderboard
{
    public class LeaderboardPlayerPrefsRepository : ILeaderboardRepository
    {
        private const string PLAYER_NAME_KEY = "LeaderboardPlayerPrefsRepository_PlayerName";
        private const string ENTRIES_KEY = "LeaderboardPlayerPrefsRepository_Entries";

        public string GetPlayerName()
            => PlayerPrefs.GetString(PLAYER_NAME_KEY);

        public void SetPlayerName(string value)
            => PlayerPrefs.SetString(PLAYER_NAME_KEY, value);

        public IEnumerable<LeaderboardEntryEntity> GetEntries()
        {
            var json = PlayerPrefs.GetString(ENTRIES_KEY);
            return JsonConvert.DeserializeObject<List<LeaderboardEntryEntity>>(json);
        }

        public void SetEntries(IEnumerable<LeaderboardEntryEntity> value)
        {
            var json = JsonConvert.SerializeObject(value);
            PlayerPrefs.SetString(ENTRIES_KEY, json);
        }
    }
}