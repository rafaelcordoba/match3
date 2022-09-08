using Match.Core.Tiles.UI;

namespace Match.Core.Tiles
{
    public interface ITileGraphicsProvider
    {
        GraphicView GetGraphicPrefab(TileType tileType);
        TileView GetTileViewPrefab();
    }
}