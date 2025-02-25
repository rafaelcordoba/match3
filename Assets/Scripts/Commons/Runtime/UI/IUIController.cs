using System.Collections.Generic;

namespace Commons.Runtime.UI
{
    public interface IUIController
    {
        IPopupView Show<TPresenter, TPopupView>()
            where TPopupView : IPopupView;

        IPopupView Show<TPresenter, TPopupView>(IDictionary<string, object> context) 
            where TPopupView : IPopupView;

        void Destroy(IPopupView popupView);
    }
}