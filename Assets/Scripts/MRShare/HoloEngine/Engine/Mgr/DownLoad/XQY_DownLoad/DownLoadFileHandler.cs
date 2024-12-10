using System;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Text;


public class DownLoadFileHandler : DownloadHandlerScript
{
    //当前下载速度
    private float _downloadRate;
    //是否处理下载状态
    private bool _isDown;
    //当前下载长度
    private int _nowLength;
    //文件总长度
    private int _sumLength;
    //经过时间
    private float _downloadStartTime;
    //下载时间
    private float _downloadTotalTime;
    private bool isDone;
    //文件写入控制器
    private FileStream _fileStream;
    //下载速度更新回调
    private Action<string> _updateDownloadRateAction;
    //
    private int _updateActionFrame = 30;
    private int _frame;
    
    
    
    //当前下载长度
    public int NowLength
    {
        get
        {
            return _nowLength;
        }
    }
    //当前下载总长度
    public int SumLength
    {
        get
        {
            return _sumLength;
        }
    }
    //当前下载百分比
    public float DownloadProgress
    {
        get
        {
            if (SumLength == 0)
                return 0f;
            
            return (float)NowLength / SumLength;
        }
    }
    //当前下载速度
    public float DownloadRate
    {
        get
        {
            return _downloadRate;
        }
    }
    //下载完成状态
    public bool IsDone
    {
        get
        {
            return isDone;
        }
    }
    
    
    
    
    #region 初始化

    public DownLoadFileHandler(string saveFilePath, Action<string> updateDownloadRateAction = null) : base(new byte[1024 * 200])  //限制下载的长度
    {
        _frame = _updateActionFrame - 1;
        _updateDownloadRateAction = updateDownloadRateAction;
        _isDown = true;
        InitFileStreamData(GetFilePath(saveFilePath), saveFilePath);
    }

    #endregion


    #region 重写方法

    [System.Obsolete]
    protected override void ReceiveContentLength(int contentLength) 
    {
        _sumLength = contentLength + _nowLength;
    }
            
    protected override bool ReceiveData(byte[] data, int dataLength)
    {
        if (_downloadStartTime == 0)
            _downloadStartTime = Time.time;
        
        if (!_isDown)
            return false;

        _nowLength += dataLength;
        _downloadTotalTime = Time.time - _downloadStartTime;
        WriteFile(data, dataLength);
                
        _downloadRate = 0;
                
        if (_downloadTotalTime != 0)
            _downloadRate = _nowLength / _downloadTotalTime / 1024f / 1024f;
        else
            _downloadRate = _nowLength / 1024f / 1024f;
        
        // Debug.Log("   下载的长度--- " + NowLength + "   总时间====" + _downloadTotalTime);
        // Debug.Log("   下载的长度" + NowLength + "   总长度" + SumLength + "进度：" + DownloadProgress);
        // Debug.Log("   下载的长度---" + NowLength + "   总长度====" + SumLength);
        // Debug.Log(DownloadRate.ToString("f1") + "mb/s");
        _frame++;

        if (_frame == _updateActionFrame)
        {
            _frame = 0;
            _updateDownloadRateAction?.Invoke(DownloadRate >= 1 ? DownloadRate.ToString("f3") + "mb/s" : (DownloadRate * 1024f).ToString("f1") + "kb/s");
        }
               
        return true;
    }
    
    protected override void CompleteContent()
    {
        isDone = true;
        _fileStream?.Close();
        _updateDownloadRateAction?.Invoke("");
    }

    #endregion

    
    #region 获取文件长度

    private void InitFileStreamData(string folderPath, string path)
    {
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
        
        if (!File.Exists(path))
            _fileStream = File.Create(path);
        else
        {
            File.Delete(path);
            _fileStream = File.Create(path);
            //_fileStream = File.OpenWrite(path);
        }
            

        _fileStream.Seek(_fileStream.Length, SeekOrigin.Current);
        _nowLength = (int) _fileStream.Length;
    }

    #endregion


    #region 写入数据

    

    private void WriteFile(byte[] dates, int length)
    {
        _fileStream?.Write(dates, 0, length);
        _fileStream?.Flush();
    }

    #endregion
    
    
    
    private string GetFilePath(string path)
    {
        if (!string.IsNullOrEmpty(path))
        {
            string[] stringDatas = path.Split('/');
            StringBuilder strbuilder = new StringBuilder();

            if (stringDatas.Length - 1 >= 0)
            {
                for (int i = stringDatas.Length - 1; i < stringDatas.Length; i++)
                    strbuilder.Append(stringDatas[i]);
                    
                return path.Replace(strbuilder.ToString(), "") ;     
            }
        }
                
        return "";
    }


    public void CancelFileStream()
    {
        // Debug.Log("Cancel File Stream");
        _fileStream?.Close();
        _fileStream = null;
    }
}
