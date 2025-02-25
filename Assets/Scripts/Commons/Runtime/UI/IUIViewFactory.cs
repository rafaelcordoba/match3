namespace Commons.Runtime.UI
{
    public interface IUIViewFactory
    {
        TView Create<TView>();
    }
}