using System;

namespace Match.Core.PlayAgain
{
    public interface IPlayAgainController
    {
        void PlayAgain();
        event Action PlayAgainRequested;
    }
}