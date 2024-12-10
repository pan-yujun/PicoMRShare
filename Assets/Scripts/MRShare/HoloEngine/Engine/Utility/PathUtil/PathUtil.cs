/****************************************************************************
* ScriptType: 主框架工具 - 路径工具
* 核心功能:   Unity 各个平台的路径工具
* 
* 修改人:     袁楠
* 修改时间:   2021/7/1
****************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HoloEngine
{
    public class PathUtil
    {
        #region AssetBundle
        /// <summary>
        /// 获得AB 输出路径
        /// </summary>
        public static string GetAssetBundleOutputPath()
        {
            return $"{PlatformUtil.GetPlatformAssetPath()}/AssetBundle/{PlatformUtil.PlatformName}";
        }

        /// <summary>
        /// 获得AB包的路径
        /// </summary>
        public static string GetAssetBundlePath(string abName)
        {
            return GetRawPath($"{GetAssetBundleOutputPath()}/{abName}");
        }

        /// <summary>
        /// 获得AB包的Manifest路径
        /// </summary>
        public static string GetAssetBundleManifestOutputPath(string abName)
        {
            string ext = Path.GetExtension(abName);
            string filePath = $"{abName.Replace(ext, "")}.manifest";
            return GetRawPath($"{GetAssetBundleOutputPath()}/{filePath}");
        }

        /// <summary>
        /// 获得AssetBundle文件夹名字
        /// </summary>
        public static string GetAssetBundleFolderName(string id,string name)
        {
            return $"{id}_{name}".ToLower();
        }
        #endregion

        #region Game ListPropertys
        /// <summary>
        /// 获得游戏2D资源路径
        /// </summary>
        public static string GetGamePropertysPath(string resName)
        {
            return GetRawPath($"{PlatformUtil.GetPlatformAssetPath()}/Local/Resource/{resName}");
        }

        // TODO 传入2D资源的游戏ID和游戏2D资源名,输出路径

        #endregion

        #region Local Config
        /// <summary>
        /// 获得游戏配置Config
        /// </summary>
        public static string GetGameConfigPath(string config)
        {
            return GetRawPath($"{PlatformUtil.GetPlatformAssetPath()}/Local/Config/{config}");
        }
        #endregion

        public static string GetRawPath(string path)
        {
            return path.Replace("\\", "/");
        }
    }
}
