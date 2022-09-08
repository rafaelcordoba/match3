using System;

namespace Match.Core.Pausing.UI.Button
{
    public interface IPauseButtonView
    {
        event Action PauseButtonClicked;
    }
}