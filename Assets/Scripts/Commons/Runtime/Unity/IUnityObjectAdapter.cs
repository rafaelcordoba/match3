using UnityEngine;

namespace Commons.Runtime.Unity
{
    public interface IUnityObjectAdapter
    {
        T Instantiate<T>(
            T original, 
            Transform parent) 
            where T : Object;

        T Instantiate<T>(
            T original, 
            Transform parent, 
            bool worldPositionStays) 
            where T : Object;

        T Instantiate<T>(
            T original,
            Vector3 position,
            Quaternion rotation,
            Transform parent)
            where T : Object;

        void Destroy(Object obj);
    }
}