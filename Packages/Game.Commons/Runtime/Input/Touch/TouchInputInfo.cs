using UnityEngine;

namespace Game.Commons.Input.Touch
{
    public struct TouchInputInfo
    {
        public double Time { get; set; }
        public Vector2 ScreenPosition { get; set; }
        public Vector3 WorldPosition { get; set; }
    }
}