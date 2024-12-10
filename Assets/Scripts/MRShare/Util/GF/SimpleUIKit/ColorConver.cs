using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GF.SimpleUIKit
{
    //[RequireComponent(typeof(Image))]
    public class ColorConver : MonoBehaviour, IConver
    {
        [SerializeField]
        private Color idleColor = Color.white;
        [SerializeField]
        private Color hoverColor = Color.white;
        [SerializeField]
        private Color selectedColor = Color.white;
        [SerializeField]
        private Color pressedColor = Color.white;
        [SerializeField]
        private Color disabledColor = Color.white;

        private Image targetImg;
        public  GameObject XuanzhongImg;

        private RawImage rawImg;

        public void OnInit()
        {
            targetImg = transform.TryGetComp<Image>();
            rawImg = transform.TryGetComp<RawImage>();
         //   XuanzhongImg = transform.TryFind("XuanzhongImg").gameObject;
        }

        public void Idle()
        {
            SetColor(idleColor);
            if (XuanzhongImg != null)
            {
                XuanzhongImg.SetActive(false);
            }
        }
        public void Idle2()
        {
            SetColor(idleColor);
        }


        public void Hover()
        {
            SetColor(hoverColor);
            if (XuanzhongImg != null)
            {
                XuanzhongImg.SetActive(false);
            }
        }

        public void Pressed()
        {
            SetColor(pressedColor);
            if (XuanzhongImg != null)
            {
                XuanzhongImg.SetActive(false);
            }
        }

        public void Selected()
        {
            SetColor(selectedColor);
            if (XuanzhongImg!=null)
            {
                XuanzhongImg.SetActive(true);
            }
        }

        public void Disabled()
        {
            SetColor(disabledColor);
            if (XuanzhongImg != null)
            {
                XuanzhongImg.SetActive(false);
            }
        }

        protected void SetColor(Color color)
        {
            if (targetImg != null)
                targetImg.color = color;

            if (rawImg != null)
                rawImg.color = color;
        }

       
    }
}