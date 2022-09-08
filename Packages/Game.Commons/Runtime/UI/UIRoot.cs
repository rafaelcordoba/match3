using UnityEngine;

namespace Game.Commons.UI
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        public Transform Transform => transform;
    }
}