using System;
using Commons.Runtime.UI;

namespace Match.Popups.Runtime
{
    public interface IChangeNamePopupView : IPopupView
    {
        event Action<string> SaveButtonClicked;
        void SetName(string playerName);
    }
}