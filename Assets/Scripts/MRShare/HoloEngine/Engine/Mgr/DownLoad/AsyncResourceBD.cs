using System;
using UnityEngine;
using System.Collections.Generic;

namespace HoloEngine
{
    /// <summary>
    /// Async Resource Batch  Download
    /// 资源的批量下载器
    /// </summary>
    public class AsyncResourceBD : AsyncResourceUD
    {
        public delegate void OnBatchDownloadedEventHandler(List<ResourceDownloadCompletedEventArgs> args);
        public AsyncResourceBD() { ResourceDownloadCompleted += DownLoadResoucesCompleted; }

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

        public event OnBatchDownloadedEventHandler ResourceBatchDownloadCompleted;
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
        private List<ResourceDownloadCompletedEventArgs> completedList = new List<ResourceDownloadCompletedEventArgs>();
        #endregion

        #region PUBLIC METHODS
        public async void BatchDownloadRemoteFiles(string[] resUrls, string[] saveUrls)
        {
            if (!isProgressing && resUrls != null && resUrls.Length != 0 && saveUrls != null && saveUrls.Length == resUrls.Length)
            {
                completedList.Clear();
                resourceList = resUrls;

                for (int i = 0; i < resourceList.Length; i++)
                {
                    await DownLoadRemoteFile(resUrls[i], saveUrls[i]);
                }
                ResourceBatchDownloadCompleted(completedList);
            }
            else
            {
                ResourceBatchDownloadCompleted(null);
                Debug.Log($"批量读取器正在执行中,请新建一个批量读取器读取资源");
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            resourceList = null;
            completedList = null;
            ResourceBatchDownloadCompleted = null;
        }
        #endregion

        #region PRIVATE METHODS
        private void DownLoadResoucesCompleted(bool err, ResourceDownloadCompletedEventArgs args)
        {
            completeCount++;
            if (!err)
                completedList.Add(args);
        }
        #endregion
    }
}
