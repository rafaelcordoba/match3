using System.Collections.Generic;

namespace Game.Commons.UI.Configuration
{
    public interface IPopupsConfiguration
    {
        List<PopupView> RegisteredPopups { get; }
    }
}