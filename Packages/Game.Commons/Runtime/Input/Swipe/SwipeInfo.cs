using UnityEngine;

namespace Game.Commons.Input.Swipe
{
    public struct SwipeInfo
    {
        public Vector2 StartWorldPosition { get; set; }
        public Vector2 EndWorldPosition { get; set; }
        public SwipeDirection SwipeDirection { get; set; }
    }
}