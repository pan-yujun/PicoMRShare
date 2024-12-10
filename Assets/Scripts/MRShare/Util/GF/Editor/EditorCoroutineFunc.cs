using System;
using System.Collections;
using UnityEngine;

namespace GF
{
    public class EditorCoroutineFunc
    {
        public static IEnumerator WaitIE(Action action, float waitForSeconds = 0)
        {
            float time = 0;

            while (time < waitForSeconds * 100)
            {
                time += Time.deltaTime;
                yield return 1;
            }


            action?.Invoke();
        }
    }
}