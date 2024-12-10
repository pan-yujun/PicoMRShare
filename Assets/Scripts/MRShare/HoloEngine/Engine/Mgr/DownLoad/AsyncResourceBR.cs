using System;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;

namespace HoloEngine
{
    /// <summary>
    /// Async Resource Batch  Reader
    /// 资源的批量读取器
    /// </summary>
    public class AsyncResourceBR<T> : AsyncResourceUR
    {
        public delegate void OnResourceReadedEventHandler(Dictionary<string, T> sender);
        public AsyncResourceBR()
        {
            ResourceLoadedCompleted += ReadResoucesCompleted;

            if (typeof(T) == typeof(Texture2D))
            {
                DoAction = (str) => ReadTexture2D(str);
            }
            else if (typeof(T) == typeof(AssetBundle))
            {
                DoAction = (str) => ReadAssetBundle(str);
            }
            else if (typeof(T) == typeof(string))
            {
                DoAction = (str) => ReadFileText(str);
            }
            else if (typeof(T) == typeof(byte[]))
            {
                DoAction = (str) => ReadFileBytes(str);
            }
        }

        #region PUBLIC PROPERTIES
        /// <summary>
        /// 下载的进度。(0表示当前不在下载过程。)
        /// </summary>
        public override float DownloadProgress
        {
            get
            {
                if (isProgressing && resourceList != null)
                    return (completeCount + requestCache.downloadProgress) / resourceList.Length;
                else
                    return 0;
            }
        }
        public event OnResourceReadedEventHandler ResourceBatchCompleted;
        #endregion

        #region PRIVATE PROPERTIES
        /// <summary>
        /// 需要下载的列表
        /// </summary>
        private string[] resourceList;
        /// <summary>
        /// 已经完成的个数
        /// </summary>
        private int completeCount;
        /// <summary>
        /// 已经下载完成的列表
        /// </summary>
        private Dictionary<string, T> completedDic = new Dictionary<string, T>();

        /// <summary>
        /// 固定的Task方法，性能优化
        /// </summary>
        private Func<string, Task> DoAction;
        #endregion

        #region PUBLIC METHODS
        public async void BatchReadResources(string[] resUrls)
        {
            if (!isProgressing && resUrls != null && resUrls.Length != 0)
            {
                isProgressing = true;
                resourceList = resUrls;
                completeCount = 0;
                completedDic.Clear();

                for (int i = 0; i < resourceList.Length; i++)
                {
                    await DoAction.Invoke(resUrls[i]);
                }
                isProgressing = false;
                ResourceBatchCompleted(completedDic);
            }
            else
            {
                ResourceBatchCompleted(null);
                Debug.Log($"批量读取器正在执行中,请新建一个批量读取器读取资源");
            }
        }

        public async void BatchReadResourcesAudio(string[] resUrls, AudioType type)
        {
            if (!isProgressing && resUrls != null && resUrls.Length != 0)
            {
                isProgressing = true;
                resourceList = resUrls;
                completeCount = 0;
                completedDic.Clear();

                for (int i = 0; i < resourceList.Length; i++)
                {
                    _ = await ReadAudio(resUrls[i], type);
                }
                isProgressing = false;
                ResourceBatchCompleted(completedDic);
            }
            else
            {
                Debug.Log($"批量读取器正在执行中,请新建一个批量读取器读取资源");
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            completedDic.Clear();
            resourceList = null;
            completedDic = null;
            DoAction = null;
            ResourceBatchCompleted = null;
        }
        #endregion

        #region PRIVATE METHODS
        private void ReadResoucesCompleted(bool err, ResourceReadCompletedEventArgs args)
        {
            completeCount++;
            if (!err)
                completedDic[args.ResourceUrl] = (T)(args.Sender);
        }
        #endregion
    }
}
