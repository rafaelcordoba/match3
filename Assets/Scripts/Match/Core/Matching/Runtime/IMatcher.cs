using System.Collections.Generic;
using Match.Core.Tiles;

namespace Match.Core.Matching
{
    public interface IMatcher
    {
        IReadOnlyList<Tile> Get(Tile origin);
    }
}