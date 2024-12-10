
namespace Assets.PICOSDKWrapper
{
    /// <summary>
    /// PICOSDKWrapper用的
    /// </summary>
    public partial class DispatcherMsg
    {
        public const uint PICOSDKWrapper = 10000;
        public const uint LeftTriggeStarted = PICOSDKWrapper + 1;// LeftTrigger按下
        public const uint LeftTriggePerformed = PICOSDKWrapper + 2;// LeftTrigger按下
        public const uint LeftTriggeCanceled = PICOSDKWrapper + 3;// LeftTrigger取消
        public const uint RightTriggeStarted = PICOSDKWrapper + 4;// RightTrigger按下
        public const uint RightTriggePerformed = PICOSDKWrapper + 5;// RightTrigger按下
        public const uint RightTriggeCanceled = PICOSDKWrapper + 6;// RightTrigger取消


    }
}
