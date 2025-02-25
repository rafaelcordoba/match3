using UnityEngine;

namespace Match.Application.Pausing
{
    public class PauseController : IPauseController
    {
        public bool IsPaused { get; private set; }

        public void Pause()
        {
            Time.timeScale = 0;
            IsPaused = true;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
            IsPaused = false;
        }
    }
}