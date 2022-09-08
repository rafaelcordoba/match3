using System;
using UnityEngine;

namespace Match.Core.Pausing.UI.Button
{
    public class PauseButtonView : MonoBehaviour, IPauseButtonView
    {
        public event Action PauseButtonClicked;
        
        public void Pause()
            => PauseButtonClicked?.Invoke();
    }
}