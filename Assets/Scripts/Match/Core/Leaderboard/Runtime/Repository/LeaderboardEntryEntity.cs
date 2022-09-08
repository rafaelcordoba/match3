using System;

namespace Match.Core.Leaderboard.Repository
{
    [Serializable]
    public class LeaderboardEntryEntity
    {
        public string PlayerName;
        public int Points;
    }
}