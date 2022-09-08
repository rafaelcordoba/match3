using System.Collections.Generic;
using System.Linq;
using Match.Core.Matching.Configuration;
using Match.Core.Matching.Strategies;
using Match.Core.Tiles;

namespace Match.Core.Matching
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
            {
                var matches = strategy.GetMatches(origin);
                if (matches.Count >= _configuration.RequiredToMatch)
                {
                    tilesToDestroy.AddRange(matches);
                }
            }
            return tilesToDestroy.Distinct().ToList();
        }
    }
}