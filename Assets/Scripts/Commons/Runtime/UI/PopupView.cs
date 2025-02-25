using System;
using UnityEngine;
using UnityEngine.UI;

namespace Commons.Runtime.UI
{
    public abstract class PopupView : MonoBehaviour, IPopupView
    {
        public event Action CloseButtonClicked;
        
        [SerializeField] protected Button _closeButton;
        
        public virtual void Show()
        {
            if (_closeButton != null)
                _closeButton.onClick.AddListener(() => CloseButtonClicked?.Invoke());
            
            gameObject.SetActive(true);
        }

        protected virtual void OnDestroy()
        {
            if (_closeButton != null)
                _closeButton.onClick.RemoveAllListeners();
        }

        public void Destroy()
            => Destroy(gameObject);
    }
}