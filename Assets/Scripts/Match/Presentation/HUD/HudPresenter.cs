using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Match.Application.Gameplay;
using Match.Application.Pausing;
using Match.Popups.Runtime;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Match.Presentation.HUD
{
    public class HudPresenter : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button autoplayButton;
        
        [Inject] private readonly IPauseController _pauseController;
        [Inject] private readonly IPopupController _popupController;
        [Inject] private readonly IAutoplayLogic _autoplayLogic;

        public void Start()
        {
            pauseButton.onClick.AddListener(OnPauseButtonClicked);
            autoplayButton.onClick.AddListener(OnAutoPlayButtonClicked);
        }

        public void OnDestroy()
        {
            pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
            autoplayButton.onClick.RemoveListener(OnAutoPlayButtonClicked);
        }

        private void OnPauseButtonClicked()
        {
            _pauseController.Pause();
            var context = new Dictionary<string, object> { { "showClose", true } };
            _popupController.OpenPopup(PopupType.LeaderboardPopup, context);
        }
        
        private void OnAutoPlayButtonClicked()
        {
            _autoplayLogic.PlayOneMove().Forget();
        }
    }
}