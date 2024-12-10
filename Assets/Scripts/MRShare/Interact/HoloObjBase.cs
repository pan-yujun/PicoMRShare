//using GF;
//using HoloShare;
//using Microsoft.MixedReality.Toolkit.UI;
//using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;

//namespace HoloSupExp
//{
//    /// <summary>
//    /// 互动开关
//    /// </summary>
//    public interface IPreview
//    {
//        bool IsPreview { set; }
//    }

//    public interface IEditModeToggle
//    {
//        void OnEditModeToggle(bool toggle);
//    }

//    public interface ILLPFSModeToggle
//    {
//        void OnLLPFSModeToggle(bool toggle);
//    }


//    public class HoloObjBase : GMono
//    {
//        [HideInInspector]
//        public Vector3 initialScale = Vector3.one;

//        public ObjData ObjData;

//        private bool isPreview;

//        public bool IsPreview
//        {
//            get
//            {
//                return isPreview;
//            }

//            set
//            {
//                isPreview = value;

//                foreach (IPreview iPreview in IPreviewArr)
//                {
//                    iPreview.IsPreview = value;
//                }
//                AppDispatcher.Instance.Dispatch(DispatcherMsg.Preview_Toggle, isPreview);

//            }
//        }

//        public bool isHideCollider = false;

//        private BoxCollider boxCollider;
//        public BoxCollider BoxCollider { get => boxCollider; }

//        public MeshRenderer targetMesh;

//        [Header("生成出来时的位置")]
//        [SerializeField]
//        private Vector3 clonePos;

//        public Vector3 ClonePos { get => clonePos; set => clonePos = value; }

//        private ObjectManipulator oml;
//        private BoundsControl boundsControl;

//        [HideInInspector]
//        public EditUI editUI;

//        private IPreview[] IPreviewArr;
//        private IEditModeToggle[] IEditModeToggleArr;
//        private Dictionary<OtherDataType, IOtherData> IOtherDataDic = new Dictionary<OtherDataType, IOtherData>();
//        private ILLPFSModeToggle[] _illpfsModeToggles;

//        public IOtherData GetIOtherData(OtherDataType otherDataType)
//        {
//            IOtherData target = null;

//            if (IOtherDataDic.ContainsKey(otherDataType))
//                target = IOtherDataDic[otherDataType];

//            return target;
//        }

//        private void Awake()
//        {
//            //RegisterMsg(GMonoMsg.EDIT_SCENE, SwitchToEditMode);
//            AppDispatcher.Instance.AddListener(DispatcherMsg.MRShare_EDIT_SCENE, SwitchToEditMode);

//            //RegisterMsg(GMonoMsg.EDIT_SCENE_TOGETHER, SwitchToEditToghterMode);
//            AppDispatcher.Instance.AddListener(DispatcherMsg.MRShare_EDIT_SCENE_TOGETHER, SwitchToEditToghterMode);

//            boxCollider = GetComponent<BoxCollider>();

//            if (isHideCollider && boxCollider != null)
//            {
//                boxCollider.enabled = false;
//            }
//            if (targetMesh == null)
//            {
//                var target = transform.TryFind("Box");

//                if (target != null)
//                    targetMesh = target.GetComponent<MeshRenderer>();
//            }

//            #region Operate

//            oml = GetComponent<ObjectManipulator>();
//            if (oml != null)
//            {
//                oml.OnManipulationStarted.AddListener(OnManipulationStarted);
//                oml.OnManipulationEnded.AddListener(OnManipulationEnded);
//            }
//            else
//            {
//                Debug.Log($"物体:{gameObject.name}没有挂载{typeof(ObjectManipulator)}组件！");
//            }

//            boundsControl = GetComponent<BoundsControl>();
//            if (boundsControl != null)
//            {
//                boundsControl.RotateStarted.AddListener(OnRotateStarted);
//                boundsControl.RotateStopped.AddListener(OnRotateStopped);

