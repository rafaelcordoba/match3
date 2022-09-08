using System.Collections.Generic;
using UnityEngine;

namespace Game.Commons.UI.Configuration
{
    [CreateAssetMenu(fileName = nameof(PopupsConfiguration), menuName = "Match/New " + nameof(PopupsConfiguration))]
    public class PopupsConfiguration : ScriptableObject, IPopupsConfiguration
    {
        [field: SerializeField] public List<PopupView> RegisteredPopups { get; set; }
    }
}