using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace GSMA.MobileConnect.Test
{
    public class MockRestClient : RestClient
    {
        public Queue<object> ResponseQueue { get; private set; }
        public RestResponse NextExpectedResponse
        {
            get { return ResponseQueue.Count == 0 ? null : ResponseQueue.Peek() as RestResponse; }
            set
            {
                ResponseQueue.Clear();
                QueueResponse(value);
            }
        }
        public int? NextExpectedStatusCode
        {
            get { return ResponseQueue.Count == 0 ? null : ResponseQueue.Peek() as int?; }
            set
            {
                ResponseQueue.Clear();
                QueueResponse(value);
            }
        }
        public Exception NextException
        {
            get { return ResponseQueue.Count == 0 ? null : ResponseQueue.Peek() as Exception; }
            set
            {
                ResponseQueue.Clear();
                QueueResponse(value);
            }
        }

        public MockRestClient(TimeSpan? timeout = null) : base(timeout)
        {
            ResponseQueue = new Queue<object>();
        }

        public override Task<RestResponse> GetAsync(string uri, RestAuthentication authentication, string sourceIp, IEnumerable<BasicKeyValuePair> queryParams = null, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            return Task.Run(() => CreateResponse());
        }

        protected override Task<RestResponse> PostAsync(string uri, RestAuthentication authentication, HttpContent content, string sourceIp, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            return Task.Run(() => CreateResponse());
        }

        public void QueueResponse(RestResponse response)
        {
            ResponseQueue.Enqueue(response);
        }

        public void QueueResponse(Exception ex)
        {
            ResponseQueue.Enqueue(ex);
        }

        public void QueueResponse(int? status)
        {
            ResponseQueue.Enqueue(status);
        }

        private RestResponse CreateResponse()
        {
            if(ResponseQueue.Count == 0)
            {
                throw new ArgumentOutOfRangeException("No responses queued");
            }

            var nextQueuedResponse = ResponseQueue.Dequeue();
            var nextException = nextQueuedResponse as Exception;

            if (nextException != null)
                throw nextException;

            var nextResponse = nextQueuedResponse as RestResponse;
            var nextStatusCode = nextQueuedResponse as int?;
            var response = nextResponse == null ? new RestResponse((HttpStatusCode)(nextStatusCode ?? 202), null) : nextResponse;

            return response;
        }
    }
}
