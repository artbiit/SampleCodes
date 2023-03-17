using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleCode
{
    public static class Extentions
    {   
        /// <summary>
        /// 실질적 null인지 확인하는 용
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsRefNull(this UnityEngine.Object obj)
        {
            return System.Object.ReferenceEquals(obj, null);
        }
    }
}