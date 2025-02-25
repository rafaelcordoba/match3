using System.Collections.Generic;

namespace Commons.Runtime.System.Collections.Generic
{
    public class CustomStack<T1, T2> 
    {
        private readonly Dictionary<T1, Stack<T2>> _poolMap = new();

        public void Push(T1 key, T2 value)
        {
            var pool = GetOrCreatePool(key);
            pool.Push(value);
        }

        public T2 Pop(T1 key)
        {
            var pool = GetOrCreatePool(key);
            return pool.Pop();
        }

        public int Count(T1 key)
        {
            var pool = GetOrCreatePool(key);
            return pool.Count;
        }

        private Stack<T2> GetOrCreatePool(T1 tileType)
        {
            if (!_poolMap.ContainsKey(tileType))
                _poolMap[tileType] = new Stack<T2>();
            return _poolMap[tileType];
        }
    }
}