using System;

namespace GF
{
    public class GTool
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static string GetTime(string format)
        {
            // yyyy_MM_dd_HH_mm_ss 2022_01_19_11_30_23
            string ts = DateTime.Now.ToString(format);
            return ts;
        }
    }
}