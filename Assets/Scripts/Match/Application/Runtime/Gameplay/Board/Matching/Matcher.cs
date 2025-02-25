using System.Collections.Generic;
using System.Linq;
using Match.Application.Gameplay.Board.Matching.Strategies;

namespace Match.Application.Gameplay.Board.Matching
{
    public class Matcher : IMatcher
    {
        private readonly IEnumerable<IMatchingStrategy> _matchingStrategies;
        private readonly IMatchingConfiguration _configuration;

        public Matcher(
            IEnumerable<IMatchingStrategy> matchingStrategies,
            IMatchingConfiguration configuration)
        {
            _matchingStrategies = matchingStrategies;
            _configuration = configuration;
        }
        
        public IReadOnlyList<Tile> Get(Tile origin)
        {
            var tilesToDestroy = new List<Tile>();
            foreach (var strategy in _matchingStrategies) 
                AddMatchesToDestroy(origin, strategy, tilesToDestroy);
            return tilesToDestroy
                .Distinct()
                .ToList();
        }

        private void AddMatchesToDestroy(Tile origin, IMatchingStrategy strategy, List<Tile> tilesToDestroy)
        {
            var matches = strategy.GetMatches(origin);
            if (matches.Count >= _configuration.RequiredToMatch)
            {
                tilesToDestroy.AddRange(matches);
            }
        }
    }
}