//                boundsControl.ScaleStarted.AddListener(OnScaleStarted);
//                boundsControl.ScaleStopped.AddListener(OnScaleStopped);
//            }
//            else
//            {
//                Debug.Log($"物体:{gameObject.name}没有挂载{typeof(BoundsControl).Name}组件！");
//            }

//            #endregion Operate

//            IPreviewArr = GetComponentsInChildren<IPreview>(true);
//            IEditModeToggleArr = GetComponentsInChildren<IEditModeToggle>(true);
//            _illpfsModeToggles = GetComponentsInChildren<ILLPFSModeToggle>(true);
//        }

//        private void SetEditModeToggleArr(bool toggle)
//        {
//            if (IEditModeToggleArr == null) return;
//            foreach (var item in IEditModeToggleArr)
//            {
//                item.OnEditModeToggle(toggle);
//            }

//            AppDispatcher.Instance.Dispatch(DispatcherMsg.Edit_Toggle, toggle);

//        }

//        public void SetEditorDelFunc(string fileName, System.Action<string, string> action)
//        {
//            editUI?.SetEditorUIDel(fileName, action);
//        }

//        public void SwitchToEditMode(object data)
//        {
//            bool b = Convert.ToBoolean(data);

//            if (b == true)
//            {
//                // 物体切换到编辑模式
//                editUI?.Show();

//                if (boundsControl != null)
//                    boundsControl.enabled = true;

//                if (oml != null)
//                    oml.enabled = true;

//                if (targetMesh != null)
//                    targetMesh.enabled = true;

//                SetEditModeToggleArr(true);
//                //IsPreview = false;
//                if (isHideCollider && boxCollider != null)
//                {
//                    boxCollider.enabled = true;
//                }
//            }
//            else
//            {
//                // 物体切换到体验模式
//                editUI?.Hide();

//                if (boundsControl != null)
//                    boundsControl.enabled = false;

//                if (oml != null)
//                    oml.enabled = false;

//                if (targetMesh != null)
//                    targetMesh.enabled = false;

//                SetEditModeToggleArr(false);
//                //IsPreview = true;
//                if (isHideCollider && boxCollider != null)
//                {
//                    boxCollider.enabled = false;
//                }
//            }

//        }

//        public void SwitchToEditToghterMode(object data)
//        {
//            bool b = Convert.ToBoolean(data);
//            SwitchToEditMode(!b);
//        }

//        #region Operate

//        private void OnManipulationStarted(ManipulationEventData arg0)
//        {
//            AudioMgr.Inst.PlayAudio(AudioName.MOVE_START);
//        }

//        private void OnManipulationEnded(ManipulationEventData arg0)
//        {
//            AudioMgr.Inst.PlayAudio(AudioName.MOVE_END);

//            Done();
//        }

//        private void OnRotateStarted()
//        {
//            AudioMgr.Inst.PlayAudio(AudioName.ROTATE_START);
//        }

//        private void OnRotateStopped()
//        {
//            AudioMgr.Inst.PlayAudio(AudioName.ROTATE_STOP);

//            Done();
//        }

//        private void OnScaleStarted()
//        {
//            AudioMgr.Inst.PlayAudio(AudioName.SCALE_START);
//        }

//        private void OnScaleStopped()
//        {
//            AudioMgr.Inst.PlayAudio(AudioName.SCALE_STOP);

//            Done();
//        }

//        public void ResetRotate()
//        {
//            Vector3 newV = new Vector3(0, transform.eulerAngles.y, 0);
//            transform.eulerAngles = newV;

//            //Vector3 forward = transform.forward;
//            //Vector3 right = transform.right;

//            //transform.up = Vector3.up;
//            //transform.forward = forward;
//            //transform.right = right;

//            // transform.up = Vector3.up;
//            Done();
//        }

