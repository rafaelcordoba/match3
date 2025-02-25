using System;

namespace Match.Application.Gameplay.Board.Matching
{
    public interface IChainReactionDestroyer
    {
        bool ChainDestroy();
        event Action<int> TilesDestroyed;
    }
}