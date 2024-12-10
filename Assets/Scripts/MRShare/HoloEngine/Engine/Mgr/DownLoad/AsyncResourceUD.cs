using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using SVermeulen.Unity3dAsyncAwaitUtil;
using System.Text.RegularExpressions;

namespace HoloEngine
{
    public class ResourceDownloadCompletedEventArgs : EventArgs
    {
        public string ResourcesUrl { get; set; }
        public string LocalUrl { get; set; }

        public ResourceDownloadCompletedEventArgs(string remoteUrl, string localUrl)
        {
            ResourcesUrl = remoteUrl;
            LocalUrl = localUrl;
        }
    }

    /// <summary>
    /// Async Resource Unit DownLoad
    /// 资源的单元下载器
    /// </summary>
    public class AsyncResourceUD : IDisposable
    {
        public delegate void OnResourceDownloadEventHandler(bool err, ResourceDownloadCompletedEventArgs args);

        #region PUBLIC PROPERTIES

        /// <summary>
        /// 下载的进度。(0表示当前不在下载过程。)
        /// </summary>
        public virtual float downloadedBytes
        {
            get
            {
                if (isProgressing && requestCache != null)
                    // return requestCache.downloadedBytes;
                    return (requestCache.downloadHandler as DownLoadFileHandler).NowLength;
                else
                    //UnityWebRequest对象是一次性的，下载完成后就被销毁，所以不能再去访问，否则会出现错误。
                    return 0;

            }
        }

        /// <summary>
        /// 下载的进度。(0表示当前不在下载过程。)
        /// </summary>
        public virtual float DownloadProgress
        {
            get
            {
                if (isProgressing && requestCache != null)
                    // return requestCache.downloadProgress;
                    return (requestCache.downloadHandler as DownLoadFileHandler).DownloadProgress;
                return 0;
            }
        }

        
        public virtual float DownloadRate
        {
            get
            {
                if (isProgressing && requestCache != null)
                    return (requestCache.downloadHandler as DownLoadFileHandler).DownloadRate;
                return 0;
            }
        }



        public event OnResourceDownloadEventHandler ResourceDownloadCompleted;
        #endregion

        #region PROTECTED PROPERTIES
        /// <summary>
        /// 当前是否在下载的指示器。
        /// </summary>
        protected bool isProgressing;

        /// <summary>
        /// 由于UnityWebRequest是使用using方式创建，需要缓存一下以便能够访问。
        /// </summary>
        protected UnityWebRequest requestCache;

        /// <summary>
        /// 超时帧数 60=1秒
        /// </summary>
        private int m_TimeOut = 60 * 5;

        /// <summary>
        /// UnityWebRequest 超时的时间
        /// </summary>
        private int DEFAULT_TIMES = 5;

        /// <summary>
        /// 是否完成下载
        /// </summary>
        private bool isComplete = false;

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// 下载目标文件 （有超时处理的）
        /// </summary>
        /// <param name="remoteUrl"></param>
        /// <param name="saveUrl"></param>
        /// <returns></returns>
        public async Task DownLoadTargetFile(string remoteUrl, string saveUrl, Action<string> updateaDownloadRateAction)
        {
            if (!isProgressing && !string.IsNullOrEmpty(remoteUrl) && !string.IsNullOrEmpty(saveUrl))
            {
                int times = 0;
                isComplete = false;

                while (times < m_TimeOut && !isComplete)
                {
                    using (var request = UnityWebRequest.Get(GetPath(remoteUrl)))
                    {
                        // request.downloadHandler = new DownloadHandlerFile(saveUrl);
                        request.downloadHandler = new DownLoadFileHandler(saveUrl, updateaDownloadRateAction);
                        requestCache = request;
                        isProgressing = true;

                        await request.SendWebRequest();
                        isProgressing = false;

                        if (request.error != null)
                        {
                            times++;
                            Debug.LogWarning("m_TimeOut:" + m_TimeOut + " times:" + times + "\nremoteUrl:" + remoteUrl + "\nsaveUrl:" + saveUrl);
                            if (times == m_TimeOut)
                            {
                                Debug.Log($"图片资源 {remoteUrl} 下载失败,请检查资源是否正确！");
                                ResourceDownloadCompleted?.Invoke(true, new ResourceDownloadCompletedEventArgs(remoteUrl, saveUrl));
                            }
                        }
                        else
                        {
                            isComplete = true;
                            times = 0;

                            ResourceDownloadCompleted?.Invoke(false, new ResourceDownloadCompletedEventArgs(remoteUrl, saveUrl));
                        }
                    }
                }
            }
            else
            {
                ResourceDownloadCompleted?.Invoke(true, new ResourceDownloadCompletedEventArgs(remoteUrl, saveUrl));
                Debug.Log($"单元下载器正在执行中,请新建一个单元下载器下载 {remoteUrl} 资源");
            }
        }


        public async Task DownLoadRemoteFile(string remoteUrl, string saveUrl)
        {
            if (!isProgressing && !string.IsNullOrEmpty(remoteUrl) && !string.IsNullOrEmpty(saveUrl))
            {
                using (var request = UnityWebRequest.Get(GetPath(remoteUrl)))
                {
                    // request.downloadHandler = new DownloadHandlerFile(saveUrl);
                    request.downloadHandler = new DownLoadFileHandler(saveUrl);
                    requestCache = request;
                    isProgressing = true;

                    await request.SendWebRequest();
                    isProgressing = false;
                    if (request.isNetworkError || request.isHttpError)
                    {
                        Debug.Log($"图片资源 {remoteUrl} 下载失败,请检查资源是否正确！");
                        ResourceDownloadCompleted?.Invoke(true, new ResourceDownloadCompletedEventArgs(remoteUrl, saveUrl));
                    }
                    else
                    {
                        ResourceDownloadCompleted?.Invoke(false, new ResourceDownloadCompletedEventArgs(remoteUrl, saveUrl));
                    }
                }
            }
            else
            {
                ResourceDownloadCompleted?.Invoke(true, new ResourceDownloadCompletedEventArgs(remoteUrl, saveUrl));
                Debug.Log($"单元下载器正在执行中,请新建一个单元下载器下载 {remoteUrl} 资源");
            }
        }

        public virtual void Dispose()
        {
            // isProgressing = false;
            // requestCache = null;
            // ResourceDownloadCompleted = null;

            // Debug.Log("111111111111111");
        }

        public void AbortCurDownload()
        {
            (requestCache?.downloadHandler as DownLoadFileHandler)?.CancelFileStream();
            Dispose();
            isProgressing = false;
            requestCache = null;
            ResourceDownloadCompleted = null;
        }
        #endregion

        #region PRIVATE METHODS
        private string GetPath(string remoteUrl)
        {
            if (Regex.IsMatch(remoteUrl, @"((http|ftp|https)://)(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,4})*(/[a-zA-Z0-9\&%_\./-~-]*)?"))
                return remoteUrl;
            else
            {
#if !UNITY_EDITOR && UNITY_ANDROID
                return "file:///" + remoteUrl;
#elif !UNITY_EDITOR && UNITY_IOS
                return "file://" + remoteUrl;
#endif
                return remoteUrl;
            }
        }
        #endregion
    }
}
