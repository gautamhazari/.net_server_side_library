﻿using GSMA.MobileConnect.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Wrapper for Http requests, returning a simple normalised response object
    /// </summary>
    public class RestClient : IDisposable
    {
        private bool _disposed;
        private readonly HttpClientHandler _handler;
        private readonly HttpClient _client;
        private readonly HttpClientHandler _noRedirectHandler;
        private readonly HttpClient _noRedirectClient;

        /// <summary>
        /// Creates a new instance of RestClient with optional timeout specified
        /// </summary>
        /// <param name="timeout">Timeout applied to all requests</param>
        public RestClient(TimeSpan? timeout)
        {
            _handler = new HttpClientHandler { UseCookies = false };
            _client = new HttpClient(_handler, true);
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = timeout ?? TimeSpan.FromSeconds(30);

            _noRedirectHandler = new HttpClientHandler { UseCookies = false, AllowAutoRedirect = false };
            _noRedirectClient = new HttpClient(_noRedirectHandler, true);
            _noRedirectClient.Timeout = TimeSpan.FromMinutes(2);
        }

        /// <summary>
        /// Creates a new instance of RestClient with default timeout of 30 seconds
        /// </summary>
        public RestClient() : this(null) { }

        private HttpRequestMessage CreateRequest(HttpMethod method, Uri uri, RestAuthentication authentication, string sourceIp, IEnumerable<BasicKeyValuePair> cookies)
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

            return message;
        }

        /// <summary>
        /// Executes a HTTP GET to the supplied uri with optional basic auth, cookies and query params
        /// </summary>
        /// <param name="uri">Base uri of GET request</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="queryParams">Query params to be added to the base url (if required)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> GetAsync(string uri, RestAuthentication authentication, string sourceIp = null, IEnumerable<BasicKeyValuePair> queryParams = null, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            UriBuilder builder = new UriBuilder(uri);
            builder.AddQueryParams(queryParams);

            var request = CreateRequest(HttpMethod.Get, builder.Uri, authentication, sourceIp, cookies);
            var response = await _client.SendAsync(request);

            return await CreateRestResponse(response);
        }

        /// <summary>
        /// Executes a HTTP POST to the supplied uri with x-www-form-urlencoded content and optional cookies
        /// </summary>
        /// <param name="uri">Base uri of the POST</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="formData">Form data to be added as POST content</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> PostAsync(string uri, RestAuthentication authentication, IEnumerable<BasicKeyValuePair> formData, string sourceIp, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            var content = new FormUrlEncodedContent(formData.Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => new KeyValuePair<string, string>(x.Key, x.Value)));
            return await PostAsync(uri, authentication, content, sourceIp, cookies);
        }

        /// <summary>
        /// Executes a HTTP POST to the supplied uri with application/json content and optional cookies
        /// </summary>
        /// <param name="uri">Base uri of the POST</param>
        /// <param name="authentication">Authentication value to be used (if auth required)</param>
        /// <param name="content">Object to be serialized as JSON for POST content</param>
        /// <param name="sourceIp">Source request IP (if identified)</param>
        /// <param name="cookies">Cookies to be added to the request (if required)</param>
        /// <returns>RestResponse containing status code, headers and content</returns>
        public virtual async Task<RestResponse> PostAsync(string uri, RestAuthentication authentication, object content, string sourceIp, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            var json = JsonConvert.SerializeObject(content);
            return await PostAsync(uri, authentication, json, "application/json", sourceIp, cookies);
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
        public virtual async Task<RestResponse> PostAsync(string uri, RestAuthentication authentication, string content, string contentType, string sourceIp, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            return await PostAsync(uri, authentication, new StringContent(content, Encoding.UTF8, contentType), sourceIp, cookies);
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
        protected virtual async Task<RestResponse> PostAsync(string uri, RestAuthentication authentication, HttpContent content, string sourceIp, IEnumerable<BasicKeyValuePair> cookies = null)
        {
            var request = CreateRequest(HttpMethod.Post, new Uri(uri), authentication, sourceIp, cookies);
            request.Content = content;
            var response = await _client.SendAsync(request);

            return await CreateRestResponse(response);
        }

        private async Task<RestResponse> CreateRestResponse(HttpResponseMessage response)
        {
            var headers = response.Headers.Select(x => new BasicKeyValuePair(x.Key, string.Join(",", x.Value))).ToList();
            var restResponse = new RestResponse { StatusCode = response.StatusCode, Headers = headers };

            restResponse.Content = await response.Content.ReadAsStringAsync();

            return restResponse;
        }

        /// <summary>
        /// Attempts to follow a redirect path until a concrete url is loaded or the expectedRedirectUrl is reached
        /// </summary>
        /// <param name="uri">Target uri to attempt a HTTP GET</param>
        /// <param name="expectedRedirectUrl">Redirect url expected, if a redirect with this location is hit the absolute uri of the location will be returned</param>
        /// <returns>Final redirected url</returns>
        public async Task<Uri> GetFinalRedirect(string uri, string expectedRedirectUrl)
        {
            return await FollowRedirects(uri, expectedRedirectUrl);
        }

        private async Task<Uri> FollowRedirects(string targetUrl, string expectedUrl, int maxRedirects = 50)
        {
            HttpResponseMessage response = null;
            var nextUrl = new Uri(targetUrl);
            var numRedirects = 0;

            do
            {
                try
                {
                    if (numRedirects > maxRedirects)
                    {
                        throw new HttpRequestException("Stuck in redirect loop");
                    }

                    if (response != null)
                    {
                        nextUrl = RetrieveLocation(response);
                        numRedirects++;
                    }

                    response = await _noRedirectClient.GetAsync(nextUrl);
                }
                catch (HttpRequestException)
                {
                    //If the final redirect is a non-working url then it may cause a request exception, if we verify it is the redirect url then just return it.
                    //Otherwise it was a request failure at some other point in the redirect chain
                    if (nextUrl.AbsoluteUri.StartsWith(expectedUrl))
                    {
                        return nextUrl;
                    }
                    throw;
                }
            } while (((int)response.StatusCode).ToString().StartsWith("3"));

            return response.RequestMessage.RequestUri;
        }

        private Uri RetrieveLocation(HttpResponseMessage message)
        {
            var uri = message.Headers.Location;

            if (!uri.IsAbsoluteUri && uri.OriginalString.StartsWith("/"))
            {
                var requestUri = message.RequestMessage.RequestUri;
                var absolute = string.Format("{0}://{1}{2}", requestUri.Scheme, requestUri.Authority, uri.OriginalString);
                uri = new Uri(absolute);
            }

            return uri;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (!_disposed)
            {
                _client.Dispose();
                _disposed = true;
            }
        }
    }
}
