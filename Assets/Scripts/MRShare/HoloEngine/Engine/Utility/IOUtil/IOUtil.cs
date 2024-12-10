/****************************************************************************
* ScriptType: 主框架 - IOUtil
* 核心功能:   IOUtil 工具
* 
* 修改人:     袁楠
* 修改时间:   2021/6/23
****************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace HoloEngine
{
    public class IOUtil
    {
        private static List<string> ignoreExtension = new List<string> { ".meta", ".DS_Store" };

        public static string[] GetFolderAllFiles(string folderPath)
        {
            List<string> allFiles = new List<string>();
            GetFolderAllFiles(folderPath, ref allFiles);

            return allFiles.ToArray();
        }

        public static void GetFolderAllFiles(string folderPath, ref List<string> files)
        {
            if (!ExistsFolder(folderPath)) return;
            // 方法1
            string[] names = Directory.GetFiles(folderPath);
            string[] dirs = Directory.GetDirectories(folderPath);
            foreach (string filename in names)
            {
                if (!ignoreExtension.Contains(Path.GetExtension(filename)))
                    files.Add(PathUtil.GetRawPath(filename));
            }
            foreach (string dir in dirs)
            {
                GetFolderAllFiles(dir, ref files);
            }
        }

        public static void WriteAllText(string path, string contents)
        {
            string name = Path.GetFileName(path);
            string folder = path.Substring(0, path.Length - name.Length - 1);

            try
            {
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                File.WriteAllText(path, contents, new UTF8Encoding(false));
            }
            catch (Exception e)
            {
                Debug.Log($"[IOUtil] 写入{path}文件错误,Err:{e}");
            }
        }

        public static void SafeWriteAllText(string path, string contents)
        {
            string name = Path.GetFileName(path);
            string folder = path.Substring(0, path.Length - name.Length - 1);

            try
            {
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                byte[] arr = Encoding.Unicode.GetBytes(contents);
                using (FileStream fs = new FileStream(path,FileMode.OpenOrCreate))
                {
                    fs.Write(arr, 0, arr.Length);
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                Debug.Log($"[IOUtil] 写入{path}文件错误,Err:{e}");
            }
        }

        public static void WriteAllBytes(string path, byte[] bytes)
        {
            CreateFile(path);
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                Debug.Log($"[IOUtil] 写入{path}文件错误,Err:{e}");
            }
        }

        public static string ReadAllTargetText(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path, UTF8Encoding.UTF8))
                    {
                        string str = sr.ReadToEnd();
                        sr.Close();
                        sr.Dispose();
                        return str;
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogWarning(ex.ToString());
                }
            }
            return null;
        }

        public static string ReadAllText(string path)
        {
            try
            {
                if (File.Exists(path))
                    return File.ReadAllText(path);
                return null;
            }
            catch (Exception ex)
            {
                Debug.LogWarning("ex:"+ex.ToString());
                throw;
            }
        }

        public static byte[] ReadAllBytes(string path)
        {
            if (File.Exists(path))
            {
                byte[] pReadByte = null;
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        BinaryReader r = new BinaryReader(fs);
                        r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开
                        pReadByte = r.ReadBytes((int)r.BaseStream.Length);
                        fs.Close();
                    }
                }
                catch (Exception) { }

                return pReadByte;
            }
            return null;
        }

        public static bool ExistsFile(string path, params string[] paths)
        {
            StringBuilder reader = new StringBuilder(path);
            for (int i = 0; i < paths.Length; i++)
            {
                reader.Append($"/{paths[i]}");
            }

            return File.Exists(reader.ToString());
        }

        public static bool ExistsFolder(string path, params string[] paths)
        {
            StringBuilder reader = new StringBuilder(path);
            for (int i = 0; i < paths.Length; i++)
            {
                reader.Append($"/{paths[i]}");
            }

            return Directory.Exists(reader.ToString());
        }

        public static void CreateFolder(string folderPath)
        {
            if (Directory.Exists(folderPath)) Directory.Delete(folderPath, true);
            Directory.CreateDirectory(folderPath);
        }

        public static void CreateFile(string filePath)
        {
            if (ExistsFile(filePath)) return;
            string folderName = Path.GetDirectoryName(filePath);
            CreateFolder(folderName);
            File.Create(filePath).Close();
        }

        public static void CopyFile(string filePath, string targetPath, bool isDele = false)
        {
            if (!ExistsFile(filePath)) Debug.Log($"[IOUtil] Copy 未找到拷贝文件{filePath}");
            else
            {
                string targetFolder = Path.GetDirectoryName(targetPath);
                if (!Directory.Exists(targetFolder))
                    Directory.CreateDirectory(targetFolder);
                try
                {
                    File.Copy(filePath, targetPath, true);
                }
                catch (Exception) { }
                finally
                {
                    if (isDele)
                        File.Delete(filePath);
                }
            }
        }

        public static void CopyDir(string dirPath, string tarPath, bool isDele = false)
        {
            try
            {
                // 判断目标目录是否存在如果不存在则新建之
                if (Directory.Exists(tarPath) && isDele)
                {
                    Directory.Delete(tarPath, true);
                    Directory.CreateDirectory(tarPath);
                }
                else
                    Directory.CreateDirectory(tarPath);

                string[] fileList = Directory.GetFileSystemEntries(dirPath);

                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    string filePath = $"{tarPath}/{Path.GetFileName(file)}";
                    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                    if (Directory.Exists(file))
                    {
                        CopyDir(file, filePath, isDele);
                    }
                    // 否则直接Copy文件
                    else
                    {
                        if (!file.EndsWith(".meta"))
                            CopyFile(file, filePath, isDele);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log($"[IOUtil] Copy Dir File,Err: {e}");
            }
        }

        // AssetBundle Manifest
        public static List<string> ReadManifestAssets(string manifestPath)
        {
            List<string> assets = new List<string>();
            using (StreamReader sr = File.OpenText(manifestPath))
            {
                string lineTxt = null;      // 每一行的文本内容
                bool isAssets = false;      // 开始记录
                while ((lineTxt = sr.ReadLine()) != null)
                {
                    if (lineTxt.StartsWith("Assets:"))
                    {
                        isAssets = true;
                        continue;
                    }
                    else if (lineTxt.StartsWith("Dependencies:")) break;

                    if (isAssets)
                    {
                        string[] splits = lineTxt.Split('/');
                        string resName = splits[splits.Length - 1];
                        resName = resName.Replace(Path.GetExtension(resName), "");
                        assets.Add(resName);
                    }
                }
                sr.Close();
            }
            return assets;
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public static void DeleteDir(string path)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }

        public static void DeleteFileInDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}