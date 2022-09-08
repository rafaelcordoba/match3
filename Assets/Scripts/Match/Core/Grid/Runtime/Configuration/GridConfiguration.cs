using UnityEngine;

namespace Match.Core.Grid.Configuration
{
    [CreateAssetMenu(fileName = nameof(GridConfiguration), menuName = "Match/New " + nameof(GridConfiguration))]
    public class GridConfiguration : ScriptableObject, IGridConfiguration
    {
        [field: SerializeField] public uint Width { get; set; }
        [field: SerializeField] public uint Height { get; set; }
        [field: SerializeField] public float TileSize { get; set; }
    }
}