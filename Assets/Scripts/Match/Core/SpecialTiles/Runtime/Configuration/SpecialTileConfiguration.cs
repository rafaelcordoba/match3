using System.Collections.Generic;
using Match.Core.Tiles;
using UnityEngine;

namespace Match.Core.SpecialTiles.Runtime.Configuration
{
    [CreateAssetMenu(fileName = nameof(SpecialTileConfiguration), menuName = "Match/New " + nameof(SpecialTileConfiguration))]
    public class SpecialTileConfiguration : ScriptableObject, ISpecialTileConfiguration
    {
        [field: SerializeField] public int TilesDestroyedRequired { get; set; }
        [field: SerializeField] public int HorizontalExplosion { get; set; }
        [field: SerializeField] public int VerticaExplosion { get; set; }
        [field: SerializeField] public int DiagonalExplosion { get; set; }
        [field: SerializeField] public List<TileColor> ColorExplosion { get; set; }
    }
}