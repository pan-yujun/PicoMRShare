//using UnityEngine;
//using Lean.Common;
//using FSA = UnityEngine.Serialization.FormerlySerializedAsAttribute;
//using Lean.Touch;
///// <summary>
///// 使用Lean插件 制作的左右滑动控制物体绕着Y轴旋转
///// 使用该方法 必须场景中有挂着Leantouch 脚本的物体
///// 必须有LeanTouchController存在
///// </summary>
//public class DragRotateInteract : MonoBehaviour
//{
//    public LeanTouchController TouchController;
//    private float _objtransformY;
//    public float Speed = 2;

//    private void Start()
//    {
//        _objtransformY = this.transform.localRotation.eulerAngles.y;
//        TouchController.AddListener(RotateListener);
//    }
//    private void RotateListener(int i, LeanTouchController.SwipeDirect swipeDirect)
//    {
//        if (i == 1)
//        {
//            RotateObj(this.transform, swipeDirect);
//        }

//    }
//    private void RotateObj(Transform objtransform, LeanTouchController.SwipeDirect swipeDirect)
//    {
//        if (swipeDirect == LeanTouchController.SwipeDirect.Left)
//        {
//            objtransform.localRotation = Quaternion.Euler(objtransform.localRotation.eulerAngles.x, _objtransformY += Speed, objtransform.localRotation.eulerAngles.z);
//        }
//        else if (swipeDirect == LeanTouchController.SwipeDirect.Right)
//        {
//            objtransform.localRotation = Quaternion.Euler(objtransform.localRotation.eulerAngles.x, _objtransformY -= Speed, objtransform.localRotation.eulerAngles.z);
//        }
//    }
//}