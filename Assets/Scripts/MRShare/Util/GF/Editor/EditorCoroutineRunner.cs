using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace GF
{
    public static class EditorCoroutineRunner
    {
        private static List<EditorCoroutine> editorCoroutineList;
        private static List<IEnumerator> buffer;

        public static IEnumerator StartEditorCoroutine(IEnumerator iterator)
        {
            if (editorCoroutineList == null)
            {
                editorCoroutineList = new List<EditorCoroutine>();
            }
            if (buffer == null)
            {
                buffer = new List<IEnumerator>();
            }
            if (editorCoroutineList.Count == 0)
            {
                EditorApplication.update += Update;
            }

            // add iterator to buffer first
            buffer.Add(iterator);

            return iterator;
        }

        private static bool Find(IEnumerator iterator)
        {
            // If this iterator is already added
            // Then ignore it this time
            foreach (EditorCoroutine editorCoroutine in editorCoroutineList)
            {
                if (editorCoroutine.Find(iterator))
                {
                    return true;
                }
            }

            return false;
        }

        private static void Update()
        {
            // EditorCoroutine execution may append new iterators to buffer
            // Therefore we should run EditorCoroutine first
            editorCoroutineList.RemoveAll
            (
                coroutine => { return coroutine.MoveNext() == false; }
            );

            // If we have iterators in buffer
            if (buffer.Count > 0)
            {
                foreach (IEnumerator iterator in buffer)
                {
                    // If this iterators not exists
                    if (!Find(iterator))
                    {
                        // Added this as new EditorCoroutine
                        editorCoroutineList.Add(new EditorCoroutine(iterator));
                    }
                }

                // Clear buffer
                buffer.Clear();
            }

            // If we have no running EditorCoroutine
            // Stop calling update anymore
            if (editorCoroutineList.Count == 0)
            {
                EditorApplication.update -= Update;
            }
        }     
    }
}