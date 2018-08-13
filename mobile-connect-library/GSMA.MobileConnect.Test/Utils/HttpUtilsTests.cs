using NUnit.Framework;
using GSMA.MobileConnect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace GSMA.MobileConnect.Test.Utils
{
    [TestFixture]
    public class HttpUtilsTests
    {
        [Test]
        public void AddQueryParamsShouldBuildUriWithQueryParams()
        {
            UriBuilder builder = new UriBuilder("http://www.google.com");
            List<BasicKeyValuePair> paramsToAdd = new List<BasicKeyValuePair>
            {
                new BasicKeyValuePair("testParam1", "16"),
                new BasicKeyValuePair("testParam2", "this one needs encoding"),
                new BasicKeyValuePair("testParam3", "$"),
            };

            builder.AddQueryParams(paramsToAdd);
            Assert.AreEqual("http://www.google.com/?testParam1=16&testParam2=this%20one%20needs%20encoding&testParam3=%24", builder.Uri.AbsoluteUri);
        }

        [Test]
        public void AddQueryParamsShouldRespectExistingParams()
        {
            UriBuilder builder = new UriBuilder("http://www.google.com/?existingParam1=12");
            List<BasicKeyValuePair> paramsToAdd = new List<BasicKeyValuePair>
            {
                new BasicKeyValuePair("testParam1", "16"),
                new BasicKeyValuePair("testParam2", "this one needs encoding"),
                new BasicKeyValuePair("testParam3", "$"),
            };

            builder.AddQueryParams(paramsToAdd);
            Assert.AreEqual("http://www.google.com/?existingParam1=12&testParam1=16&testParam2=this%20one%20needs%20encoding&testParam3=%24", builder.Uri.AbsoluteUri);
        }

        [Test]
        public void AddQueryParamsShouldIgnoreEmptyValues()
        {
            UriBuilder builder = new UriBuilder("http://www.google.com");
            List<BasicKeyValuePair> paramsToAdd = new List<BasicKeyValuePair>
            {
                new BasicKeyValuePair("testParam1", "16"),
                new BasicKeyValuePair("testParam2", ""),
                new BasicKeyValuePair("testParam3", "$"),
            };

            builder.AddQueryParams(paramsToAdd);
            Assert.AreEqual("http://www.google.com/?testParam1=16&testParam3=%24", builder.Uri.AbsoluteUri);
        }

        [Test]
        public void AddQueryParamsShouldIgnoreEmptyKeys()
        {
            UriBuilder builder = new UriBuilder("http://www.google.com");
            List<BasicKeyValuePair> paramsToAdd = new List<BasicKeyValuePair>
            {
                new BasicKeyValuePair("testParam1", "16"),
                new BasicKeyValuePair("", "this one needs encoding"),
                new BasicKeyValuePair("testParam3", "$"),
            };

            builder.AddQueryParams(paramsToAdd);
            Assert.AreEqual("http://www.google.com/?testParam1=16&testParam3=%24", builder.Uri.AbsoluteUri);
        }

        [Test]
        public void AddQueryParamsShouldHandleNullEnumerable()
        {
            UriBuilder builder = new UriBuilder("http://www.google.com");
            List<BasicKeyValuePair> paramsToAdd = null;

            builder.AddQueryParams(paramsToAdd);
            Assert.AreEqual("http://www.google.com/", builder.Uri.AbsoluteUri);
        }

        [Test]
        public void AddQueryParamsShouldHandleEmptyEnumerable()
        {
            UriBuilder builder = new UriBuilder("http://www.google.com");
            List<BasicKeyValuePair> paramsToAdd = new List<BasicKeyValuePair>();

            builder.AddQueryParams(paramsToAdd);
            Assert.AreEqual("http://www.google.com/", builder.Uri.AbsoluteUri);
        }

        [TestCase("http://www.google.com/?test=123&test2=432&test3=a%20name", "test", "123")]
        [TestCase("http://www.google.com/?test=123&test2=432&test3=a%20name", "test2", "432")]
        [TestCase("http://www.google.com/?test=123&test2=432&test3=a%20name", "test3", "a name")]
        public void ExtractQueryValueShouldExtractValue(string rawUri, string key, string expected)
        {
            Uri uri = new Uri(rawUri);
            var actual = HttpUtils.ExtractQueryValue(uri.Query, key);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExtractQueryStringShouldReturnNullIfKeyNotExists()
        {
            Uri uri = new Uri("http://www.google.com/?test=123&test2=432&test3=a%20name");
            var actual = HttpUtils.ExtractQueryValue(uri.Query, "notexist");
            Assert.IsNull(actual);
        }

        [Test]
        public void ParseQueryStringShouldReturnListOfParams()
        {
            var queryString = "?test=123&test2=432&test3=a%20name";
            var result = HttpUtils.ParseQueryString(queryString);
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("123", result["test"]);
            Assert.AreEqual("432", result["test2"]);
            Assert.AreEqual("a name", result["test3"]);
        }

        [Test]
        public void GetCookiesShouldReturnListOfCookies()
        {
            var request = new HttpRequestMessage();
            request.Headers.Add("Cookie", "X-Test-Cookie=123412341234; X-Test2-Cookie=1222211111222");
            var cookies = request.GetCookies().ToList();
            Assert.AreEqual(cookies.Count(), 2);
            Assert.AreEqual(cookies[0].Key, "X-Test-Cookie");
            Assert.AreEqual(cookies[0].Value, "123412341234");
            Assert.AreEqual(cookies[1].Key, "X-Test2-Cookie");
            Assert.AreEqual(cookies[1].Value, "1222211111222");
        }

        [Test]
        public void GetCookiesWithEmptyCookieShouldReturnNull()
        {
            var request = new HttpRequestMessage();
            request.Headers.Add("Cookie", "");

            var cookies = request.GetCookies();

            Assert.IsNull(cookies);
        }

        [Test]
        public void GetCookiesWithNoCookieHeaderShouldReturnNull()
        {
            var request = new HttpRequestMessage();

            var cookies = request.GetCookies();

            Assert.IsNull(cookies);
        }

        [Test]
        public void ProxyRequiredCookiesShouldReturnCookieList()
        {
            var requiredCookies = new List<string> { "test-cookie", "test-cookie-5" };
            var cookies = new List<BasicKeyValuePair>
            {
                new BasicKeyValuePair("test-cookie", "123"),
                new BasicKeyValuePair("test-cookie-2", "234"),
                new BasicKeyValuePair("test-cookie-3", "345"),
                new BasicKeyValuePair("test-cookie-4", "456"),
                new BasicKeyValuePair("test-cookie-5", "567"),
            };

            var actual = HttpUtils.ProxyRequiredCookies(requiredCookies, cookies);

            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("123", actual[0].Value);
            Assert.AreEqual("567", actual[1].Value);
        }
    }
}
