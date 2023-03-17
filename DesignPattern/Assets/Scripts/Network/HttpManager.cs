using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleCode
{
    #region ������ �ڵ�
    public enum HttpMethods
    {
        Post,
        Get,
    }

    public class HttpRequest
    {
        public HttpResponse Response { get; private set; }
        public byte[] RawData;

        public HttpRequest(System.Uri uri, HttpMethods methods , System.Action<HttpRequest, HttpResponse> onResponsed)
        {

        }
        
        public void Send() {; }
    }

    public class HttpResponse
    {
        public int StatusCode;
        public string DataAsText;
    }

    public class HttpError
    {
        public System.Exception Exception;
        public HttpRequest Request;
    }

    public class HttpOptions
    {
        public int ApiKey;
        public HttpMethods Method;
        public RequestData Data;
        public System.Action<ResponseData> OnComplete;
        public System.Action<HttpError> OnError;
    }

    /// <summary>
    /// ��� �޾Ƽ� ���
    /// </summary>
    [System.Serializable]
    public class RequestData
    {

        public short EncryptionKey;
        
    }

    /// <summary>
    /// ��� �޾Ƽ� ���
    /// </summary>
    [System.Serializable]
    public class ResponseData
    {
        public int ResponseCode;
        public string ResponseMessage;
    }

    #endregion


    public partial class HttpManager : Singleton<HttpManager>
    {

        private Queue<HttpRequest> RequestQueue;
        [SerializeField]
        protected HttpSettings settings;

        #region MonoBehaviours
        protected override void Awake()
        {
            base.Awake();
            RequestQueue = new Queue<HttpRequest>();
            StartCoroutine(Sender());
        }
        #endregion

        #region Methods

        public HttpRequest CreateRequest<T> (HttpOptions options) where T : ResponseData
        {
            HttpRequest request = new HttpRequest(new System.Uri(settings.GetApi(options.ApiKey)), options.Method, (req, res) => {

                if (IsAvailableResponse(req, res))
                {
                   T responseData = JsonUtility.FromJson<T>(res.DataAsText);

                    options.OnComplete?.Invoke(responseData);
                }
                else
                {
                    HttpError httpError = new HttpError();
                    httpError.Request = req;
                    httpError.Exception = new System.Exception("���� �ۼ�");
                    options.OnError(httpError);
                }
            });

            request.RawData= System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(options.Data));
            RequestQueue.Enqueue(request);

            return request;
        }

        private bool IsAvailableResponse(HttpRequest request, HttpResponse response)
        {
            if(request == null || response == null || (response.StatusCode < 200 && response.StatusCode > 204) || string.IsNullOrWhiteSpace(response.DataAsText))
            {
                //�ʿ��� ���� ó�� �۾�
                return false;
            }


            return true;
        }

        //UniTask ���� ������ ��ü ����
        private IEnumerator Sender()
        {
            var wait = new WaitForSecondsRealtime(.1f); 
            while (true)
            {
                if(RequestQueue.Count <= 0)
                {
                    yield return null;
                    continue;
                }

                //���� �� ����
                RequestQueue.Dequeue().Send();
                yield return wait;
            }
        }
        #endregion
    }
}
