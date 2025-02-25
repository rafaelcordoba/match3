using System;

namespace Commons.Runtime.Grid
{
    [Serializable]
    public struct GridPosition
    {
        public uint X { get; }

        public uint Y { get; }

        public GridPosition(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
            => $"GridPosition: X:{X} Y:{Y}";
    }
}