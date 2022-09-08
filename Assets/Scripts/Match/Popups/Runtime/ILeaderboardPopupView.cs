using System;
using Game.Commons.UI;

namespace Match.Popups
{
    public interface ILeaderboardPopupView : IPopupView
    {
        event Action PlayAgainClicked;
        event Action ChangeNameClicked;
        void SetPlayerNameText(string playerName);
        void SetLeaderboardText(string leaderboard);
        void SetCloseButtonVisibility(bool isVisible);
    }
}