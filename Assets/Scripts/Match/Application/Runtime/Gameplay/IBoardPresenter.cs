using Cysharp.Threading.Tasks;

namespace Match.Application.Gameplay
{
    public interface IBoardPresenter
    {
        void CreateTiles();
        void Refill();
        void ClearBoard();
        UniTask MoveTilesAsync();
        UniTask DestroyTilesAsync();
    }
}