using Game.Commons.Grid;
using UnityEngine;

namespace Match.Core.Tiles.UI
{
    public interface ITileView
    {
        Tile Tile { get; set; }
        ITilePoolController PoolController { get; set; }
        void SetActive(bool isActive);
        void SetLocalPosition(GridPosition gridPosition);
        void SetParent(Transform parent);
        void SetState(TileViewState state);
        void SetTileSize(float tileSize);
    }
}