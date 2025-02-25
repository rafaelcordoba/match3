using System;

namespace Commons.Runtime.UI
{
    public interface IPopupView
    {
        event Action CloseButtonClicked;
        void Show();
        void Destroy();
    }
}