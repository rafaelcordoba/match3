using System.Collections.Generic;

namespace Match.Core.Leaderboard.Repository
{
    public interface ILeaderboardDefaultData
    {
        List<LeaderboardEntryEntity> DefaultEntries { get; set; }
    }
}