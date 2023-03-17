using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleCode
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        protected virtual void Awake()
        {
            if (Instance.IsRefNull())
            {
                Destroy(this);
                Debug.LogError($"Instance is not Null : {typeof(T)}");

            }
            else
            {
                Instance = (T)FindAnyObjectByType<T>();
            }
        }


    }
}