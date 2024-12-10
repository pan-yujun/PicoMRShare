using System.Collections;
using System.Collections.Generic;

namespace GF
{
    public class EditorCoroutine : IEnumerator
    {
        private Stack<IEnumerator> executionStack;

        public EditorCoroutine(IEnumerator iterator)
        {
            executionStack = new Stack<IEnumerator>();
            executionStack.Push(iterator);
        }

        public bool MoveNext()
        {
            IEnumerator i = executionStack.Peek();

            if (i.MoveNext())
            {
                object result = i.Current;
                if (result != null && result is IEnumerator)
                {
                    executionStack.Push((IEnumerator)result);
                }

                return true;
            }
            else
            {
                if (executionStack.Count > 1)
                {
                    executionStack.Pop();
                    return true;
                }
            }

            return false;
        }

        public void Reset()
        {
            throw new System.NotSupportedException("This Operation Is Not Supported.");
        }

        public object Current
        {
            get { return executionStack.Peek().Current; }
        }

        public bool Find(IEnumerator iterator)
        {
            return executionStack.Contains(iterator);
        }
    }
}