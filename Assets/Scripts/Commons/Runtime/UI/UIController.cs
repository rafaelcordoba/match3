using System.Collections.Generic;
using Commons.Runtime.Unity;
using UnityEngine;
using VContainer;

namespace Commons.Runtime.UI
{
    public class UIController : IUIController
    {
        private readonly IObjectResolver _objectResolver;
        private readonly IUIViewFactory _viewFactory;
        private readonly IUnityObjectAdapter _objectAdapter;
        private readonly List<IPopupView> _activePopups = new();

        public UIController(
            IObjectResolver objectResolver, 
            IUIViewFactory viewFactory)
        {
            _objectResolver = objectResolver;
            _viewFactory = viewFactory;
        }

        public IPopupView Show<TPresenter, TPopupView>()
            where TPopupView : IPopupView 
            => Show<TPresenter, TPopupView>(new Dictionary<string, object>());

        public IPopupView Show<TPresenter, TPopupView>(IDictionary<string, object> context) 
            where TPopupView : IPopupView 
        {
            var presenter = (IPresenter<TPopupView>) _objectResolver.Resolve<TPresenter>();
            var view = _viewFactory.Create<TPopupView>();
            presenter.SetContext(context);
            presenter.SetView(view);
            _activePopups.Add(view);
            view.Show();
            return view;
        }

        public void Destroy(IPopupView popupView)
        {
            if (!ValidateCanPop())
                return;
            
            _activePopups.Remove(popupView);
            popupView.Destroy();
        }

        private bool ValidateCanPop()
        {
            if (_activePopups.Count > 0)
                return true;

            LogError("Cannot destroy because stack is empty");
            return false;
        }

        private static void LogError(string message)
            => Debug.LogError($"{nameof(UIViewFactory)}: {message}");
    }
}