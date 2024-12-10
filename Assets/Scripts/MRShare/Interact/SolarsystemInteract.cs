//using HoloSupExp;
//using Microsoft.MixedReality.Toolkit.UI;
//using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
//using System.Collections.Generic;
//using UnityEngine;

//namespace HoloShare
//{
//    public class SolarsystemInteract : MonoBehaviour, IPreview,IEditModeToggle
//    {
//        public List<GameObject> planets;

//        public List<PlanetTouch> touchs;

//        public string curPlanetName = "";

//        public bool IsPreview
//        {
//            set
//            {
//                Toggle(!value);
//            }
//        }

//        public void OnEditModeToggle(bool toggle)
//        {
//            Toggle(toggle);
//        }

//        BoundsControl[] boundsControls;
//        ObjectManipulator[] objectManipulators;

//        private void Awake()
//        {
//            for (int i = 0; i < touchs.Count; i++)
//            {
//                string name = touchs[i].name;
//                touchs[i].onTouch.AddListener(() => ShowPlanet(name));
//            }

//            boundsControls = GetComponentsInChildren<BoundsControl>();
//            objectManipulators = GetComponentsInChildren<ObjectManipulator>();
//        }

        

//        public void Toggle(bool toggle)
//        {
//            foreach (BoundsControl boundsControl in boundsControls)
//            {
//                boundsControl.enabled = toggle;
//            }

//            foreach (ObjectManipulator objectManipulator in objectManipulators)
//            {
//                objectManipulator.enabled = toggle;
//            }
//        }

//        public void ShowPlanet(string name)
//        {
//            if (name.Equals(curPlanetName) == true) return;

//            for (int i = 0; i < planets.Count; i++)
//            {
//                if (name.Equals(planets[i].name))
//                {
//                    planets[i].SetActive(true);
//                }
//                else
//                {
//                    planets[i].SetActive(false);
//                }
//            }

//            for (int i = 0; i < touchs.Count; i++)
//            {
//                var effect = touchs[i].transform.Find("lockmark");

//                if (name.Equals(touchs[i].name))
//                {
//                    if (effect != null)
//                        effect.gameObject.SetActive(true);
//                }
//                else
//                {
//                    if (effect != null)
//                        effect.gameObject.SetActive(false);
//                }
//            }

//            curPlanetName = name;
//        }

        
//    }
//}