namespace Game.Commons.UI
{
    public interface IUIViewFactory
    {
        TView Create<TView>();
    }
}