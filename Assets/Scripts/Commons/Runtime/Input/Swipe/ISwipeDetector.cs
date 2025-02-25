using System;

namespace Commons.Runtime.Input.Swipe
{
    public interface ISwipeDetector
    {
        event Action<SwipeInfo> Swiped;
    }
}