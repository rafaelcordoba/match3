using UnityEngine;

namespace Commons.Runtime.Unity
{
    public class UnityObjectAdapter : IUnityObjectAdapter
    {
        public T Instantiate<T>(
            T original, 
            Transform parent) 
            where T : Object
            => Object.Instantiate(original, parent);

        public T Instantiate<T>(
            T original, 
            Transform parent, 
            bool worldPositionStays) 
            where T : Object
            => Object.Instantiate(original, parent, worldPositionStays);

        public T Instantiate<T>(
            T original,
            Vector3 position,
            Quaternion rotation,
            Transform parent)
            where T : Object
            => Object.Instantiate(original, position, rotation, parent);

        public void Destroy(Object obj)
            => Object.Destroy(obj);
    }
}