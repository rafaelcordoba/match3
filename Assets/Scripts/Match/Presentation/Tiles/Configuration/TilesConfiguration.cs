using System.Collections.Generic;
using System.Linq;
using Match.Application.Gameplay.Board;
using UnityEngine;

namespace Match.Presentation.Tiles.Configuration
{
    [CreateAssetMenu(fileName = nameof(TilesConfiguration), menuName = "Match/New " + nameof(TilesConfiguration))]
    public class TilesConfiguration : ScriptableObject, ITilesConfiguration, ITileTypeRepository
    {
        [field: SerializeField] public List<TileGraphicPrefab> TilePrefabs { get; set; }
        [field: SerializeField] public TileView TileViewPrefab { get; set; }
        [field: SerializeField] public int PoolSize { get; set; }
        
        public IEnumerable<TileType> Get() =>
            TilePrefabs.Select(c => c.Type);
    }
}