using UnityEngine;

namespace Commons.Runtime.Camera
{
    public class CameraAdapter : ICameraAdapter
    {
        private readonly UnityEngine.Camera _camera;
        public CameraAdapter(UnityEngine.Camera camera) => _camera = camera;
        public Vector3 ScreenToWorldPoint(Vector3 position) => _camera.ScreenToWorldPoint(position);
        public float NearClipPlane => _camera.nearClipPlane;
    }
}