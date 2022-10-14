
using System;
using Match.Core.SpecialTiles.Runtime.Configuration;
using Match.Core.Tiles;
using UnityEngine;

namespace Match.Core.SpecialTiles.Runtime
{
    [Serializable]
    public class SpecialTile : Tile
    {
        [field: SerializeField] public ISpecialTileConfiguration Configuration { get; set; }
    }
}