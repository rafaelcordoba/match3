using System;
using System.Collections.Generic;

namespace Match.Application.Leaderboard
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