using System;
using Game.Commons.UI;

namespace Match.Popups
{
    public interface IChangeNamePopupView : IPopupView
    {
        event Action<string> SaveButtonClicked;
        void SetName(string playerName);
    }
}