//using HoloSupExp;
//using Microsoft.MixedReality.Toolkit.UI;
//using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
//using System.Collections.Generic;
//using UnityEngine;

///// <summary>
///// 该脚本用于编辑模式和体验模式相互切换时，控制该物体下的所有子物体的BoundsControl和ObjectManipulator的显隐
///// </summary>
//public class ObjectManipulatorToggle : MonoBehaviour, IPreview, IEditModeToggle
//{


//    public bool IsPreview
//    {
//        set
//        {
//            Toggle(!value);
//        }
//    }

//    public void OnEditModeToggle(bool toggle)
//    {
//        Toggle(toggle);
//    }

//    BoundsControl[] boundsControls;
//    ObjectManipulator[] objectManipulators;


//    private void Awake()
//    {


//        boundsControls = GetComponentsInChildren<BoundsControl>(true);
//        objectManipulators = GetComponentsInChildren<ObjectManipulator>(true);
//    }

//    /// <summary>
//    /// 切换BoundsControl和ObjectManipulator的enable状态
//    /// </summary>
//    /// <param name="toggle"></param>
//    public void Toggle(bool toggle)
//    {
//        foreach (BoundsControl boundsControl in boundsControls)
//        {
//            boundsControl.enabled = toggle;
//        }

//        foreach (ObjectManipulator objectManipulator in objectManipulators)
//        {
//            objectManipulator.enabled = toggle;
//        }
//    }



//}
