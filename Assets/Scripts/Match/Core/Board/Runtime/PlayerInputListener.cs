using System;
using Game.Commons.Input.Swipe;
using VContainer.Unity;

namespace Match.Core.Board
{
    public class PlayerInputListener : IStartable, IDisposable
    {
        private readonly ISwipeDetector _swipeDetector;
        private readonly IBoardFlowController _boardFlowController;

        public PlayerInputListener(ISwipeDetector swipeDetector, IBoardFlowController boardFlowController)
        {
            _swipeDetector = swipeDetector;
            _boardFlowController = boardFlowController;
        }

        public void Start()
            => _swipeDetector.Swiped += OnSwipe;

        public void Dispose()
            => _swipeDetector.Swiped -= OnSwipe;

        private void OnSwipe(SwipeInfo swipeInfo)
            => _boardFlowController.HandleSwipe(swipeInfo);
    }
}