using System;
using Game.Commons.Grid;
using UnityEngine;

namespace Match.Core.Tiles
{
    [Serializable]
    public class Tile
    {
        [field: SerializeField] public TileColor TileColor { get; set; }
        [field: SerializeField] public GridPosition GridPosition { get; set; }
        [field: SerializeField] public bool Destroyed { get; set; }
        [field: SerializeField] public bool Refilled { get; set; }

        public override string ToString()
            => $"Type: {TileColor} X: {GridPosition.X} Y:{GridPosition.Y}";
    }
}