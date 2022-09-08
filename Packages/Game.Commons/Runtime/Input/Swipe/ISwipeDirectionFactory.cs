using UnityEngine;

namespace Game.Commons.Input.Swipe
{
    public interface ISwipeDirectionFactory
    {
        SwipeDirection Get(Vector3 startPosition, Vector3 endPosition);
    }
}