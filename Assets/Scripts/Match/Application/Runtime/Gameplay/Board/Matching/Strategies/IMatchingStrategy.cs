using System.Collections.Generic;

namespace Match.Application.Gameplay.Board.Matching.Strategies
{
    public interface IMatchingStrategy
    {
        IReadOnlyList<Tile> GetMatches(Tile origin);
    }
}