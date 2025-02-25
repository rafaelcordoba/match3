using Match.Application.Gameplay.Board;

namespace Match.Presentation.Tiles
{
    public interface ITilePoolController
    {
        void InitializePool(TileType tileType);
        ITileView Get(TileType tileType);
        void Return(ITileView tileView);
    }
}