using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GF
{
    public static class MsgDispatcher
    {
        private static Dictionary<string, Action<object>> mRegisterMsgs = new Dictionary<string, Action<object>>();

        public static void Register(string msgName, Action<object> OnReceived)
        {
            if (!mRegisterMsgs.ContainsKey(msgName))
            {
                // 下划线是省略号，接受object参数
                mRegisterMsgs.Add(msgName, _ => { });
            }
            mRegisterMsgs[msgName] += OnReceived;
        }

        public static void UnRegister(string msgName, Action<object> OnReceived)
        {
            if (mRegisterMsgs.ContainsKey(msgName))
            {
                mRegisterMsgs[msgName] -= OnReceived;
            }
        }

        public static void Send(string msgName, object data)
        {
            if (mRegisterMsgs.ContainsKey(msgName))
            {
                mRegisterMsgs[msgName](data);
            }
        }

    }  
}