//        public void ChangeAnges()
//        {
//            //Debug.LogWarning("自身角度:" + transform.eulerAngles + "  本地欧拉：" + transform.localEulerAngles + " forward:" + transform.forward);
//            //Debug.LogWarning("父物体 :" + transform.parent.eulerAngles + " 本地欧拉：" + transform.parent.localEulerAngles);
//            //Debug.LogWarning("PointDataHandler.pointImgData :" + PointDataHandler.pointImgData.m_EulerAngles);

//            //Vector3 vec = new Vector3(PointDataHandler.pointImgData.m_Position.x, PointDataHandler.pointImgData.m_Position.y, 0);
//            //var temp = Vector3.ProjectOnPlane(transform.position - PointDataHandler.pointImgData.m_Position, vec);

//            //GameObject obj = new GameObject();
//            //obj.transform.position = temp;

//            //transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
//            //transform.rotation = Quaternion.Euler(0, PointDataHandler.pointImgData.m_EulerAngles.y, PointDataHandler.pointImgData.m_EulerAngles.z);
//        }

//        /// <summary>
//        /// 操作完成
//        /// </summary>
//        public void Done()
//        {
//            Debug.LogWarning("使用SceneResInformationLogic替换SceneMgr");
//            //SceneMgr.Inst.UpdateTranData(ObjData.m_GameObjMark, new TranData(transform.localScale, transform.localPosition, transform.localEulerAngles));
//            SceneResInformationLogic.Inst.UpdateTranData(ObjData.m_GameObjMark, new TranData(transform.localScale, transform.localPosition, transform.localEulerAngles));

//        }

//        #endregion Operate

//        protected override void OnBeforeDestroy()
//        {
//            if (editUI != null)
//            {
//                Destroy(editUI.gameObject);
//                editUI = null;
//            }

//            if (oml != null)
//            {
//                oml.OnManipulationStarted.RemoveListener(OnManipulationStarted);
//                oml.OnManipulationEnded.RemoveListener(OnManipulationEnded);
//            }

//            if (boundsControl != null)
//            {
//                boundsControl.RotateStarted.RemoveListener(OnRotateStarted);
//                boundsControl.RotateStopped.RemoveListener(OnRotateStopped);

//                boundsControl.ScaleStarted.RemoveListener(OnScaleStarted);
//                boundsControl.ScaleStopped.RemoveListener(OnScaleStopped);
//            }
//        }

//        /// <summary>
//        /// 初始化新生成的模型数据
//        /// </summary>
//        public void InitOtherData()
//        {
//            if (ObjData == null)
//            {
//                Debug.LogError("InitOtherData Failed...Because ObjData == null!");
//                return;
//            }

//            var iOtherDatas = GetComponents<IOtherData>();

//            foreach (IOtherData iOtherData in iOtherDatas)
//            {
//                iOtherData.HoloObjBase = this;

//                IOtherDataDic[iOtherData.OtherDataType] = iOtherData;

//                OtherData otherData = ObjData.GetOtherData(iOtherData.OtherDataType);

//                ObjData.SaveOtherData(iOtherData.OtherDataType, iOtherData.InitData(otherData));
//            }
//        }

//        public void UpdateOtherData(OtherDataType otherDataType, object data)
//        {
//            ObjData.SaveOtherData(otherDataType, IOtherDataDic[otherDataType].UpdateData(data));
//        }


//        public void ResetTouchEvent(bool isTouch)
//        {
//            foreach (var item in _illpfsModeToggles)
//            {
//                item?.OnLLPFSModeToggle(isTouch);
//            }
//        }

//        [InspectorButton("同步位置Clone Pos")]
//        private void SyncPosition()
//        {

//            clonePos = transform.localPosition;


//        }

//        /// <summary>
//        /// 初始化模板数据
//        /// </summary>
//        public void InitTemplatesData()
//        {
//            if (ObjData == null)
//            {
//                Debug.LogError("InitTemplatesData Failed...Because ObjData == null!");
//                return;
//            }

//            var templatesArr = GetComponentsInChildren<IMaterialCategory>(true);
//            if (templatesArr.Length == 0)
//                return;

