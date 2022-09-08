using System;
using Game.Commons.Grid;
using UnityEngine;

namespace Match.Core.Tiles
{
    [Serializable]
    public class Tile
    {
        [field: SerializeField] public TileType TileType { get; set; }
        [field: SerializeField] public GridPosition GridPosition { get; set; }
        [field: SerializeField] public bool Destroyed { get; set; }
        [field: SerializeField] public bool Refilled { get; set; }

        public override string ToString()
            => $"Type: {TileType} X: {GridPosition.X} Y:{GridPosition.Y}";
    }
}