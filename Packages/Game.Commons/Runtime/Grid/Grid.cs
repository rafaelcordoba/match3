using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Commons.Grid
{
    public class Grid<TItem> : IGrid<TItem>
    {
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public IEnumerable<TItem> Items => _array.Cast<TItem>();

        private float _cellSize;
        private TItem[,] _array;

        public void Init(
            uint width, 
            uint height, 
            float cellSize)
        {
            Width = width;
            Height = height;
            
            _cellSize = cellSize;
            _array = new TItem[width, height];
            
            for (uint x = 0; x < _array.GetLength(0); x++)
            for (uint y = 0; y < _array.GetLength(1); y++)
                _array[x, y] = default;
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
                _array[gridPosition.X, gridPosition.Y] : 
                default;
        }

        public void SetItem(GridPosition gridPosition, TItem value)
        {
            if (!PositionIsValid(gridPosition)) 
                throw new Exception("SetItem: invalid position x:{x} y:{y}");
                
            _array[gridPosition.X, gridPosition.Y] = value;
        }

        public Vector2 GetWorldPosition(GridPosition gridPosition) 
            => new Vector2(gridPosition.X, gridPosition.Y) * _cellSize;

        public GridPosition GetGridPosition(Vector2 worldPosition)
        {
            var floorToIntX = Mathf.FloorToInt(worldPosition.x / _cellSize);
            var floorToIntY = Mathf.FloorToInt(worldPosition.y / _cellSize);
            return new GridPosition(x: (uint) floorToIntX, y: (uint) floorToIntY);
        }

        private bool PositionIsValid(GridPosition gridPosition) 
            => gridPosition.X < Width && gridPosition.Y < Height;
    }
}