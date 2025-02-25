using System;
using Commons.Runtime.UI;

namespace Match.Popups.Runtime
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