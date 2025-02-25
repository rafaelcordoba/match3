using System;
using System.Collections.Generic;
using Commons.Runtime.UI;

namespace Match.Popups.Runtime
{
    public class PopupController : IPopupController
    {
        public event Action<PopupType> PopupClosed;
        
        private readonly IUIController _uiController;
        private readonly Dictionary<PopupType, IPopupView> _openedPopups = new();

        public PopupController(IUIController uiController)
            => _uiController = uiController;

        public void OpenPopup(PopupType popupType, IDictionary<string, object> context)
        {
            _openedPopups[popupType] = popupType switch
            {
                // TODO: this needs to be refactored in a data-driven way (Presenter Attribute with reference to View)
                PopupType.LeaderboardPopup => _uiController.Show<ILeaderboardPopupPresenter, ILeaderboardPopupView>(context),
                PopupType.ChangeNamePopup => _uiController.Show<IChangeNamePopupPresenter, IChangeNamePopupView>(context),
                _ => throw new ArgumentOutOfRangeException(nameof(popupType), popupType, null)
            };
        }
        
        public void OpenPopup(PopupType popupType)
            => OpenPopup(popupType, new Dictionary<string, object>());

        public void ClosePopup(PopupType popupType)
        {
            var view = _openedPopups[popupType];
            _uiController.Destroy(view);
            PopupClosed?.Invoke(popupType);
        }
    }
}