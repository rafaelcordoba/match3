using Game.Commons.Input.Swipe;
using UnityEngine;

namespace Match.Core.Board.Switcher
{
    public interface ITileSwitcher
    {
        SwitcherResult TrySwitch(Vector2 worldStartPosition, SwipeDirection swipeDirection);
        void SwitchBack(SwitcherResult switcherResult);
    }
}