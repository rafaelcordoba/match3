using System.Collections.Generic;
using Commons.Runtime.UI;
using Match.Application.Leaderboard;
using Match.Popups.Runtime;

namespace Match.Presentation.ChangeName
{
    public class ChangeNamePopupPresenter : IPresenter<IChangeNamePopupView>, IChangeNamePopupPresenter
    {
        private readonly IPopupController _popupController;
        private readonly ILeaderboardController _leaderboardController;
        private IChangeNamePopupView _view;

        public ChangeNamePopupPresenter(
            IPopupController popupController, 
            ILeaderboardController leaderboardController)
        {
            _popupController = popupController;
            _leaderboardController = leaderboardController;
        }
        
        public void SetContext(IDictionary<string, object> context) { }

        public void SetView(IChangeNamePopupView view)
        {
            _view = view;
            var playerName = _leaderboardController.GetPlayerName();
            _view.SetName(playerName);
            
            _view.SaveButtonClicked += OnSaveButtonClicked;
        }

        public void Dispose()
            => _view.SaveButtonClicked -= OnSaveButtonClicked;

        private void OnSaveButtonClicked(string input)
        {
            if (string.IsNullOrEmpty(input))
                return;
            
            _leaderboardController.SetPlayerName(input);
            _popupController.ClosePopup(PopupType.ChangeNamePopup);
        }
    }
}