using System;
using System.Collections.Generic;

namespace Match.Popups.Runtime
{
    public interface IPopupController
    {
        void OpenPopup(PopupType popupType);
        void ClosePopup(PopupType popupType);
        event Action<PopupType> PopupClosed;
        void OpenPopup(PopupType popupType, IDictionary<string, object> context);
    }
}