using GSMA.MobileConnect.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GSMA.MobileConnect.Utils
{
    /// <summary>
    /// Static Helper Class containing various methods and extensions required for Http Requests
    /// </summary>
    public static class HttpUtils
    {
        private static Regex authErrorRegex = new Regex(@"error\s?=\s?""(.*?)"".*?error_description\s?=\s?""(.*?)""");

        /// <summary>
        /// Extension method to add list of queryparams to a UriBuilder as a querystring
        /// </summary>
        /// <param name="builder">Builder to add query string to</param>
        /// <param name="queryParams">List of params to add to query string</param>
        public static void AddQueryParams(this UriBuilder builder, IEnumerable<BasicKeyValuePair> queryParams)
        {
            if(queryParams == null || !queryParams.Any())
            {
                return;
            }

            bool firstParam = builder.Query.IndexOf('=') == -1;
            StringBuilder query = new StringBuilder(builder.Query.TrimStart('?'));
            foreach (var queryParam in queryParams)
            {
                if(!string.IsNullOrEmpty(queryParam.Value) && !string.IsNullOrEmpty(queryParam.Key))
                {
                    if (!firstParam)
                    {
                        query.Append('&');
                    }

                    query.AppendFormat("{0}={1}", queryParam.Key, Uri.EscapeDataString(queryParam.Value));
                    firstParam = false;
                }
            }
            builder.Query = query.ToString();
        }

        /// <summary>
        /// Filters a list of cookies to return only the cookies required
        /// </summary>
        /// <param name="requiredCookies">List of required cookie keys</param>
        /// <param name="currentCookies">Complete list of cookies from originating Http request</param>
        /// <returns>List containing only cookies with keys in requiredCookies</returns>
        public static List<BasicKeyValuePair> ProxyRequiredCookies(IEnumerable<string> requiredCookies, IEnumerable<BasicKeyValuePair> currentCookies)
        {
            List<BasicKeyValuePair> cookiesToProxy = new List<BasicKeyValuePair>();

            if(currentCookies == null)
            {
                return cookiesToProxy;
            }

            foreach (var cookie in currentCookies)
            {
                if(requiredCookies.Contains(cookie.Key))
                {
                    cookiesToProxy.Add(cookie);
                }
            }

            return cookiesToProxy;
        }

        /// <summary>
        /// Extracts an unescaped value from the query string if found
        /// </summary>
        /// <remarks>If key exists multiple times in query string the last value will be returned</remarks>
        /// <param name="queryString">Full query string or url with query string</param>
        /// <param name="key">Key to be extracted from query</param>
        /// <returns>Unescaped value of key if found, otherwise null</returns>
        public static string ExtractQueryValue(string queryString, string key)
        {
            var index = queryString.LastIndexOf(key + "=", StringComparison.Ordinal);
            if(index == -1)
            {
                return null;
            }

            var reducedQuery = queryString.Substring(index);
            var firstEquals = reducedQuery.IndexOf('=');
            var firstAmp = reducedQuery.IndexOf('&');

            var length = (firstAmp > 0 ? firstAmp : reducedQuery.Length) - (firstEquals + 1);
            var value = reducedQuery.Substring(firstEquals + 1, length);

            return Uri.UnescapeDataString(value);
        }

        /// <summary>
        /// Parses a query string to return a dictionary of all key/value pairs
        /// </summary>
        /// <param name="queryString">Query string to parse</param>
        /// <returns>Dictionary of key/value pairs parsed from query string</returns>
        public static IDictionary<string, string> ParseQueryString(string queryString)
        {
            queryString = queryString.TrimStart('?');
            var paramKvPairs = queryString.Split('&');

            var kvPairs = new Dictionary<string, string>();
            foreach (var param in paramKvPairs)
            {
                var split = param.Split('=');
                kvPairs.Add(split[0], Uri.UnescapeDataString(split.ElementAtOrDefault(1) ?? ""));
            }

            return kvPairs;
        }

        /// <summary>
        /// Extension method to retrieve all cookies from a <see cref="HttpRequestMessage"/> in the form of KeyValue pairs
        /// </summary>
        /// <param name="request">Request with cookies</param>
        /// <returns>List of cookies or null if Cookie header does not exist</returns>
        public static IEnumerable<BasicKeyValuePair> GetCookies(this System.Net.Http.HttpRequestMessage request)
        {
            try
            {
                IEnumerable<string> values;
                request.Headers.TryGetValues("Cookie", out values);
                var cookieString = values?.FirstOrDefault();

                return string.IsNullOrEmpty(cookieString)
                    ? null
                    : cookieString
                        .Split(';')
                        .Select(x =>
                            {
                                var kv = x.Trim().Split('=');
                                return kv.Length == 2
                                    ? new BasicKeyValuePair(kv[0], kv[1])
                                    : new BasicKeyValuePair(null, null);
                            }
                        );
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns true if status code is an error type (400s and 500s)
        /// </summary>
        /// <param name="statusCode">Status code to check</param>
        /// <returns>True if error code</returns>
        public static bool IsHttpErrorCode(int statusCode)
        {
            char codeType = statusCode.ToString()[0];
            return codeType == '4' || codeType == '5';
        }

        /// <summary>
        /// Gets the client ip address from the request message, works for WebApi 2 Web-Host, Self-Host and OWIN hosting methods
        /// </summary>
        /// <param name="request">Request to extract ip address from</param>
        /// <returns>Ip address if found</returns>
        internal static string GetClientIp(this System.Net.Http.HttpRequestMessage request)
        {
            IEnumerable<string> ipHeaderValues;

            if (request.Headers.TryGetValues(Headers.X_FORWARDED_FOR, out ipHeaderValues))
            {
                return ipHeaderValues.FirstOrDefault();
            }

            if(request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((dynamic)request.Properties["MS_HttpContext"])?.Request.UserHostAddress;
            }

            if(request.Properties.ContainsKey("System.ServiceModel.Channels.RemoteEndpointMessageProperty"))
            {
                return ((dynamic)request.Properties["System.ServiceModel.Channels.RemoteEndpointMessageProperty"])?.Address;
            }

            if (request.Properties.ContainsKey("MS_OwinContext"))
            {
                return ((dynamic)request.Properties["MS_OwinContext"])?.Request.RemoteIpAddress;
            }

            return null;
        }

        internal static ErrorResponse GenerateAuthenticationError(string wwwauthenticate)
        {
            if(string.IsNullOrEmpty(wwwauthenticate))
            {
                return null;
            }

            var match = authErrorRegex.Match(wwwauthenticate);
            if(match != null && match.Groups.Count == 3)
            {
                return new ErrorResponse { Error = match.Groups[1].Value, ErrorDescription = match.Groups[2].Value };
            }

            return null;
        }
    }
}
