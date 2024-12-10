using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GF.SimpleUIKit
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BaseUIPanel : GMono, IInit
    {
        private CanvasGroup canvasGroup;

        public void ToggleInteract(bool b)
        {
            if (canvasGroup != null)
                canvasGroup.blocksRaycasts = b;
        }

        public void SetAlpha(float a)
        {
            canvasGroup.alpha = a;
        }

        public virtual void OnInit()
        {
            canvasGroup = transform.TryGetComp<CanvasGroup>();
        }

        public virtual void OnShow()
        {
            Show();
        }

        public virtual void OnPause()
        {

        }

        public virtual void OnResume()
        {

        }

        public virtual void OnHide()
        {
            Hide();
        }

        protected override void OnBeforeDestroy()
        {

        }


    }
}
