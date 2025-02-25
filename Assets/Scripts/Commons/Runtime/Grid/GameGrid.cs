using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Commons.Runtime.Grid
{
    public class GameGrid<TItem> : IGrid<TItem>
    {
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public float CellSize { get; private set; }
        public TItem[,] ItemsArray { get; private set; }
        public IEnumerable<TItem> Items => ItemsArray.Cast<TItem>();

        public void Init(
            uint width, 
            uint height, 
            float cellSize)
        {
            Width = width;
            Height = height;
            CellSize = cellSize;
            
            ItemsArray = new TItem[width, height];
            
            for (uint x = 0; x < ItemsArray.GetLength(0); x++)
            for (uint y = 0; y < ItemsArray.GetLength(1); y++)
                ItemsArray[x, y] = default;
        }

        public TItem GetItem(Vector2 worldPosition)
        {
            var gridPosition = GetGridPosition(worldPosition);
            return GetItem(gridPosition);
        }

        public TItem GetItem(GridPosition gridPosition)
        {
            var positionIsValid = PositionIsValid(gridPosition);
            return positionIsValid ? 
                ItemsArray[gridPosition.X, gridPosition.Y] : 
                default;
        }

        public void SetItem(GridPosition gridPosition, TItem value)
        {
            if (!PositionIsValid(gridPosition)) 
                throw new Exception("SetItem: invalid position x:{x} y:{y}");
                
            ItemsArray[gridPosition.X, gridPosition.Y] = value;
        }

        public Vector2 GetWorldPosition(GridPosition gridPosition) 
            => new Vector2(gridPosition.X, gridPosition.Y) * CellSize;

        public GridPosition GetGridPosition(Vector2 worldPosition)
        {
            var floorToIntX = Mathf.FloorToInt(worldPosition.x / CellSize);
            var floorToIntY = Mathf.FloorToInt(worldPosition.y / CellSize);
            return new GridPosition(x: (uint) floorToIntX, y: (uint) floorToIntY);
        }

        private bool PositionIsValid(GridPosition gridPosition) 
            => gridPosition.X < Width && gridPosition.Y < Height;
    }
}