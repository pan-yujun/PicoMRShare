using UnityEngine;

namespace HoloEngine
{
    /// <summary>
    /// yuannan 的文件下载和读取工具,所有的加载方式都基于UnityWebRequest
    /// </summary>
    public class YNDM : Singleton<YNDM>
    {
        #region DownLoader
        // 单个文件资源下载
        public AsyncResourceBD DownLoadOnceResrouces(string resUrl, string saveUrl, AsyncResourceBD.OnBatchDownloadedEventHandler completed = null)
        {
            return DownLoadBatchResrouces(new string[] { resUrl }, new string[] { saveUrl }, completed);
        }

        // 批量资源下载
        public AsyncResourceBD DownLoadBatchResrouces(string[] resUrls, string[] saveUrls, AsyncResourceBD.OnBatchDownloadedEventHandler completed = null)
        {
            AsyncResourceBD loader = new AsyncResourceBD();
            if (completed != null)
                loader.ResourceBatchDownloadCompleted += completed;

            loader.BatchDownloadRemoteFiles(resUrls, saveUrls);
            return loader;
        }
        #endregion

        #region Reader
        // 单个文件资源读取
        public AsyncResourceBR<T> ReadOnceResrouces<T>(string resUrl, AsyncResourceBR<T>.OnResourceReadedEventHandler completed = null)
        {
            return ReadBatchResrouces(new string[] { resUrl }, completed);
        }

        // 批量资源读取
        public AsyncResourceBR<T> ReadBatchResrouces<T>(string[] resUrls, AsyncResourceBR<T>.OnResourceReadedEventHandler completed = null)
        {
            AsyncResourceBR<T> reader = new AsyncResourceBR<T>();
            if (completed != null)
                reader.ResourceBatchCompleted += completed;

            reader.BatchReadResources(resUrls);
            return reader;
        }

        // 单个音频文件资源读取
        public AsyncResourceBR<AudioClip> ReadOnceResroucesAudioClip(string resUrls, AudioType type, AsyncResourceBR<AudioClip>.OnResourceReadedEventHandler completed = null)
        {
            return ReadBatchResroucesAudioClip(new string[] { resUrls }, type, completed);
        }

        // 批量音频文件资源读取
        public AsyncResourceBR<AudioClip> ReadBatchResroucesAudioClip(string[] resUrl, AudioType type, AsyncResourceBR<AudioClip>.OnResourceReadedEventHandler completed = null)
        {
            AsyncResourceBR<AudioClip> reader = new AsyncResourceBR<AudioClip>();
            if (completed != null)
                reader.ResourceBatchCompleted += completed;

            reader.BatchReadResourcesAudio(resUrl, type);
            return reader;
        }
        #endregion
    }
}
