using UnityEngine;

public class UnityAndroidSetting : MonoBehaviour
{
    public static int newStatusBarValue;

    /// <summary>
    ///  隐藏上方状态栏
    /// </summary>
    public static void Hide()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        setStatusBarValue(1024); // WindowManager.LayoutParams.FLAG_FULLSCREEN; change this to 0 if unsatisfied
#endif
    }

    /// <summary>
    ///  显示上方状态栏
    /// </summary>
    public static void Show()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        setStatusBarValue(2048); // WindowManager.LayoutParams.FLAG_FORCE_NOT_FULLSCREEN
#endif
    }

    private static void setStatusBarValue(int value)
    {
        newStatusBarValue = value;
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                activity.Call("runOnUiThread", new AndroidJavaRunnable(setStatusBarValueInThread));
            }
        }
    }

    private static void setStatusBarValueInThread()
    {
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                using (var window = activity.Call<AndroidJavaObject>("getWindow"))
                {
                    window.Call("setFlags", newStatusBarValue, newStatusBarValue);
                }
            }
        }
    }

    public bool isShowStatusBar = true;

    private void Awake()
    {
        if (isShowStatusBar)
        {
            AndroidStatusBar.statusBarState = AndroidStatusBar.States.TranslucentOverContent;
        }
        else
        {
        }
    }
}