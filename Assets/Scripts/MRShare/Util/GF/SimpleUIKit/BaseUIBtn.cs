using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using GF;
using UnityEngine.EventSystems;

namespace GF.SimpleUIKit
{
    public abstract class BaseUIBtn : GMono, IInteract, IInit
    {
        public UnityEvent M_OnClick = new UnityEvent();
        public UnityEvent M_OnEnter = new UnityEvent();
        public UnityEvent M_OnExit = new UnityEvent();
        public UnityEvent M_OnDown = new UnityEvent();
        public UnityEvent M_OnUp = new UnityEvent();

        protected bool interactable = true;

        public void SetInteractable(bool b)
        {
            interactable = b;

            if (interactable == true)
                conver.Idle();
            else if (interactable == false)
                conver.Disabled();
        }

        protected IConver conver;

        public virtual void OnInit()
        {
            conver = transform.TryGetComp<IConver>();

            conver?.OnInit();
            conver?.Idle();
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (interactable == false) return;

            M_OnClick?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (interactable == false) return;

            M_OnEnter?.Invoke();

#if !(UNITY_ANDROID || UNITY_IOS) 
            conver?.Hover();
#endif
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (interactable == false) return;

            M_OnExit?.Invoke();

#if !(UNITY_ANDROID || UNITY_IOS)
            conver?.Idle();//不知道之前为什么注释，20230203打开的注释
#endif
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (interactable == false) return;

            M_OnDown?.Invoke();

#if !(UNITY_ANDROID || UNITY_IOS) 
            conver?.Pressed();
#endif
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (interactable == false) return;

            M_OnUp?.Invoke();

            // conver?.Idle();
        }
    }

    public interface IInteract : IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {

    }

    public interface IConver : IInit
    {
        void Idle();

        void Idle2();

        void Hover();

        void Pressed();

        void Selected();

        void Disabled();
    }

}