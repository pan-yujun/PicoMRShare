using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GF
{
    // 这里我们不希望此类通过挂到物体上来使用
    // 因此设计成abstract，只能继承使用
    public abstract class GMono : MonoBehaviour
    {
        #region MsgDispatcher
        // 集成了消息机制

        List<MsgRecord> mMsgRecorder = new List<MsgRecord>();
        private class MsgRecord
        {
            // 由于每次注册消息都会new对象
            // 频繁new会消耗性能，所以使用对象池
            private static Stack<MsgRecord> mMsgRecordPool = new Stack<MsgRecord>();

            // 不让外部创建对象，只由内部分配对象
            private MsgRecord() { }

            public static MsgRecord Allocate(string msgName, Action<object> onReceived)
            {
                MsgRecord msgRecord = mMsgRecordPool.Count > 0 ? mMsgRecordPool.Pop() : new MsgRecord();
                msgRecord.Name = msgName;
                msgRecord.OnMsgReceived = onReceived;

                return msgRecord;
            }

            public void Recycle()
            {
                Name = null;
                OnMsgReceived = null;

                mMsgRecordPool.Push(this);
            }

            public string Name { get; set; }
            public Action<object> OnMsgReceived { get; set; }
        }

        public void RegisterMsg(string msgName, Action<object> onReceived)
        {
            mMsgRecorder.Add(MsgRecord.Allocate(msgName, onReceived));
            MsgDispatcher.Register(msgName, onReceived);
        }

        public void UnRegisterAllMsg(string msgName)
        {
            var selectedMsgRecords = mMsgRecorder.FindAll(msgRecord => msgRecord.Name == msgName);
            selectedMsgRecords.ForEach(msgRecord =>
            {
                MsgDispatcher.UnRegister(msgRecord.Name, msgRecord.OnMsgReceived);
                mMsgRecorder.Remove(msgRecord);
                msgRecord.Recycle();
            });
            selectedMsgRecords.Clear();
        }
        public void UnRegisterMsg(string msgName, Action<object> onReceived)
        {
            var selectedMsgRecords = mMsgRecorder.FindAll(msgRecord => msgRecord.Name == msgName && msgRecord.OnMsgReceived == onReceived);
            selectedMsgRecords.ForEach(msgRecord =>
            {
                MsgDispatcher.UnRegister(msgRecord.Name, msgRecord.OnMsgReceived);
                mMsgRecorder.Remove(msgRecord);
                msgRecord.Recycle();
            });
            selectedMsgRecords.Clear();
        }

        public void SendMsg(string msgName, object data = null)
        {
            MsgDispatcher.Send(msgName, data);
        }

        private void OnDestroy()
        {
            OnBeforeDestroy();

            foreach (MsgRecord msgRecord in mMsgRecorder)
            {
                MsgDispatcher.UnRegister(msgRecord.Name, msgRecord.OnMsgReceived);
                msgRecord.Recycle();
            }

            mMsgRecorder.Clear();
        }

        protected abstract void OnBeforeDestroy();
        #endregion

        #region Transform Simplify
        public void SetPosX(float x)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            // 使用扩展方法实现
            transform.SetPosX(x);
        }

        public void SetPosY(float y)
        {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
            transform.SetPosY(y);
        }
        public void SetPosZ(float z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
            transform.SetPosZ(z);
        }
        #endregion

        #region GameObject Simplify
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ToggleVisible()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
        #endregion

        #region Delay Fuction
        private Coroutine cor;

        public void Delay(float seconds, Action onFinished)
        {
            if (cor != null) StopCoroutine(cor);
            cor = StartCoroutine(DelayCoroutine(seconds, onFinished));
        }

        private IEnumerator DelayCoroutine(float seconds, Action onFinished)
        {
            yield return new WaitForSeconds(seconds);
            if (onFinished != null)
                onFinished();
        }
        #endregion
    }
}