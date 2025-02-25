using System;
using System.Collections.Generic;

namespace Commons.Runtime.UI
{
    public interface IPresenter<T> : IDisposable where T : IPopupView
    {
        void SetContext(IDictionary<string, object> context);
        void SetView(T view);
    }
}