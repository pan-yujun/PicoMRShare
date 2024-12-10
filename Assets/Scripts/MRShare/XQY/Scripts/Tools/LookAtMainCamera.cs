using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XTools.UnityEngine
{
    public class LookAtMainCamera : MonoBehaviour
    {
        public bool OnXOZ = true;
        public bool IsReverseForward = false;

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            this.transform.LookAt(Camera.main.transform);
            if (OnXOZ)
            {
                this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y + (IsReverseForward ? 180 : 0), this.transform.eulerAngles.z);
            }
        }
    }
}