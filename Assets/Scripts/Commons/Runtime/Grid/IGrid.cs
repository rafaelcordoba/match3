using System.Collections.Generic;
using UnityEngine;

namespace Commons.Runtime.Grid
{
    public interface IGrid<TItem>
    {
        uint Width { get; }
        uint Height { get; }
        IEnumerable<TItem> Items { get; }
        float CellSize { get; }
        TItem[,] ItemsArray { get; }

        void Init(
            uint width, 
            uint height, 
            float cellSize);

        TItem GetItem(GridPosition gridPosition);

        TItem GetItem(Vector2 worldPosition);

        void SetItem(GridPosition gridPosition, TItem value);

        Vector2 GetWorldPosition(GridPosition gridPosition);

        GridPosition GetGridPosition(Vector2 worldPosition);
    }
}