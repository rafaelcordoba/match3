using System;
using Commons.Runtime.Grid;
using UnityEngine;

namespace Match.Application.Gameplay.Board
{
    [Serializable]
    public class Tile
    {
        [field: SerializeField] public TileType TileType { get; set; }
        [field: SerializeField] public GridPosition GridPosition { get; set; }
        [field: SerializeField] public bool Destroyed { get; set; }
        [field: SerializeField] public bool Refilled { get; set; }
        
        public Tile Clone()
        {
            return new Tile
            {
                TileType = TileType,
                GridPosition = GridPosition,
                Refilled = Refilled
            };
        }

        public override string ToString()
            => $"Type: {TileType} X: {GridPosition.X} Y:{GridPosition.Y}";
    }
}