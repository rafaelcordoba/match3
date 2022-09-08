using System.Collections.Generic;
using Match.Core.Tiles;

namespace Match.Core.Matching.Strategies
{
    public interface IMatchingStrategy
    {
        IReadOnlyList<Tile> GetMatches(Tile origin);
    }
}