using UnityEngine;

namespace Commons.Runtime.Input.Swipe
{
    public struct SwipeInfo
    {
        public Vector2 StartWorldPosition { get; set; }
        public Vector2 EndWorldPosition { get; set; }
        public SwipeDirection SwipeDirection { get; set; }
    }
}