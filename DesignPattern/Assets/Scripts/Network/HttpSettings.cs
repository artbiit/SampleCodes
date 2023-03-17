using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleCode
{
    public enum ServerTypes
    {
        Dev,
        Live,
        QA
    }
    public class HttpSettings : ScriptableObject
    {
        public ServerTypes ServerType = ServerTypes.Dev;   
        //Odin 혹은 SerializableDictionary 구현으로 인스펙터에 표현할 수 있도록 해야 함
        private Dictionary<ServerTypes, string> Servers = new Dictionary<ServerTypes, string>();
        private Dictionary<int, string> Apis = new Dictionary<int, string>();
        //전송 후 최소 대기 시간
        public float MinimumDelay = .1f;

        public string GetApi(int apiKey)
        {
            return $"{Servers[ServerType]}{Apis[apiKey]}";
        }

    }
}
