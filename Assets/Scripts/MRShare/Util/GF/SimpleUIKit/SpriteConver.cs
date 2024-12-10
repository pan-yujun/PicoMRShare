using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GF;

namespace GF.SimpleUIKit
{
    [RequireComponent(typeof(Image))]
    public class SpriteConver : MonoBehaviour, IConver
    {
        [SerializeField]
        private Sprite idleSprite;
        [SerializeField]
        private Sprite idleSprite2;//在背景是白色的时候，主页按钮更换成状态2
        [SerializeField]
        private Sprite hoverSprite;
        [SerializeField]
        private Sprite selectedSprite;
        [SerializeField]
        private Sprite clickSprite;
        [SerializeField]
        private Sprite disabledSprite;

        private Image targetImg;

        public void OnInit()
        {
            targetImg = transform.TryGetComp<Image>();
        }

        public void Idle()
        {
            SetImg(idleSprite);
        }
        /// <summary>
        /// 在背景是白色的时候，主页按钮更换成状态2
        /// </summary>
        public void Idle2()
        {
            SetImg(idleSprite2);
        }

        public void Hover()
        {
          //  SetImg(hoverSprite);
        }


        public void Selected()
        {
            SetImg(selectedSprite);
        }

        public void Pressed()
        {
            SetImg(clickSprite);
        }   

        public void Disabled()
        {
           // SetImg(disabledSprite);
        }

        protected void SetImg(Sprite sprite)
        {
            if (sprite != null)
                targetImg.sprite = sprite;
        }     
    }
}