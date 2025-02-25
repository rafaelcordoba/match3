using Match.Application.Gameplay.Board;

namespace Match.Presentation.Tiles
{
    public interface ITileGraphicsProvider
    {
        GraphicView GetGraphicPrefab(TileType tileType);
        TileView GetTileViewPrefab();
    }
}