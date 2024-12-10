/****************************************************************************
* ScriptType: 主框架工具 - ArraySortUtil
* 核心功能:   Unity Array 排序工具
* 
* 修改人:     袁楠
* 修改时间:   2021/7/1
****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace HoloEngine
{
    // 排序帮助类
    public static class ArraySortUtil
    {
        // 条件委托对象,通过 a, b对象和自定义的算法进行比较
        public delegate bool Condition<T>(T a, T b);

        /// <summary>
        /// 冒泡排序 condition 用于排序的自定义判断
        /// </summary>
        public static void BubbleSort<T>(ref T[] array, Condition<T> condition, bool inversion = false)
        {
            if (condition != null)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (condition(array[j], array[j + 1]) == !inversion)
                        {
                            T temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 冒泡排序 condition 用于排序的自定义判断
        /// </summary>
        public static void BubbleSort<T>(ref List<T> list, Condition<T> condition, bool inversion = false)
        {
            T[] array = ListToArray(list);
            BubbleSort(ref array, condition, inversion);
            list = ArrayToList(array);
        }

        /// <summary>
        /// 快速排序 condition 用于排序的自定义判断
        /// </summary>
        public static void QuickSort<T>(ref T[] array, Condition<T> condition, bool inversion = false)
        {
            if (condition != null)
            {
                QuickSortFunction(array, 0, array.Length - 1, condition, inversion);
            }
        }

        /// <summary>
        /// 快速排序 condition 用于排序的自定义判断
        /// </summary>
        public static void QuickSort<T>(ref List<T> list, Condition<T> condition, bool inversion = false)
        {
            T[] array = ListToArray(list);
            QuickSort(ref array, condition, inversion);
            list = ArrayToList(array);
        }

        /// <summary>
        /// List 转 Array
        /// </summary>
        public static T[] ListToArray<T>(List<T> list)
        {
            if (list == null) return null;
            T[] array = new T[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                array[i] = list[i];
            }
            return array;
        }

        /// <summary>
        /// Array 转 List
        /// </summary>
        public static List<T> ArrayToList<T>(T[] array)
        {
            if (array == null) return null;
            List<T> list = new List<T>();

            list.AddRange(array);
            
            return list;
        }

        // ---------------------  这里是快速排序的实现  ---------------------
        private static void QuickSortFunction<T>(T[] array, int low, int height, Condition<T> condition, bool inversion = false)
        {
            try
            {
                int sortIndex = 0;
                if (low < height)
                {
                    sortIndex = QuickSortPartiton(array, low, height, condition, inversion);
                    QuickSortFunction(array, low, sortIndex, condition, inversion);
                    QuickSortFunction(array, sortIndex + 1, height, condition, inversion);
                }

            }
            catch (Exception e) { Debug.Log($"[ArraySortUtil] 调用快速排序的时候出错了： {e}"); }
        }

        private static int QuickSortPartiton<T>(T[] array, int low, int height, Condition<T> condition, bool inversion = false)
        {
            int leftIndex = low + 1;
            int rightIndex = height;

            T key = array[low];
            T temp;
            while (leftIndex < rightIndex)
            {
                while (leftIndex < rightIndex && condition(array[leftIndex], key) == inversion)
                {
                    leftIndex++;
                }
                while (leftIndex < rightIndex && condition(array[rightIndex], key) == !inversion)
                {
                    rightIndex--;
                }
                if (leftIndex < rightIndex)
                {
                    temp = array[leftIndex];
                    array[leftIndex] = array[rightIndex];
                    array[rightIndex] = temp;
                }
            }

            // 返回下标
            if (condition(array[leftIndex], key) == inversion)
            {
                array[low] = array[leftIndex];
                array[leftIndex] = key;
            }
            return leftIndex - 1;
        }
    }
}
