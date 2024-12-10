/****************************************************************************
* ScriptType: 主框架Editor - 平台判断IO工具
* 核心功能:   过的平台的路径地址
* 
* 修改人:     袁楠
* 修改时间:   2021/7/1
****************************************************************************/

using UnityEngine;

namespace HoloEngine
{

    public class PlatformUtil
    {
        /// <summary>
        /// 获取平台的资源路径
        /// </summary>
        /// <returns></returns>
        public static string GetPlatformAssetPath()
        {
#if UNITY_EDITOR
            return Application.streamingAssetsPath;
#else
            if (Application.platform == RuntimePlatform.Android)
                return Application.dataPath + "!assets";
            else
                return Application.streamingAssetsPath;
#endif
        }

        /// <summary>
        /// 获得默认的平台名
        /// </summary>
        public static string PlatformName
        {
            get
            {
#if UNITY_EDITOR
                UnityEditor.BuildTarget target = UnityEditor.EditorUserBuildSettings.activeBuildTarget;
                return GetPlatformName(target);
#else
                RuntimePlatform platform = Application.platform;
                return GetPlatformName(platform);
#endif
            }
        }

        /// <summary>
        /// 获取平台的名称
        /// </summary>
        /// <returns></returns>
        public static string GetPlatformName(RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.Android:
                    return "Android";
                case RuntimePlatform.IPhonePlayer:
                    return "IOS";
                default:
                    return "UWP";
            }
        }

#if UNITY_EDITOR
        /// <summary>
        /// 获取平台的名称
        /// </summary>
        /// <returns></returns>
        public static string GetPlatformName(UnityEditor.BuildTarget target)
        {
            switch (target)
            {
                case UnityEditor.BuildTarget.Android:
                    return "Android";
                case UnityEditor.BuildTarget.iOS:
                    return "IOS";
                default:
                    return "UWP";
            }
        }
#endif
    }
}