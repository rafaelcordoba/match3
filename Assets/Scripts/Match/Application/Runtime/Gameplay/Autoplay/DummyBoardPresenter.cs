using Cysharp.Threading.Tasks;

namespace Match.Application.Gameplay.Autoplay
{
    public class DummyBoardPresenter : IBoardPresenter
    {
        public void CreateTiles()
        {
        }

        public void Refill()
        {
        }

        public void ClearBoard()
        {
        }

        public UniTask MoveTilesAsync()
        {
            return UniTask.CompletedTask;;
        }

        public UniTask DestroyTilesAsync()
        {
            return UniTask.CompletedTask;;
        }
    }
}