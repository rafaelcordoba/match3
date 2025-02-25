using System;
using Commons.Runtime.Input.Swipe;
using Match.Application.Pausing;
using VContainer.Unity;

namespace Match.Application.Gameplay
{
    public class PlayerInputListener : IStartable, IDisposable, IPlayerInputListener
    {
        private readonly IPauseController _pauseController;
        private readonly ISwipeDetector _swipeDetector;
        
        public bool Enabled { get; set; } = true;
        public event Action<SwipeInfo> Swiped;

        public PlayerInputListener(ISwipeDetector swipeDetector, IPauseController pauseController)
        {
            _swipeDetector = swipeDetector;
            _pauseController = pauseController;
        }

        public void Start()
            => _swipeDetector.Swiped += OnSwipe;

        public void Dispose()
            => _swipeDetector.Swiped -= OnSwipe;

        private void OnSwipe(SwipeInfo swipeInfo)
        {
            if (_pauseController.IsPaused || !Enabled)
                return;
            
            Swiped?.Invoke(swipeInfo);
        }
    }
}