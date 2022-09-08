using Game.Commons.Input.Swipe;

namespace Match.Core.Board
{
    public interface IBoardFlowController
    {
        void HandleSwipe(SwipeInfo swipeInfo);
        bool FlowInProgress { get; }
    }
}