using Game.Commons.Input.Touch;
using UnityEngine;

namespace Game.Commons.Input.Swipe
{
    public interface ISwipeConditionChecker
    {
        bool Pass(
            TouchInputInfo touchInputInfo, 
            Vector3 startPosition, 
            double startTime);
    }
}