using Match.Application.Gameplay.Board;
using UnityEngine;

namespace Match.Infrastructure.UnityConfigurations
{
    [CreateAssetMenu(fileName = nameof(GridScriptableObject), menuName = "Match/New " + nameof(GridScriptableObject))]
    public class GridScriptableObject : ScriptableObject, IGridConfiguration
    {
        [field: SerializeField] public uint Width { get; set; }
        [field: SerializeField] public uint Height { get; set; }
        [field: SerializeField] public float TileSize { get; set; }
    }
}