/****************************************************************************
* ScriptType: 主框架 - 协程 管理类
* 核心功能:   主要用于给一些不能开启协程的脚本开启协程
* 
* 修改人:     袁楠
* 修改时间:   2021/6/21
****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloEngine
{
    public class CoroutineMgr : SingletonMono<CoroutineMgr>
    {
        private HashSet<CoroutineWrapper> currentIterators;
        private List<CoroutineWrapper> iteratorsToAdd;
        private List<CoroutineWrapper> iteratorsToRemove;

        public CoroutineWrapper StartCoroutineWrapper(IEnumerator enumerator)
        {
            var iterator = new CoroutineWrapper(enumerator);
            iteratorsToAdd.Add(iterator);
            return iterator;
        }

        public void StopCoroutineWrapper(CoroutineWrapper coroutineWrapper)
        {
            if (coroutineWrapper != null)
            {
                iteratorsToRemove.Add(coroutineWrapper);
            }
        }        

        IEnumerator UpdateCoroutineWrapper()
        {
            while (true)
            {

                if (iteratorsToAdd.Count > 0)
                {
                    // 添加
                    iteratorsToAdd.ForEach(it => { currentIterators.Add(it); });
                    iteratorsToAdd.Clear();
                }

                if (currentIterators.Count > 0)
                {
                    foreach (var i in currentIterators)
                    {
                        i.Update();
                    }

                    currentIterators.RemoveWhere(i => i.isEnd);
                }

                if (iteratorsToRemove.Count > 0)
                {
                    // 删除
                    iteratorsToRemove.ForEach(it => { currentIterators.Remove(it); });
                    iteratorsToRemove.Clear();
                }
                yield return 1;
            }
        }

        #region  Life
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            currentIterators = new HashSet<CoroutineWrapper>();
            iteratorsToAdd = new List<CoroutineWrapper>();
            iteratorsToRemove = new List<CoroutineWrapper>();

            StartCoroutine(UpdateCoroutineWrapper());
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            StopAllCoroutines();
        }
        #endregion
    }

    public class CoroutineWrapper
    {
        public bool isEnd { get; private set; }
        readonly IEnumerator _enumerator;

        public CoroutineWrapper(IEnumerator enumerator)
        {
            _enumerator = enumerator;
            isEnd = _enumerator == null;
        }

        public void Update()
        {
            isEnd = !MoveNext(_enumerator);
        }

        private bool MoveNext(IEnumerator enumerator)
        {
            //yield return 另一个协程：递归 MoveNext
            var child = enumerator.Current as IEnumerator;
            if (child != null && MoveNext(child))
                return true;

            // 处理 Unity 内置协程：WaitForSeconds LoadAssetAsync
            var asyncOperation = enumerator.Current as AsyncOperation;
            if (asyncOperation != null && !asyncOperation.isDone)
                return true;

            if (enumerator.MoveNext())
                return true;

            return false;
        }
    }
}