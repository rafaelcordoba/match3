using Cysharp.Threading.Tasks;

namespace Match.Application.Gameplay.Board
{
    public interface ISwapper
    {
        UniTask SwapAsync(Tile origin, Tile target);
    }
}