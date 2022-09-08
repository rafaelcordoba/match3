using System;

namespace Game.Commons.Input.Touch
{
    public interface ITouchInputController
    {
        event Action<TouchInputInfo> TouchStart;
        event Action<TouchInputInfo> TouchMove;
        event Action<TouchInputInfo> TouchEnd;
        void Enable();
        void Disable();
    }
}