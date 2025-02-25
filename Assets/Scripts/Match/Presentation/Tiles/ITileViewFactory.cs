using Match.Application.Gameplay.Board;
using UnityEngine;

namespace Match.Presentation.Tiles
{
    public interface ITileViewFactory
    {
        ITileView Create(TileType tileType, Transform parent);
    }
}