using System;
using System.Collections.Generic;
using System.Linq;
using Match.Core.Leaderboard.Repository;

namespace Match.Core.Leaderboard
{
    public class LeaderboardController : ILeaderboardController
    {
        public event Action<string> PlayerNameChanged;
        
        private readonly ILeaderboardRepository _repository;

        public LeaderboardController(ILeaderboardRepository repository)
            => _repository = repository;

        public string GetPlayerName()
            => _repository.GetPlayerName();

        public void SetPlayerName(string playerName)
        {
            _repository.SetPlayerName(playerName);
            PlayerNameChanged?.Invoke(playerName);
        }

        public void SetPoints(int points)
        {
            var playerName = GetPlayerName();
            var leaderboardEntries = GetEntries().Select(ConvertToEntity).ToList();
            var playerEntry = leaderboardEntries.FirstOrDefault(entry => entry.PlayerName == playerName);
            if (playerEntry == null)
            {
                playerEntry = new LeaderboardEntryEntity
                {
                    PlayerName = playerName,
                    Points = points
                };
                leaderboardEntries.Add(playerEntry);
            }

            if (points > playerEntry.Points)
                playerEntry.Points = points;

            _repository.SetEntries(leaderboardEntries);
        }

        public IEnumerable<LeaderboardEntry> GetEntries()
            => _repository.GetEntries() == null ? 
                Array.Empty<LeaderboardEntry>() : 
                _repository.GetEntries()
                    .Select(ConvertToModel)
                    .OrderByDescending(entry => entry.Points);

        private static LeaderboardEntryEntity ConvertToEntity(LeaderboardEntry entry)
            => new()
            {
                PlayerName = entry.PlayerName,
                Points = entry.Points
            };

        private static LeaderboardEntry ConvertToModel(LeaderboardEntryEntity entity)
            => new()
            {
                PlayerName = entity.PlayerName,
                Points = entity.Points
            };
    }
}