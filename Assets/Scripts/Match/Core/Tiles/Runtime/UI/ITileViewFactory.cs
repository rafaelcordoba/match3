using UnityEngine;

namespace Match.Core.Tiles.UI
{
    public interface ITileViewFactory
    {
        ITileView Create(TileType tileType, Transform parent);
    }
}