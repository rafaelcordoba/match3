using System.Collections.Generic;
using UnityEngine;

namespace Match.Core.SpecialTiles.Runtime.Configuration
{
    [CreateAssetMenu(fileName = nameof(SpecialTileConfiguration), menuName = "Match/New " + nameof(SpecialTileConfiguration))]
    public class SpecialTilesConfiguration : ScriptableObject, ISpecialTilesConfiguration
    {
        [field: SerializeField] public List<SpecialTileConfiguration> Configurations { get; set; }
    }
}