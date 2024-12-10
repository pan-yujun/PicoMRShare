namespace HoloShare
{
    /// <summary>
    /// 公共的消息名（多平台通用）
    /// </summary>
    public struct GMonoMsg
    {
        /// <summary>
        /// 更新点位信息
        /// 1.用户扫码时 2.点位信息有变动时
        /// </summary>
        public const string UPDATE_POINT_INFO = "UpdatePointInfo";

        public const string REF_POINT_INFO = "RefPointInfo";

        /// <summary>
        /// 更新管理员资源信息
        /// </summary>
        public const string UPDATE_RES_INFO = "UpdateResInfo";

        /// <summary>
        /// 更新点位数据结果
        /// </summary>
        public const string UPLOAD_POINT_DATA_RESULT = "UploadPointDataResult";

        /// <summary>
        /// 开关编辑模式
        /// </summary>
        public const string TOGGLE_EDIT_MODE = "ToggleEditMode";

        /// <summary>
        /// 删除目标场景数据
        /// </summary>
        public const string DEL_SCENE_DATA = "DelSceneData";

        /// <summary>
        /// 编辑场景
        /// </summary>
        public const string EDIT_SCENE = "Edit_Scene";

        public const string EDIT_SCENE_TOGETHER = "edit_scene_together";

        /// <summary>
        /// 登录请求
        /// </summary>
        public const string LOGIN_REQUEST = "LoginRequest";

        /// <summary>
        /// 登录结果
        /// </summary>
        public const string LOGIN_RESULT = "LoginResult";

        /// <summary>
        /// 开关启动页
        /// </summary>
        public const string TOGGLE_LAUCH_PAGE = "ToggleLauchPage";

        /// <summary>
        /// 提示用户更新应用
        /// </summary>
        public const string TIP_UPDATE_APP = "TipUpdateApp";

        /// <summary>
        /// 弹窗
        /// </summary>
        public const string SHOW_DIALOG = "ShowDialog";

        /// <summary>
        /// 解析二维码失败
        /// （扫描超时）
        /// </summary>
        public const string DECODE_QR_FAILED = "DecodeQRFailed";

        /// <summary>
        /// 识别失败
        /// （识别超时或下载识别图失败）
        /// </summary>
        public const string RECOG_FAILED = "RecogFailed";

        /// <summary>
        /// 停止扫描+识别流程
        /// </summary>
        public const string STOP_SCAN_AND_RECOG = "StopScanAndRecog";

        /// <summary>
        /// 扫描开始（扫码流程）
        /// </summary>
        public const string SCAN_START = "ScanStart";

        /// <summary>
        /// 扫描完成
        /// </summary>
        public const string SCAN_FINISH = "ScanFinish";

        /// <summary>
        /// 识别开始
        /// </summary>
        public const string RECOG_START = "RecogStart";

        /// <summary>
        /// 识别完成
        /// </summary>
        public const string RECOG_FINISH = "RecogFinish";

        /// <summary>
        /// 加载场景
        /// </summary>
        //public const string LOAD_SCENE = "LoadScene";

        /// <summary>
        /// 新建场景
        /// </summary>
        public const string CREATE_SCENE = "CreateScene";

        /// <summary>
        /// 新建场景 v1.1
        /// </summary>
        public const string CREATE_NEW_SCENE = "CreateNewScene";

        /// <summary>
        /// 扫码统计
        /// </summary>
        public const string SCAN_STATISTICS = "ScanStatistics";

        /// <summary>
        /// 删除场景
        /// </summary>
        public const string REMOVE_SCENE = "RemoveScene";

        /// <summary>
        /// 用户未登录或登录信息过期,请重新登录
        /// </summary>
        public const string USERINFO_EXPIRE = "10010";

        /// <summary>
        /// 账号其他在设备登录
        /// </summary>
        public const string ACCOUNTLOGIN_OTHER = "10012";

        /// <summary>
        /// 扫描次数已达上限
        /// </summary>
        public const string SCANECODE_LIMIT_MAX = "13035";

        /// <summary>
        /// 打开图标选择界面
        /// </summary>
        public const string ICONCHOOSE_OPEN_SOURCE = "OpenIconSource";

        /// <summary>
        /// 刷新加载进度
        /// </summary>
        public const string FRESHEN_LOAD_PROGRESS = "FreshenLoadProgress";

        /// <summary>
        /// 取消进度
        /// </summary>
        public const string CANCEL_LOAD_PROGRESS = "CancelLoadProgress";

        /// <summary>
        /// 离线模式
        /// </summary>
        public const string OFFLINE_LOAD = "OfflineLoad";
    }

    public struct PlayerPrefsKey
    {
        public const string ACCOUNT = "Account";
        public const string PASSWORD = "Password";
        public const string FIRST_LAUNCH_APP = "FirstLaunchAPP";
        public const string VALIDITY_TIME = "validitytime";
    }

    public struct AnimatorStr
    {
        /// <summary>
        /// 动画状态名
        /// </summary>
        public const string IDLE = "idle";

        /// <summary>
        /// 动画参数名
        /// </summary>
        public const string TOUCH = "Touch";

        /// <summary>
        /// 动画参数名
        /// </summary>
        public const string HOVER = "Hover";
    }

    public struct CaptureMsg
    {
        /// <summary>
        /// 拍照完成
        /// </summary>
        public const string PHOTOGRAPH_FINISH = "PhotographFinish";

        /// <summary>
        /// 录像完成
        /// </summary>
        public const string RECORD_FINISH = "RecordFinish";
    }

    public struct AudioName
    {
        public const string MOVE_START = "Move_Start";
        public const string MOVE_END = "Move_End";
        public const string ROTATE_START = "Rotate_Start";
        public const string ROTATE_STOP = "Rotate_Stop";
        public const string SCALE_START = "Scale_Start";
        public const string SCALE_STOP = "Scale_Stop";
        public const string FINISH_SCAN = "Finish_Scan";
    }

    public struct SysConst
    {
        public const string CAPTURE_IMG_FULLNAME = "1.jpg";
        public const string PROJECT_NAME = "HoloShare";
        public const string HOLOLENS = "HoloLens";
        public const string ANDROID = "Android";
        public const string IOS = "iOS";
        public const string MOBILE = "Mobile";
    }

    /// <summary>
    /// 物体标签
    /// </summary>
    public struct Tag
    {
        /// <summary>
        /// “ 独秀 ” 互动
        /// 1.意为互动流程比较长的互动，例如有语音介绍的互动。
        /// 2.当“ 独秀 ” 互动触发时，它将重置上一个“ 独秀 ”互动的Animator回idle状态
        /// </summary>
        public const string SINGLE_SHOW = "SingleShow";
    }
}