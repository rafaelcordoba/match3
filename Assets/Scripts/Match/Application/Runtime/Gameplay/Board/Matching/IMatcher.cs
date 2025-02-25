using System.Collections.Generic;

namespace Match.Application.Gameplay.Board.Matching
{
    public interface IMatcher
    {
        IReadOnlyList<Tile> Get(Tile origin);
    }
}