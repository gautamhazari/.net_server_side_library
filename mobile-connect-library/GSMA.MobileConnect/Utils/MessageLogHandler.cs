using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Utils
{
    public class MessageLogHandler : DelegatingHandler
    {
        public MessageLogHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.LogRequest();
            var response = await base.SendAsync(request, cancellationToken);
            response.LogResponse();
            return response;
        }
    }
}
