using System.Linq;
using Game.Commons.UI.Configuration;
using Game.Commons.Unity;
using UnityEngine;

namespace Game.Commons.UI
{
    public class UIViewFactory : IUIViewFactory
    {
        private readonly IUnityObjectAdapter _objectAdapter;
        private readonly Transform _rootParent;
        private readonly IPopupsConfiguration _configuration;

        public UIViewFactory(
            IUIRoot rootParent, 
            IPopupsConfiguration configuration, 
            IUnityObjectAdapter objectAdapter)
        {
            _configuration = configuration;
            _objectAdapter = objectAdapter;
            _rootParent = rootParent.Transform;
        }

        public TPopupView Create<TPopupView>()
        {
            var prefab = _configuration.RegisteredPopups
                .First(popup => popup is TPopupView);
            var popupView = _objectAdapter.Instantiate(prefab, _rootParent);
            popupView.gameObject.SetActive(false);
            var component = popupView.GetComponent<TPopupView>();
            return component;
        }
    }
}