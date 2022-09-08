using Game.Commons.Input.Touch;
using UnityEngine;

namespace Match.Core.Pausing
{
    public class PauseController : IPauseController
    {
        private readonly ITouchInputController _touchInputController;

        public PauseController(ITouchInputController touchInputController)
            => _touchInputController = touchInputController;

        public void Pause()
        {
            Time.timeScale = 0;
            _touchInputController.Disable();
        }

        public void UnPause()
        {
            Time.timeScale = 1;
            _touchInputController.Enable();
        }
    }
}