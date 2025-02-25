using System.Collections.Generic;

namespace Commons.Runtime.UI.Configuration
{
    public interface IPopupsConfiguration
    {
        List<PopupView> RegisteredPopups { get; }
    }
}