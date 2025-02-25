using System;
using Commons.Runtime.Input.Touch;
using UnityEngine;

namespace Commons.Runtime.Input.Swipe
{
    public class SwipeDetector : IDisposable, ISwipeDetector
    {
        public event Action<SwipeInfo> Swiped;
        
        private readonly ITouchInputController _inputController;
        private readonly ISwipeConditionChecker _swipeConditionChecker;
        private readonly ISwipeDirectionFactory _swipeDirectionFactory;
        private Vector3 _startPosition;
        private double _startTime;
        private bool _swipeDetectionAllowed;

        public SwipeDetector(ITouchInputController inputController, 
            ISwipeConditionChecker swipeConditionChecker,
            ISwipeDirectionFactory swipeDirectionFactory)
        {
            _inputController = inputController;
            _swipeConditionChecker = swipeConditionChecker;
            _swipeDirectionFactory = swipeDirectionFactory;

            _inputController.TouchStart += OnTouchStart;
            _inputController.TouchMove += OnTouchMove;
        }

        public void Dispose()
        {
            _inputController.TouchStart -= OnTouchStart;
            _inputController.TouchMove += OnTouchMove;
        }

        private void OnTouchStart(TouchInputInfo touchInputInfo)
        {
            _startPosition = touchInputInfo.WorldPosition;
            _startTime = touchInputInfo.Time;
            _swipeDetectionAllowed = true;
        }

        private void OnTouchMove(TouchInputInfo touchInputInfo)
        {
            if (!_swipeDetectionAllowed) 
                return; 
            if (!_swipeConditionChecker.Pass(touchInputInfo, _startPosition, _startTime)) 
                return;

            var swipeDirection = _swipeDirectionFactory.Get(_startPosition, touchInputInfo.WorldPosition);
            var swipeInfo = new SwipeInfo
            {
                StartWorldPosition = _startPosition,
                EndWorldPosition = touchInputInfo.WorldPosition,
                SwipeDirection = swipeDirection
            };
            Swiped?.Invoke(swipeInfo);
            _swipeDetectionAllowed = false;
        }
    }
}