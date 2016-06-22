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
        public RestResponse NextExpectedResponse { get; set; }
        public int? NextExpectedStatusCode { get; set; }
        public Exception NextException { get; set; }

        public MockRestClient(TimeSpan? timeout = null) : base(timeout)
        {

        }

        public override Task<RestResponse> GetAsync(string uri, string basicAuthenticationEncoded, string sourceIp, IEnumerable<BasicKeyValuePair> queryParams = null, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            return Task.Run(() => CreateResponse());
        }

        protected override Task<RestResponse> PostAsync(string uri, string basicAuthenticationEncoded, HttpContent content, string sourceIp, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            return Task.Run(() => CreateResponse());
        }

        private RestResponse CreateResponse()
        {
            if (NextException != null)
                throw NextException;

            var response = NextExpectedResponse == null ? new RestResponse((HttpStatusCode)(NextExpectedStatusCode ?? 202), null) : NextExpectedResponse;

            NextExpectedResponse = null;
            NextExpectedStatusCode = null;
            NextException = null;

            return response;
        }
    }
}
