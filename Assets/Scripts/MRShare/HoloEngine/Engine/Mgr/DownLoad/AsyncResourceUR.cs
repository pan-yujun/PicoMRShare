using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using SVermeulen.Unity3dAsyncAwaitUtil;
using System.Text.RegularExpressions;

namespace HoloEngine
{
    public class ResourceReadCompletedEventArgs : EventArgs
    {
        public string ResourceUrl { get; set; }
        public object Sender { get; set; }

        public ResourceReadCompletedEventArgs(string resourceUrl, object sender)
        {
            ResourceUrl = resourceUrl;
            Sender = sender;
        }
    }

    /// <summary>
    /// Async Resource Unit Reader
    /// 资源的单元读取器
    /// </summary>
    public class AsyncResourceUR : IDisposable
    {
        public delegate void OnResourceReadEventHandler(bool err, ResourceReadCompletedEventArgs args);

        #region PUBLIC PROPERTIES
        /// <summary>
        /// 下载的进度。(0表示当前不在下载过程。)
        /// </summary>
        public virtual float DownloadProgress
        {
            get
            {
                if (isProgressing && requestCache != null)
                    return requestCache.downloadProgress;
                else
                    //UnityWebRequest对象是一次性的，下载完成后就被销毁，所以不能再去访问，否则会出现错误。
                    return 0;
            }
        }

        public event OnResourceReadEventHandler ResourceLoadedCompleted;
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
        #endregion

        #region PUBLIC METHODS

        public async Task<Texture2D> ReadTexture2D(string resUrl, bool compress)
        {
            if (!isProgressing && !string.IsNullOrEmpty(resUrl))
            {
                using (var request = UnityWebRequestTexture.GetTexture(GetPath(resUrl)))
                {
                    requestCache = request;
                    isProgressing = true;

                    await request.SendWebRequest();
                    isProgressing = false;
                    if (request.isNetworkError || request.isHttpError)
                    {
                        Debug.Log($"图片资源 {resUrl} 读取失败,请检查资源是否正确！");
                        ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                        return null;
                    }
                    else
                    {
                        var texture = DownloadHandlerTexture.GetContent(request);
                        texture.Compress(compress);
                        ResourceLoadedCompleted?.Invoke(false, new ResourceReadCompletedEventArgs(resUrl, texture));
                        return texture;
                    }
                }
            }
            else
            {
                ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                Debug.Log($"单元读取器正在执行中,请新建一个单元读取器读取 {resUrl} 资源");
                return null;
            }
        }

        public async Task<Texture2D> ReadTexture2D(string resUrl)
        {
            if (!isProgressing && !string.IsNullOrEmpty(resUrl))
            {
                using (var request = UnityWebRequestTexture.GetTexture(GetPath(resUrl)))
                {
                    requestCache = request;
                    isProgressing = true;

                    await request.SendWebRequest();
                    isProgressing = false;
                    if (request.isNetworkError || request.isHttpError)
                    {
                        Debug.Log($"图片资源 {resUrl} 读取失败,请检查资源是否正确！");
                        ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                        return null;
                    }
                    else
                    {
                        var texture = DownloadHandlerTexture.GetContent(request);
                        ResourceLoadedCompleted?.Invoke(false, new ResourceReadCompletedEventArgs(resUrl, texture));
                        return texture;
                    }
                }
            }
            else
            {
                ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                Debug.Log($"单元读取器正在执行中,请新建一个单元读取器读取 {resUrl} 资源");
                return null;
            }
        }

        public async Task<AssetBundle> ReadAssetBundle(string resUrl)
        {
            if (!isProgressing && !string.IsNullOrEmpty(resUrl))
            {
                using (var request = UnityWebRequestAssetBundle.GetAssetBundle(GetPath(resUrl)))
                {
                    requestCache = request;
                    isProgressing = true;

                    await request.SendWebRequest();
                    isProgressing = false;
                    if (request.isNetworkError || request.isHttpError)
                    {
                        Debug.Log($"AssetBundle资源 {resUrl} 读取失败,请检查资源是否正确！");
                        ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                        return null;
                    }
                    else
                    {
                        var asset = DownloadHandlerAssetBundle.GetContent(request);
                        ResourceLoadedCompleted?.Invoke(false, new ResourceReadCompletedEventArgs(resUrl, asset));
                        return asset;
                    }
                }
            }
            else
            {
                ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                Debug.Log($"单元读取器正在执行中,请新建一个单元读取器下载 {resUrl} 资源");
                return null;
            }
        }

        public async Task<string> ReadFileText(string resUrl)
        {
            if (!isProgressing && !string.IsNullOrEmpty(resUrl))
            {
                using (var request = UnityWebRequest.Get(GetPath(resUrl)))
                {
                    requestCache = request;
                    isProgressing = true;

                    await request.SendWebRequest();
                    isProgressing = false;
                    if (request.isNetworkError || request.isHttpError)
                    {
                        Debug.Log($"文本资源 {resUrl} 读取失败,请检查资源是否正确！");
                        ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                        return null;
                    }
                    else
                    {
                        var text = request.downloadHandler.text;
                        ResourceLoadedCompleted?.Invoke(false, new ResourceReadCompletedEventArgs(resUrl, text));
                        return text;
                    }
                }
            }
            else
            {
                ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                Debug.Log($"单元读取器正在执行中,请新建一个单元读取器下载 {resUrl} 资源");
                return null;
            }
        }

        public async Task<byte[]> ReadFileBytes(string resUrl)
        {
            if (!isProgressing && !string.IsNullOrEmpty(resUrl))
            {
                using (var request = UnityWebRequest.Get(GetPath(resUrl)))
                {
                    requestCache = request;
                    isProgressing = true;

                    await request.SendWebRequest();
                    isProgressing = false;
                    if (request.isNetworkError || request.isHttpError)
                    {
                        Debug.Log($"文本资源 {resUrl} 读取失败,请检查资源是否正确！");
                        ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                        return null;
                    }
                    else
                    {
                        var bytes = request.downloadHandler.data;
                        ResourceLoadedCompleted?.Invoke(false, new ResourceReadCompletedEventArgs(resUrl, bytes));
                        return bytes;
                    }
                }
            }
            else
            {
                ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                Debug.Log($"单元读取器正在执行中,请新建一个单元读取器下载 {resUrl} 资源");
                return null;
            }
        }

        public async Task<AudioClip> ReadAudio(string resUrl, AudioType audiotype)
        {
            if (!isProgressing && !string.IsNullOrEmpty(resUrl))
            {
                using (var request = UnityWebRequestMultimedia.GetAudioClip(GetPath(resUrl), audiotype))
                {
                    requestCache = request;
                    isProgressing = true;

                    await request.SendWebRequest();
                    isProgressing = false;
                    if (request.isHttpError || request.isNetworkError)
                    {
                        Debug.Log($"音频资源 {resUrl} 读取失败,请检查资源是否正确！");
                        ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                        return null;
                    }
                    else
                    {
                        var audio = DownloadHandlerAudioClip.GetContent(request);
                        ResourceLoadedCompleted?.Invoke(false, new ResourceReadCompletedEventArgs(resUrl, audio));
                        return audio;
                    }
                }
            }
            else
            {
                ResourceLoadedCompleted?.Invoke(true, new ResourceReadCompletedEventArgs(resUrl, null));
                Debug.Log($"单元读取器正在执行中,请新建一个单元读取器下载 {resUrl} 资源");
                return null;
            }
        }

        public virtual void Dispose()
        {
            isProgressing = false;
            requestCache = null;
            ResourceLoadedCompleted = null;
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
