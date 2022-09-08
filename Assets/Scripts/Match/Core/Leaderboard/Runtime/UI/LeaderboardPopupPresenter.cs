using System.Collections.Generic;
using System.Text;
using Game.Commons.UI;
using Match.Core.PlayAgain;
using Match.Popups;

namespace Match.Core.Leaderboard.UI
{
    public class LeaderboardPopupPresenter : IPresenter<ILeaderboardPopupView>, ILeaderboardPopupPresenter
    {
        private const string CONTEXT_SHOW_CLOSE = "showClose";
        private readonly IPopupController _popupController;
        private readonly ILeaderboardController _leaderboardController;
        private readonly IPlayAgainController _playAgainController;
        private ILeaderboardPopupView _view;
        private bool _showCloseButton;

        public LeaderboardPopupPresenter(
            IPopupController popupController, 
            ILeaderboardController leaderboardController,
            IPlayAgainController playAgainController)
        {
            _popupController = popupController;
            _leaderboardController = leaderboardController;
            _playAgainController = playAgainController;
        }

        public void SetContext(IDictionary<string, object> context)
        {
            if (context.ContainsKey(CONTEXT_SHOW_CLOSE) && 
                context[CONTEXT_SHOW_CLOSE] is bool showClose) 
                _showCloseButton = showClose;
            else
                _showCloseButton = false;
        }

        public void SetView(ILeaderboardPopupView view)
        {
            _view = view;
            _view.SetCloseButtonVisibility(_showCloseButton);
            SetLeaderboardText();

            _view.PlayAgainClicked += OnPlayAgainClicked;
            _view.ChangeNameClicked += OnChangeNameClicked;
            _view.CloseButtonClicked += CloseButtonClicked;
            _leaderboardController.PlayerNameChanged += OnPlayerNameChanged;
        }

        public void Dispose()
        {
            _view.PlayAgainClicked -= OnPlayAgainClicked;
            _view.ChangeNameClicked -= OnChangeNameClicked;
            _view.CloseButtonClicked -= CloseButtonClicked;
            _leaderboardController.PlayerNameChanged -= OnPlayerNameChanged;
        }

        private void OnPlayAgainClicked()
        {
            _playAgainController.PlayAgain();
            CloseButtonClicked();
        }

        private void OnChangeNameClicked()
        {
            _popupController.OpenPopup(PopupType.ChangeNamePopup);
        }

        private void CloseButtonClicked()
        {
            _popupController.ClosePopup(PopupType.LeaderboardPopup);
        }

        private void OnPlayerNameChanged(string playerName)
        {
            _view.SetPlayerNameText(playerName);
        }

        private void SetLeaderboardText()
        {
            var playerName = _leaderboardController.GetPlayerName();
            _view.SetPlayerNameText(playerName);

            var stringBuilder = new StringBuilder();
            
            foreach (var entry in _leaderboardController.GetEntries())
                stringBuilder.AppendLine($"{entry.PlayerName} {entry.Points}");

            _view.SetLeaderboardText(stringBuilder.ToString());
        }
    }
}