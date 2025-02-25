using Commons.Runtime.Input.Touch;
using UnityEngine;

namespace Commons.Runtime.Input.Swipe
{
    public interface ISwipeConditionChecker
    {
        bool Pass(
            TouchInputInfo touchInputInfo, 
            Vector3 startPosition, 
            double startTime);
    }
}