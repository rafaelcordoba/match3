using System.Collections.Generic;
using Match.Core.Tiles.UI;
using UnityEngine;

namespace Match.Core.Tiles.Configuration
{
    [CreateAssetMenu(fileName = nameof(TilesConfiguration), menuName = "Match/New " + nameof(TilesConfiguration))]
    public class TilesConfiguration : ScriptableObject, ITilesConfiguration
    {
        [field: SerializeField] public List<TileGraphicPrefab> TilePrefabs { get; set; }
        [field: SerializeField] public TileView TileViewPrefab { get; set; }
        [field: SerializeField] public int PoolSize { get; set; }
    }
}