//            LibraryMaterialMgr libraryMaterialMgr = new LibraryMaterialMgr();
//            libraryMaterialMgr.OnStart(this.transform);
//            libraryMaterialMgr.InitTemplatesInfo(ObjData.m_LibMaterailInfo);


//            Dictionary<string, List<MeshRenderer>> renderMap = new Dictionary<string, List<MeshRenderer>>();
//            libraryMaterialMgr.InitLocalResPicInfo((libresId, instid, component, res) =>
//            {
//                if (string.IsNullOrEmpty(libresId)) return;
//                List<MeshRenderer> compList = renderMap.ContainsKey(libresId) ? renderMap[libresId] : new List<MeshRenderer>();
//                compList.Add(component);
//                renderMap[libresId] = compList;

//                MediaLibraryFile.Instance.FindTargetMeidaFilePath(libresId, null, (t, str, url) =>
//                  {
//                      MediaLibraryFile.Instance.LoadTexture(str, url, (localPath, tex) =>
//                        {
//                          //Debug.LogWarning(str+ " url:" + url);
//                          if (renderMap.ContainsKey(libresId))
//                            {
//                                var temp = renderMap[libresId];
//                                if (tex == null)
//                                {
//                                    string fileName = Path.GetFileName(str);
//                                    B.TextureLoad.Inst.LoadForExternal(fileName, str, url, (path, t2d) =>
//                                    {
//                                        tex = t2d;
//                                        _SetTex();
//                                    });
//                                }
//                                else
//                                {
//                                    _SetTex();
//                                }

//                                void _SetTex()
//                                {
//                                    for (int i = 0; i < temp.Count; i++)
//                                    {
//                                        temp[i].material.mainTexture = tex;
//                                    }
//                                }
//                            }
//                        });
//                  });
//            });

//            Dictionary<string, List<AudioSource>> audioMap = new Dictionary<string, List<AudioSource>>();
//            libraryMaterialMgr.InitLocalResAudioInfo((libresId, instid, component, res) =>
//            {
//                if (string.IsNullOrEmpty(libresId)) return;

//                MediaLibraryFile.Instance.FindTargetMeidaFilePath(libresId, component, (a, str, url) =>
//                  {
//                      List<AudioSource> compList = audioMap.ContainsKey(libresId) ? audioMap[libresId] : new List<AudioSource>();
//                      compList.Add((AudioSource)a);
//                      audioMap[libresId] = compList;

//                      string extension = Path.GetExtension(url);
//                      AudioType at = extension.Contains(".mp3") ? AudioType.MPEG : AudioType.WAV;
//                      MediaLibraryFile.Instance.LoadAudio(str, at, url, (serverUrl, clip) =>
//                         {
//                             if (audioMap.ContainsKey(libresId))
//                             {
//                                 var temp = audioMap[libresId];
//                                 for (int i = 0; i < temp.Count; i++)
//                                 {
//                                     temp[i].clip = clip;
//                                 }
//                             }
//                         });
//                  });
//            });

//            Dictionary<string, List<UnityEngine.Video.VideoPlayer>> videoMap = new Dictionary<string, List<UnityEngine.Video.VideoPlayer>>();
//            libraryMaterialMgr.InitLocalResVideoInfo((libresId, instid, component, res) =>
//            {
//                if (string.IsNullOrEmpty(libresId)) return;

//                List<UnityEngine.Video.VideoPlayer> compList = videoMap.ContainsKey(libresId) ? videoMap[libresId] : new List<UnityEngine.Video.VideoPlayer>();
//                compList.Add(component);
//                videoMap[libresId] = compList;

//                MediaLibraryFile.Instance.FindTargetMeidaFilePath(libresId, null, (v, path, url) =>
//                 {
//                     var temp = videoMap[libresId];
//                     for (int i = 0; i < temp.Count; i++)
//                     {
//                         temp[i].source = UnityEngine.Video.VideoSource.Url;
//                         temp[i].url = path;
//                     }
//                 });
//            });

//        }
//    }
//}