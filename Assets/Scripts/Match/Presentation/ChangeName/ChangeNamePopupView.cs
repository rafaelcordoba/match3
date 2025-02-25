using System;
using Commons.Runtime.UI;
using Match.Popups.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Match.Presentation.ChangeName
{
    public class ChangeNamePopupView : PopupView, IChangeNamePopupView
    {
        public event Action<string> SaveButtonClicked;
        
        [SerializeField] private TMP_InputField _nameInput;
        [SerializeField] private Button _saveButton;

        public override void Show()
        {
            base.Show();
            _saveButton.onClick.AddListener(SendSaved);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _saveButton.onClick.RemoveAllListeners();
        }

        public void SetName(string playerName)
            => _nameInput.text = playerName;

        private void SendSaved()
            => SaveButtonClicked?.Invoke(_nameInput.text);
    }
}