using System;
using Commons.Runtime.Input.Swipe;

namespace Match.Application.Gameplay
{
    public interface IPlayerInputListener
    {
        bool Enabled { get; set; }
        event Action<SwipeInfo> Swiped;
    }
}