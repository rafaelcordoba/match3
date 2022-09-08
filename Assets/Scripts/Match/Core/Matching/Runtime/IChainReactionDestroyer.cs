using System;

namespace Match.Core.Matching
{
    public interface IChainReactionDestroyer
    {
        bool ChainDestroy();
        event Action<int> TilesDestroyed;
    }
}