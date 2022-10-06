using Match.Core.Tiles.UI;

namespace Match.Core.Tiles
{
    public interface ITilePoolController
    {
        void InitializePool(TileColor tileColor);
        ITileView Get(TileColor tileColor);
        void Return(ITileView tileView);
    }
}