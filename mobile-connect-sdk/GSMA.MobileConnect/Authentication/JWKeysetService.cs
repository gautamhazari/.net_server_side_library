using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Concrete implementation <see cref="IJWKeysetService"/>
    /// </summary>
    public class JWKeysetService : IJWKeysetService
    {
        private readonly RestClient _client;
        private readonly ICache _cache;

        /// <summary>
        /// Creates an instance of the JWKeysetService with a configured cache
        /// </summary>
        /// <param name="client">RestClient for handling HTTP requests</param>
        /// <param name="cache">Cache for storing and reusing <see cref="JWKeyset"/> objects</param>
        public JWKeysetService(RestClient client, ICache cache)
        {
            _client = client;
            _cache = cache;
        }

        /// <inheritdoc/>
        public async Task<JWKeyset> RetrieveJWKSAsync(string url)
        {
            var cached = await RetrieveFromCache(url);

            if (cached != null && !cached.HasExpired)
            {
                return cached;
            }

            RestResponse response;
            try
            {
                response = await _client.GetAsync(url, null);
            }
            catch (Exception e) when (e is HttpRequestException || e is System.Net.WebException || e is TaskCanceledException)
            {
                return cached;
            }

            var jwks = JsonConvert.DeserializeObject<JWKeyset>(response.Content);

            await AddToCache(url, jwks).ConfigureAwait(false);

            return jwks;
        }

        /// <inheritdoc/>
        public JWKeyset RetrieveJWKS(string url)
        {
            return RetrieveJWKSAsync(url).Result;
        }

        private async Task<JWKeyset> RetrieveFromCache(string url)
        {
            if (_cache == null)
                return null;

            return await _cache.Get<JWKeyset>(url, false);
        }

        private async Task AddToCache(string url, JWKeyset keyset)
        {
            if (_cache == null || keyset == null)
                return;

            await _cache.Add(url, keyset).ConfigureAwait(false);
        }
    }
}
