using System;

namespace Lncodes.Module.Unity.Helper
{
    [Serializable]
    public struct Boundary<T> where T : IComparable<T>
    {
        public T Min;

        public T Max;

        public Boundary(T min, T max) =>
            (Min, Max) = (min, max);
    }
}
