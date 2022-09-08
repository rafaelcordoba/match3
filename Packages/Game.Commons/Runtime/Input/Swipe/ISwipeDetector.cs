using System;

namespace Game.Commons.Input.Swipe
{
    public interface ISwipeDetector
    {
        event Action<SwipeInfo> Swiped;
    }
}