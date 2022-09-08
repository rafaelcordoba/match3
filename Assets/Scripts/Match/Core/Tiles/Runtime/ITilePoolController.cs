using Match.Core.Tiles.UI;

namespace Match.Core.Tiles
{
    public interface ITilePoolController
    {
        void InitializePool(TileType tileType);
        ITileView Get(TileType tileType);
        void Return(ITileView tileView);
    }
}