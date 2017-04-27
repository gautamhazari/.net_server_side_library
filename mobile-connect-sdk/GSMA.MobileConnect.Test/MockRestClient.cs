using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Linq;

namespace GSMA.MobileConnect.Test
{
    public class MockRestClient : RestClient
    {
        private readonly object _locker = new object();
        private bool _expectParallelRequests = false;
        public Queue<object> ResponseQueue { get; private set; }

        public List<Tuple<string, object>> ParallelResponses { get; private set; }

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

        public MockRestClient(TimeSpan? timeout = null, TimeSpan? headlessTimeout = null) : base(timeout, headlessTimeout)
        {
            ResponseQueue = new Queue<object>();
            ParallelResponses = new List<Tuple<string, object>>();
        }

        public override Task<RestResponse> GetAsync(string uri, RestAuthentication authentication, string xRedirect, string sourceIp, IEnumerable<BasicKeyValuePair> queryParams = null, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            return Task.Run(() => HandleResponse(uri));
        }

        protected override Task<RestResponse> PostAsync(string uri, RestAuthentication authentication, HttpContent content, string xRedirect, string sourceIp, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            return Task.Run(() => HandleResponse(uri));
        }

        public void QueueResponse(RestResponse response)
        {
            ResponseQueue.Enqueue(response);
        }

        public void QueueResponse(Exception ex)
        {
            ResponseQueue.Enqueue(ex);
        }

        public void QueueParallelResponses(params Tuple<string, object>[] responses)
        {
            ParallelResponses.AddRange(responses);
            _expectParallelRequests = true;
        }

        public void QueueResponse(int? status)
        {
            ResponseQueue.Enqueue(status);
        }

        private RestResponse HandleResponse(string uri)
        {
            return _expectParallelRequests ? HandleInParallel(uri) : HandleInSequence();
        }

        private RestResponse HandleInSequence()
        {
            if (ResponseQueue.Count == 0)
            {
                throw new ArgumentOutOfRangeException("No responses queued");
            }

            var nextQueuedResponse = ResponseQueue.Dequeue();
            return CreateResponse(nextQueuedResponse);
        }

        private RestResponse HandleInParallel(string uri)
        {
            lock (_locker)
            {
                if (ParallelResponses.Count == 0)
                {
                    _expectParallelRequests = true;
                    return HandleResponse(uri);
                }

                var response = ParallelResponses.FirstOrDefault(x => x.Item1 == uri);

                if (response == null)
                {
                    throw new ArgumentOutOfRangeException($"No response for {uri}");
                }

                ParallelResponses.Remove(response);
                return CreateResponse(response.Item2);
            }
        }

        private static RestResponse CreateResponse(object nextResponse)
        {
            var nextException = nextResponse as Exception;

            if (nextException != null)
                throw nextException;

            var nextRestResponse = nextResponse as RestResponse;
            var nextStatusCode = nextResponse as int?;
            var response = nextResponse == null ? new RestResponse((HttpStatusCode)(nextStatusCode ?? 202), null) : nextRestResponse;

            return response;
        }
    }
}
