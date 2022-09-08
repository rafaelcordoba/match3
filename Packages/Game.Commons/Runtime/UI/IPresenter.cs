using System;
using System.Collections.Generic;

namespace Game.Commons.UI
{
    public interface IPresenter<T> : IDisposable where T : IPopupView
    {
        void SetContext(IDictionary<string, object> context);
        void SetView(T view);
    }
}