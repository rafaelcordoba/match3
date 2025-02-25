using System;
using Commons.Runtime.UI;
using Match.Popups.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Match.Presentation.Leaderboard
{
    public class LeaderboardPopupView : PopupView, ILeaderboardPopupView
    {
        public event Action PlayAgainClicked;
        public event Action ChangeNameClicked;
        
        [SerializeField] private TextMeshProUGUI _playerName;
        [SerializeField] private TextMeshProUGUI _leaderboard;
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _changeNameButton;

        public override void Show()
        {
            base.Show();
            _playAgainButton.onClick.AddListener(() => { PlayAgainClicked?.Invoke(); });
            _changeNameButton.onClick.AddListener(() => { ChangeNameClicked?.Invoke(); });
        }

        public void SetPlayerNameText(string playerName)
            => _playerName.text = playerName;

        public void SetLeaderboardText(string leaderboard)
            => _leaderboard.text = leaderboard;

        public void SetCloseButtonVisibility(bool isVisible)
            => _closeButton.gameObject.SetActive(isVisible);

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _playAgainButton.onClick.RemoveAllListeners();
            _changeNameButton.onClick.RemoveAllListeners();
        }
    }
}