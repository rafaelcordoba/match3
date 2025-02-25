using System;
using Cysharp.Threading.Tasks;

namespace Match.Application.Gameplay.Board.Matching
{
    public interface IMatchingDestroyer
    {
        UniTask<bool> TryDestroy(Tile[] tiles);
        UniTask<bool> TryDestroy(Tile tile);
        event Action<int> TilesDestroyed;
    }
}