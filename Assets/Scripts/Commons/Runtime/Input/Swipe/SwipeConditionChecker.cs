using Commons.Runtime.Input.Touch;
using UnityEngine;

namespace Commons.Runtime.Input.Swipe
{
    public class SwipeConditionChecker : ISwipeConditionChecker
    {
        private const double MIN_DISTANCE = 0.5f;
        private const double MAX_TIME_SECONDS = 3f;
        
        public bool Pass(
            TouchInputInfo touchInputInfo, 
            Vector3 startPosition, 
            double startTime)
        {
            var passDistanceCondition = PassDistanceCondition(touchInputInfo, startPosition);
            var passTimeCondition = PassTimeCondition(touchInputInfo, startTime);
            return passDistanceCondition && passTimeCondition;
        }

        private static bool PassDistanceCondition(
            TouchInputInfo touchInputInfo, 
            Vector3 startPosition)
        {
            var endPosition = touchInputInfo.WorldPosition;
            var distance = Vector3.Distance(startPosition, endPosition);
            return distance > MIN_DISTANCE;
        }

        private static bool PassTimeCondition(
            TouchInputInfo touchInputInfo, 
            double startTime)
        {
            var endTime = touchInputInfo.Time;
            var timePassed = endTime - startTime;
            return timePassed < MAX_TIME_SECONDS;
        }
    }
}