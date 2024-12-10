namespace GF.SimpleUIKit
{
    public class CommonBtn : BaseUIBtn
    {
        public SpriteConver[] allButton;
        protected override void OnBeforeDestroy()
        {
            
        }
        /// <summary>
        /// 加在拍照按钮上面，确保所有UI返回到idle2状态 需要优化
        /// </summary>
        public void ReBtnUIIdle2()
        {
            for (int i = 0; i < allButton.Length; i++)
            {
                if (allButton[i] != this.GetComponent<SpriteConver>())
                {
                    allButton[i].Idle2();
                }
            }
        }
    }
}