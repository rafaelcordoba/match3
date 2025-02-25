using System.Collections.Generic;
using UnityEngine;

namespace Commons.Runtime.UI.Configuration
{
    [CreateAssetMenu(fileName = nameof(PopupsConfiguration), menuName = "Match/New " + nameof(PopupsConfiguration))]
    public class PopupsConfiguration : ScriptableObject, IPopupsConfiguration
    {
        [field: SerializeField] public List<PopupView> RegisteredPopups { get; set; }
    }
}