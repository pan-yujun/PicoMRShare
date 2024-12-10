using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GF.SimpleUIKit;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace GF.SimpleUIKit
{
    /// <summary>
    /// 可选择按钮
    /// </summary>
    public class SelectableBtn : BaseUIBtn, ISelectable
    {
        public UnityEvent M_OnSelect = new UnityEvent();
        public UnityEvent M_OnDeselect = new UnityEvent();

        private SingleSelector singleSelector;
        public SingleSelector SingleSelector { get { return singleSelector; } set { singleSelector = value; } }

        public bool isSelected = false;
        protected virtual void SelectBtn()
        {
            SingleSelector.SelectItem(this);
        }

        private void OnSelect()
        {
            isSelected = true;

            interactable = false;

            conver.Selected();
        }

        private void OnDeselect()
        {
            isSelected = false;

            interactable = true;
            conver.Idle();
        }
        public void OnDeselect_Idle2()
        {
           // isSelected = false;

          //  interactable = true;

            conver.Idle2();
        }

        public void Select()
        {
            OnSelect();

            M_OnSelect?.Invoke();
        }

        public void SelectWithoutNotify()
        {
            OnSelect();
        }

        public void Deselect()
        {
            OnDeselect();

            M_OnDeselect?.Invoke();
        }

        public void DeselectWithoutNotify()
        {
            OnDeselect();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            SelectBtn();
        }

        protected override void OnBeforeDestroy()
        {

        }
    }
}