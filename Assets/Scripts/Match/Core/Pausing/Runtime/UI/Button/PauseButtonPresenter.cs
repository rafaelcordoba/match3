using System;
using System.Collections.Generic;
using Match.Popups;
using VContainer.Unity;

namespace Match.Core.Pausing.UI.Button
{
    public class PauseButtonPresenter : IStartable, IDisposable
    {
        private readonly IPauseButtonView _view;
        private readonly IPauseController _pauseController;
        private readonly IPopupController _popupController;

        public PauseButtonPresenter(
            IPauseButtonView view, 
            IPauseController pauseController,
            IPopupController popupController)
        {
            _view = view;
            _pauseController = pauseController;
            _popupController = popupController;
        }

        public void Start()
            => _view.PauseButtonClicked += OnPauseButtonClicked;

        public void Dispose()
            => _view.PauseButtonClicked -= OnPauseButtonClicked;

        private void OnPauseButtonClicked()
        {
            _pauseController.Pause();
            var context = new Dictionary<string, object>
            {
                { "showClose", true }
            };
            _popupController.OpenPopup(PopupType.LeaderboardPopup, context);
            _popupController.PopupClosed += _ => _pauseController.UnPause();
        }
    }
}