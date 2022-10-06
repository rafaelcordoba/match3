using UnityEngine;

namespace Match.Core.Tiles.UI
{
    public interface ITileViewFactory
    {
        ITileView Create(TileColor tileColor, Transform parent);
    }
}