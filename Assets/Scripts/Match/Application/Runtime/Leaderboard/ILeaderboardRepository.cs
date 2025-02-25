using System.Collections.Generic;

namespace Match.Application.Leaderboard
{
    public interface ILeaderboardRepository
    {
        string GetPlayerName();
        void SetPlayerName(string value);
        IEnumerable<LeaderboardEntryEntity> GetEntries();
        void SetEntries(IEnumerable<LeaderboardEntryEntity> value);
    }
}