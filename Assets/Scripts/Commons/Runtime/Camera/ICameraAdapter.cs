using UnityEngine;

namespace Commons.Runtime.Camera
{
    public interface ICameraAdapter
    {
        Vector3 ScreenToWorldPoint(Vector3 position);
        float NearClipPlane { get; }
    }
}