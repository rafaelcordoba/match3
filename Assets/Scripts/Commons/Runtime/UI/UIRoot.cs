using UnityEngine;

namespace Commons.Runtime.UI
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        public Transform Transform => transform;
    }
}