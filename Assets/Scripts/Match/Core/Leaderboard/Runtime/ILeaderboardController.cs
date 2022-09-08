using System;
using System.Collections.Generic;
using Match.Core.Leaderboard.Repository;

namespace Match.Core.Leaderboard
{
    public interface ILeaderboardController
    {
        void SetPlayerName(string playerName);
        IEnumerable<LeaderboardEntry> GetEntries();
        string GetPlayerName();
        event Action<string> PlayerNameChanged;
        void SetPoints(int points);
    }
}