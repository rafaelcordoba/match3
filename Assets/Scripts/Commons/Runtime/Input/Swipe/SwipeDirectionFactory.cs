using UnityEngine;

namespace Commons.Runtime.Input.Swipe
{
    public class SwipeDirectionFactory : ISwipeDirectionFactory
    {
        private const double DIRECTION_THRESHOLD = 0.9f;
        
        public SwipeDirection Get(Vector3 startPosition, Vector3 endPosition)
        {
            var direction = endPosition - startPosition;
            var normalizedDirection2D = new Vector2(direction.x, direction.y).normalized;
            
            if (Vector2.Dot(Vector2.up, normalizedDirection2D) > DIRECTION_THRESHOLD)
                return SwipeDirection.Up;
            
            if (Vector2.Dot(Vector2.down, normalizedDirection2D) > DIRECTION_THRESHOLD)
                return SwipeDirection.Down;
            
            if (Vector2.Dot(Vector2.left, normalizedDirection2D) > DIRECTION_THRESHOLD)
                return SwipeDirection.Left;
            
            if (Vector2.Dot(Vector2.right, normalizedDirection2D) > DIRECTION_THRESHOLD)
                return SwipeDirection.Right;

            return SwipeDirection.None;
        }
    }
}