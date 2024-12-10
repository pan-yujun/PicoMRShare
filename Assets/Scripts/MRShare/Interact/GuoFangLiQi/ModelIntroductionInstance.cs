using HoloEngine;
using UnityEngine;

public class ModelIntroductionInstance : Singleton<ModelIntroductionInstance>
{
    private Transform lastIntroObj;
 
   /// <summary>
   /// 关闭上个声音播放
   /// </summary>
   /// <param name="obj"></param>
    public void CloseLastAudio(Transform obj=null)
    {
        if (lastIntroObj != null&&lastIntroObj!=obj)
        {
            
            lastIntroObj.gameObject.SetActive(false);

        }

        lastIntroObj = obj;
        
    }
}
