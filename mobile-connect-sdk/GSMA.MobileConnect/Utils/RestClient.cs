using GSMA.MobileConnect.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Wrapper for Http requests, returning a simple normalised response object
    /// </summary>
    public class RestClient : IDisposable
    {
        private bool _disposed;
        private readonly HttpClient _client;
        private readonly HttpClient _noRedirectClient;

        /// <summary>
        /// Creates a new instance of RestClient with optional timeout specified
        /// </summary>
        /// <param name="timeout">Timeout applied to all requests</param>
        /// <param name="headlessTimeout">Timeout applied to headless requests</param>
        public RestClient(TimeSpan? timeout, TimeSpan? headlessTimeout)
        {
            var handler = new MessageLogHandler(new HttpClientHandler { UseCookies = false });
            _client = new HttpClient(handler, true);
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = timeout ?? TimeSpan.FromSeconds(30);

            var noRedirectHandler = new HttpClientHandler { UseCookies = false, AllowAutoRedirect = false };
            _noRedirectClient = new HttpClient(noRedirectHandler, true);
            _noRedirectClient.Timeout = headlessTimeout ?? TimeSpan.FromMinutes(2);
        }

        /// <summary>
        /// Creates a new instance of RestClient with default timeout of 30 seconds and headless timeout of 2 minutes
        /// </summary>
        public RestClient() : this(null, null) { }

        private HttpRequestMessage CreateRequest(HttpMethod method, Uri uri, string xRedirect, RestAuthentication authentication, string sourceIp, IEnumerable<BasicKeyValuePair> cookies)
        {
            var message = new HttpRequestMessage(method, uri);

            if (cookies != null && cookies.Any())
            {
                var cookieKeyValues = cookies.Select(x => string.Format("{0}={1}", x.Key, x.Value));
                var cookieString = string.Join("; ", cookieKeyValues);
                message.Headers.Add("Cookie", cookieString);
            }

            if (!string.IsNullOrEmpty(sourceIp))
            {
                message.Headers.Add(Headers.X_SOURCE_IP, sourceIp);
            }

            if (authentication != null)
            {
                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authentication.Scheme, authentication.Parameter);
            }

            if (xRedirect != null)
            {
                message.Headers.Add(Headers.X_REDIRECT, xRedirect);
            }
            else
            {
                message.Headers.Add(Headers.X_REDIRECT, Constants.Parameters.X_REDIRECT_DEFAULT_VALUE);
            }

            return message;
        }

        private HttpRequestMessage CreateDiscoveryRequest(HttpMethod method, Uri uri, string xRedirect, RestAuthentication authentication, string sourceIp, IEnumerable<BasicKeyValuePair> cookies)
        {
            var message = CreateRequest(method, uri, xRedirect, authentication, sourceIp, cookies);
            message.Headers.Add(Headers.SDK_VERSION, VersionUtils.GetSDKVersion());
            return message;
        }

        /// <summary>
        /// Executes a HTTP GET to the supplied uri with optional basic auth, cookies and query params
        /// </summary>
        /// <param name="uri">Base uri of GET request</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="xRedirect">x-Redirect header(if identified)</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>       
        /// <param name="queryParams">Query params to be added to the base url (if required)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> GetAsync(string uri, RestAuthentication authentication, string xRedirect = "APP", string sourceIp = null, IEnumerable<BasicKeyValuePair> queryParams = null, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            UriBuilder builder = new UriBuilder(uri);

            builder.AddQueryParams(queryParams);

            var request = CreateRequest(HttpMethod.Get, builder.Uri, xRedirect, authentication, sourceIp, cookies);
            var response = await _client.SendAsync(request);

            return await CreateRestResponse(response);
        }
        
        /// <summary>
        /// Executes a HTTP GET to the supplied uri with optional basic auth, cookies and query params
        /// </summary>
        /// <param name="uri">Base uri of GET request</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="xRedirect">x-Redirect header(if identified)</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>       
        /// <param name="queryParams">Query params to be added to the base url (if required)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<String> GetAsyncWithRedirect(string uri, RestAuthentication authentication, MobileConnectRequestOptions requestOptions, string xRedirect = "APP", string sourceIp = null, IEnumerable<BasicKeyValuePair> queryParams = null, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            UriBuilder builder = new UriBuilder(uri);

            builder.AddQueryParams(queryParams);

            var request = CreateRequest(HttpMethod.Get, builder.Uri, xRedirect, authentication, sourceIp, cookies);
            var response = await _client.SendAsync(request);

            return response.RequestMessage.RequestUri.ToString();
        }

        /// <summary>
        /// Executes a HTTP GET to the supplied uri with optional basic auth, cookies and query params
        /// </summary>
        /// <param name="uri">Base uri of GET request</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="xRedirect">x-Redirect header(if identified)</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>       
        /// <param name="queryParams">Query params to be added to the base url (if required)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> GetDiscoveryAsync(string uri, RestAuthentication authentication, string xRedirect = "APP", string sourceIp = null, IEnumerable<BasicKeyValuePair> queryParams = null, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            UriBuilder builder = new UriBuilder(uri);

            builder.AddQueryParams(queryParams);

            var request = CreateDiscoveryRequest(HttpMethod.Get, builder.Uri, xRedirect, authentication, sourceIp, cookies);
            var response = await _client.SendAsync(request);

            return await CreateRestResponse(response);
        }

        /// <summary>
        /// Executes a HTTP POST to the supplied uri with x-www-form-urlencoded content and optional cookies
        /// </summary>
        /// <param name="uri">Base uri of the POST</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="formData">Form data to be added as POST content</param>
        /// <param name="xRedirect">x-Redirect header(if identified)</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> PostAsync(string uri, RestAuthentication authentication, IEnumerable<BasicKeyValuePair> formData, string sourceIp, string xRedirect, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            var content = new FormUrlEncodedContent(formData.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => new KeyValuePair<string, string>(x.Key, x.Value)));
            return await PostAsync(uri, authentication, content, sourceIp, xRedirect, cookies);
        }

        /// <summary>
        /// Executes a HTTP POST to the supplied uri with application/json content and optional cookies
        /// </summary>
        /// <param name="uri">Base uri of the POST</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="content">Object to be serialized as JSON for POST content</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="xRedirect">X-Redirect header value</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> PostAsync(string uri, RestAuthentication authentication, object content, string sourceIp, string xRedirect = Parameters.X_REDIRECT_DEFAULT_VALUE, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            var json = JsonConvert.SerializeObject(content);
            return await PostAsync(uri, authentication, json, "application/json", sourceIp, xRedirect, cookies);
        }

        /// <summary>
        /// Executes a HTTP POST to the supplied uri with the supplied content type and content, with optional cookies
        /// </summary>
        /// <param name="uri">Base uri of the POST</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="content">Content of the POST request</param>
        /// <param name="contentType">Content type of the POST request</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> PostAsync(string uri, RestAuthentication authentication, string content, string contentType, string sourceIp, string xRedirect = "APP", IEnumerable<BasicKeyValuePair> cookies = null)
        {
            return await PostAsync(uri, authentication, new StringContent(content, Encoding.UTF8, contentType), sourceIp, xRedirect, cookies);
        }

        /// <summary>
        /// Executes a HTTP POST to the supplied uri with the supplied HttpContent object, with optional cookies. Used as the base for other PostAsync methods.
        /// </summary>
        /// <param name="uri">Base uri of the POST</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="content">Content of the POST request</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns></returns>
        protected virtual async Task<RestResponse> PostAsync(string uri, RestAuthentication authentication, HttpContent content, string sourceIp, string xRedirect, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            var request = CreateRequest(HttpMethod.Post, new Uri(uri), xRedirect, authentication, sourceIp, cookies);
            request.Content = content;
            var response = await _client.SendAsync(request);

            return await CreateRestResponse(response);
        }

        /// <summary>
        /// Executes a HTTP POST to the supplied uri with x-www-form-urlencoded content and optional cookies
        /// </summary>
        /// <param name="uri">Base uri of the POST</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="formData">Form data to be added as POST content</param>
        /// <param name="xRedirect">x-Redirect header(if identified)</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> PostDiscoveryAsync(string uri, RestAuthentication authentication, IEnumerable<BasicKeyValuePair> formData, string sourceIp, string xRedirect, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            var content = new FormUrlEncodedContent(formData.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => new KeyValuePair<string, string>(x.Key, x.Value)));
            return await PostDiscoveryAsync(uri, authentication, content, sourceIp, xRedirect, cookies);
        }

        /// <summary>
        /// Executes a HTTP POST to the supplied uri with application/json content and optional cookies
        /// </summary>
        /// <param name="uri">Base uri of the POST</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="content">Object to be serialized as JSON for POST content</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="xRedirect">X-Redirect header value</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> PostDiscoveryAsync(string uri, RestAuthentication authentication, object content, string sourceIp, string xRedirect = Parameters.X_REDIRECT_DEFAULT_VALUE, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            var json = JsonConvert.SerializeObject(content);
            return await PostDiscoveryAsync(uri, authentication, json, "application/json", sourceIp, xRedirect, cookies);
        }

        /// <summary>
        /// Executes a HTTP POST to the supplied uri with the supplied content type and content, with optional cookies
        /// </summary>
        /// <param name="uri">Base uri of the POST</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="content">Content of the POST request</param>
        /// <param name="contentType">Content type of the POST request</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> PostDiscoveryAsync(string uri, RestAuthentication authentication, string content, string contentType, string sourceIp, string xRedirect = "APP", IEnumerable<BasicKeyValuePair> cookies = null)
        {
            return await PostDiscoveryAsync(uri, authentication, new StringContent(content, Encoding.UTF8, contentType), sourceIp, xRedirect, cookies);
        }

        /// <summary>
        /// Executes a HTTP POST to the supplied uri with the supplied HttpContent object, with optional cookies. Used as the base for other PostAsync methods.
        /// </summary>
        /// <param name="uri">Base uri of the POST</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="content">Content of the POST request</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns></returns>
        protected virtual async Task<RestResponse> PostDiscoveryAsync(string uri, RestAuthentication authentication, HttpContent content, string sourceIp, string xRedirect, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            var request = CreateDiscoveryRequest(HttpMethod.Post, new Uri(uri), xRedirect, authentication, sourceIp, cookies);
            request.Content = content;
            var response = await _client.SendAsync(request);

            return await CreateRestResponse(response);
        }

        private async Task<RestResponse> CreateRestResponse(HttpResponseMessage response)
        {
            var headers = response.Headers.Select(x => new BasicKeyValuePair(x.Key, string.Join(",", x.Value))).ToList();
            var restResponse = new RestResponse { StatusCode = response.StatusCode, ReasonPhrase = response.ReasonPhrase, Headers = headers };

            restResponse.Content = await response.Content.ReadAsStringAsync();

            return restResponse;
        }

        /// <summary>
        /// Attempts to follow a redirect path until a concrete url is loaded or the expectedRedirectUrl is reached
        /// </summary>
        /// <param name="targetUrl">Target uri to attempt a HTTP GET</param>
        /// <param name="expectedRedirectUrl">Redirect url expected, if a redirect with this location is hit the absolute uri of the location will be returned</param>
        /// <param name="pollFrequencyInMs"></param>
        /// <param name="maxRedirects"></param>
        /// <param name="cancellationToken">Cancellation token to allow cancellation of long running request if required</param>
        /// <returns>Final redirected url</returns>
        public async Task<Uri> GetFinalRedirect(string targetUrl, string expectedRedirectUrl, int pollFrequencyInMs, int maxRedirects, CancellationToken cancellationToken = default(CancellationToken))
        {
            var nextUrl = new Uri(targetUrl);
            var numRedirects = 0;

            while (NotArrivedAtExpectedUrl(nextUrl, expectedRedirectUrl))
            {
                if (numRedirects > maxRedirects)
                {
                    throw new HttpRequestException("Stuck in redirect loop");
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }
                var response = await _noRedirectClient.GetAsync(nextUrl, cancellationToken);
                numRedirects++;
                if (response.Headers.Location == null)
                {
                    // This may be due to a defect in the gateway. Sometimes instead of a redirect URL we get
                    // a 200 response with no Location header. If this happens, just wait and try again
                    // with the same url. 
                    await Task.Delay(pollFrequencyInMs, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    nextUrl = RetrieveLocation(response);
                }
            }

            return nextUrl;
        }

        private bool NotArrivedAtExpectedUrl(Uri redirectUrl, string expectedUrl)
        {
            return redirectUrl.AbsoluteUri.StartsWith(expectedUrl) == false;
        }

        private Uri RetrieveLocation(HttpResponseMessage message)
        {
            var uri = message.Headers.Location;

            if (!uri.IsAbsoluteUri && uri.OriginalString.StartsWith("/"))
            {
                var requestUri = message.RequestMessage.RequestUri;
                var absolute = $"{requestUri.Scheme}://{requestUri.Authority}{uri.OriginalString}";
                uri = new Uri(absolute);
            }

            return uri;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass 
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _client.Dispose();
                    _noRedirectClient.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
