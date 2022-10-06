using Match.Core.Tiles.UI;

namespace Match.Core.Tiles
{
    public interface ITileGraphicsProvider
    {
        GraphicView GetGraphicPrefab(TileColor tileColor);
        TileView GetTileViewPrefab();
    }
}