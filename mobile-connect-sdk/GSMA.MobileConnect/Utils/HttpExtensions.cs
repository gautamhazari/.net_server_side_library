using Newtonsoft.Json;
using System.Net.Http;

namespace GSMA.MobileConnect.Utils
{
    public static class HttpExtensions
    {
        public static void LogRequest(this HttpRequestMessage requestMessage)
        {
            var content = string.Empty;
            if (requestMessage.Content != null)
            {
                content = requestMessage.Content.ReadAsStringAsync().Result;
            }

            var path = requestMessage.RequestUri.PathAndQuery;
            Log.Info($"Request: [{path}] {requestMessage.Method.Method} {content} " +
                $"headers: {JsonConvert.SerializeObject(requestMessage.Headers)}");
        }

        public static void LogResponse(this HttpResponseMessage responseMessage)
        {
            var logText = responseMessage.Content != null
                ? responseMessage.Content.ReadAsStringAsync().Result
                : responseMessage.StatusCode.ToString();

            Log.Info($"Response: {logText}");
        }
    }
}
