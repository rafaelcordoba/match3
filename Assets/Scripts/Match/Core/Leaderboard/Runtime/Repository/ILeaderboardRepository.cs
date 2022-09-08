using System.Collections.Generic;

namespace Match.Core.Leaderboard.Repository
{
    public interface ILeaderboardRepository
    {
        string GetPlayerName();
        void SetPlayerName(string value);
        IEnumerable<LeaderboardEntryEntity> GetEntries();
        void SetEntries(IEnumerable<LeaderboardEntryEntity> value);
    }
}