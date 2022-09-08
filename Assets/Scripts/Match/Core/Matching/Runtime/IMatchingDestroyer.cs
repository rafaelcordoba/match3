using System;
using Match.Core.Tiles;

namespace Match.Core.Matching
{
    public interface IMatchingDestroyer
    {
        int Destroy(Tile origin);
        event Action<int> TilesDestroyed;
    }
}