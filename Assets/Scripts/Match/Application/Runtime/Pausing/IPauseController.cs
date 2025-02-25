namespace Match.Application.Pausing
{
    public interface IPauseController
    {
        bool IsPaused { get; }
        void Pause();
        void Unpause();
    }
}