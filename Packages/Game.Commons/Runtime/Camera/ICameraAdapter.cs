using UnityEngine;

namespace Game.Commons.Camera
{
    public interface ICameraAdapter
    {
        Vector3 ScreenToWorldPoint(Vector3 position);
        float NearClipPlane { get; }
    }
}