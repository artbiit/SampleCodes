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
        //Odin Ȥ�� SerializableDictionary �������� �ν����Ϳ� ǥ���� �� �ֵ��� �ؾ� ��
        private Dictionary<ServerTypes, string> Servers = new Dictionary<ServerTypes, string>();
        private Dictionary<int, string> Apis = new Dictionary<int, string>();
        //���� �� �ּ� ��� �ð�
        public float MinimumDelay = .1f;

        public string GetApi(int apiKey)
        {
            return $"{Servers[ServerType]}{Apis[apiKey]}";
        }

    }
}
