using System;
using System.Collections.Generic;
using UnityEngine;

namespace A
{
    public class ObjectPool<T> where T : new()
    {
        private Stack<T> m_Stack = new Stack<T>();
        private Action<T> m_ActionOnGet;
        private Action<T> m_ActionOnRelease;

        public int countAll { get; private set; }
        public int countActive { get { return countAll - countInactive; } }
        public int countInactive { get { return m_Stack.Count; } }

        public ObjectPool()
        {
        }

        public ObjectPool(Action<T> actionOnGet, Action<T> actionOnRelease)
        {
            m_ActionOnGet = actionOnGet;
            m_ActionOnRelease = actionOnRelease;
        }

        public T Get()
        {
            T element;
            if (m_Stack.Count == 0)
            {
                element = new T();
                countAll++;
            }
            else
            {
                element = m_Stack.Pop();
            }
            if (m_ActionOnGet != null)
                m_ActionOnGet(element);
            return element;
        }

        public void Release(T element)
        {
            if (m_Stack.Count > 0 && m_Stack.Contains(element))
                Debug.LogError($"[Object Pool] Trying to destroy object that is already released to pool.");
            if (m_ActionOnRelease != null)
                m_ActionOnRelease(element);
            m_Stack.Push(element);
        }

        public void Clear()
        {
            m_Stack.Clear();
        }

        public void Dispose()
        {
            m_Stack.Clear();
            m_Stack = null;
            m_ActionOnGet = null;
            m_ActionOnRelease = null;
        }
    }
}