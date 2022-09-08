using TMPro;
using UnityEngine;

namespace Match.Core.Scoring.UI
{
    public class ScoringView : MonoBehaviour, IScoringView
    {
        [SerializeField] private TextMeshProUGUI _pointsText;
        [SerializeField] private TextMeshProUGUI _countdown;

        public void SetPoints(int points)
            => _pointsText.text = $"{points:n0}";

        public void SetCountdown(int countdown)
            => _countdown.text = $"{countdown:n0}";
    }
}