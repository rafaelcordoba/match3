using System;

namespace Game.Commons.UI
{
    public interface IPopupView
    {
        event Action CloseButtonClicked;
        void Show();
        void Destroy();
    }
}