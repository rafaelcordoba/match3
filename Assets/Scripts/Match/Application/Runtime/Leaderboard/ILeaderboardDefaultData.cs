using System.Collections.Generic;

namespace Match.Application.Leaderboard
{
    public interface ILeaderboardDefaultData
    {
        List<LeaderboardEntryEntity> DefaultEntries { get; set; }
    }
}