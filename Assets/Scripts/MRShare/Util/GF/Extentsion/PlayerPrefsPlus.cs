using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GF
{
    public class PlayerPrefsPlus : PlayerPrefs
    {
        public static bool GetBool(string key)
        {
            return GetInt(key) == 1 ? true : false;
        }

        public static bool GetBool(string key, bool defaultValue)
        {
            int myDefaultValue = defaultValue ? 1 : 0;

            if (!HasKey(key))
            {
                SetInt(key, myDefaultValue);
            }

            return GetInt(key) == 1 ? true : false;
        }

        public static void SetBool(string key, bool value)
        {
            if (value)
            {
                SetInt(key, 1);
            }
            else
            {
                SetInt(key, 0);
            }
        }
    }
}