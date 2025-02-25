using Cysharp.Threading.Tasks;
using Match.Application.Gameplay.Board;

namespace Match.Application.Gameplay
{
    public interface IGameplayManager
    {
        UniTask MoveTilesAsync(Tile origin, Tile target);
        void Stop();
        bool IsRunning { get; }
    }
}