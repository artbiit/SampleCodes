using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleCode
{

    #region 예제용 코드
    public class SignInRequest : RequestData
    {
        public string Id;
        public string Pw;
    }

    public class SignInResponse : ResponseData
    {

    }

    #endregion
    public partial class HttpManager
    {
       public static void SignIn(string id, string pw)
        {
            HttpOptions options = new HttpOptions
            {
                Method = HttpMethods.Post,
                OnComplete = (data) => { Debug.Log("로그인 성공"); },
                OnError = (error) => { Debug.LogError(error.Exception); },
                ApiKey = -1,
            };

            options.Data = new SignInRequest { Id = id, Pw = pw };
            Instance.CreateRequest<SignInResponse>(options);
        }
    }
}
