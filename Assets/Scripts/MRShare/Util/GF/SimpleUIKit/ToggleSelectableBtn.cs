namespace GF.SimpleUIKit
{
    /// <summary>
    /// 可取消选中的可选按钮
    /// </summary>
    public class ToggleSelectableBtn : SelectableBtn
    {
        public SpriteConver[] allButton;
        protected override void SelectBtn()
        {
          //  if (!SlidePanelBase.IsComplete) return;

            if (isSelected)
            {
                Deselect();
                for (int i = 0; i < allButton.Length; i++)
                {
                    allButton[i].Idle();
                }
               
            }
            else
            {
                // Todo
                //if (SingleSelector.curSelect != null)
                //    ((SingleSelector.curSelect) as ToggleSelectableBtn).DeselectWithoutNotify();
                if (SingleSelector != null)
                    SingleSelector.SelectItem(this);
                for (int i = 0; i < allButton.Length; i++)
                {
                    if (allButton[i]!=this.GetComponent<SpriteConver>())
                    {
                        allButton[i].Idle2();
                    }
                   
                }
             

            }                
        }
        /// <summary>
        /// 加在扫码以及按钮上面，确保所有UI返回到idle状态 需要优化
        /// </summary>
        public void ReBtnUI()
        {
            for (int i = 0; i < allButton.Length; i++)
            {
                allButton[i].Idle();
            }
        }
        /// <summary>
        /// 加在个人、点位按钮上面，确保所有UI返回到idle2状态 需要优化
        /// </summary>
        public void ReBtnUIIdle2()
        {
            for (int i = 0; i < allButton.Length; i++)
            {
                if (allButton[i] != this.GetComponent<SpriteConver>())
                {
                    allButton[i].Idle2();
                }
                else
                {
                    allButton[i].Selected();
                }
            }
        }
    }
}