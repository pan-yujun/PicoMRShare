using System.Collections;

namespace A
{
    public static class ArrayListPool
    {
        private static readonly ObjectPool<ArrayList> s_ArrayListPool = new ObjectPool<ArrayList>(null, Clear);

        private static void Clear(ArrayList l)
        {
            l.Clear();
        }

        public static ArrayList Get()
        {
            return s_ArrayListPool.Get();
        }

        public static void Release(ArrayList toRelease)
        {
            s_ArrayListPool.Release(toRelease);
        }
    }
}