using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Utils;
using GSMA.MobileConnect.Exceptions;
using Newtonsoft.Json;
using System.Threading;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Constants;
using Scope = GSMA.MobileConnect.Utils.Scope;
using System.Net.Http;
using GSMA.MobileConnect.Claims;
using Version = GSMA.MobileConnect.Discovery.Version;

namespace GSMA.MobileConnect.Authentication
{
    /// <summary>
    /// Concrete implementation of <see cref="IAuthenticationService"/>
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        private readonly RestClient _client;

        /// <summary>
        /// Creates a new instance of the class AuthenticationService using the specified RestClient for all HTTP requests
        /// </summary>
        /// <param name="client">RestClient for handling HTTP requests</param>
        public AuthenticationService(RestClient client)
        {
            this._client = client;
        }

        /// <inheritdoc/>
        public StartAuthenticationResponse StartAuthentication(string clientId, string correlationId, string authorizeUrl, string redirectUrl, string state, string nonce,
            string encryptedMsisdn, AuthenticationOptions options, string currentVersion)
        {
            Validate.RejectNullOrEmpty(clientId, "clientId");
            Validate.RejectNullOrEmpty(authorizeUrl, "authorizeUrl");
            Validate.RejectNullOrEmpty(redirectUrl, "redirectUrl");
            Validate.RejectNullOrEmpty(state, "state");
            Validate.RejectNullOrEmpty(nonce, "nonce");

            options = options ?? new AuthenticationOptions();
            options.Scope = options.Scope ?? "";

            if (options != null && !options.IsUsingCorrelationId)
            {
                correlationId = "";
            }

            bool shouldUseAuthorize = options.Scope.ToLower().Equals(Constants.Scope.AUTHZ.ToLower());

            if (shouldUseAuthorize)
            {
                Validate.RejectNullOrEmpty(options.Context, "options.Context");
                Validate.RejectNullOrEmpty(options.ClientName, "options.ClientName");
                Validate.RejectNullOrEmpty(options.BindingMessage, "options.BindingMessage");
            }

            if (options != null)
            {
                KYCClaimsParameter kycClaims = options.KycClaims;
                if (kycClaims != null)
                {
                    bool isNamePresent = false;
                    bool isAddressPresent = false;
                    if (currentVersion.Equals(DefaultOptions.V2_3) && options.Scope.Contains(Constants.Scope.KYC_PLAIN))
                    {
                        isNamePresent = StringUtils.requireNonEmpty("name || given_name and family_name",
                            kycClaims.Name, kycClaims.GivenName, kycClaims.FamilyName);
                        isAddressPresent = StringUtils.requireNonEmpty(
                            "address || houseno_or_housename, postal_code, country, town", kycClaims.Address,
                            kycClaims.HousenoOrHouseName, kycClaims.PostalCode, kycClaims.Country, kycClaims.Town);
                    }
             
                    if (currentVersion.Equals(DefaultOptions.V2_3) && options.Scope.Contains(Constants.Scope.KYC_HASHED))
                    {
                        isNamePresent = StringUtils.requireNonEmpty("name_hashed || given_name_hashed and family_name_hashed",
                            kycClaims.NameHashed, kycClaims.GivenNameHashed, kycClaims.FamilyNameHashed);
                        isAddressPresent = StringUtils.requireNonEmpty(
                            "address_hashed || houseno_or_housename_hashed, postal_code_hashed, country_hashed, town_hashed", kycClaims.AddressHashed,
                            kycClaims.HousenoOrHouseNameHashed, kycClaims.PostalCodeHashed, kycClaims.CountryHashed, kycClaims.TownHashed);
                    }

                    if ((isNamePresent & !isAddressPresent) | (!isNamePresent & isAddressPresent))
                    {
                        throw new MobileConnectInvalidArgumentException("(split|concatenated, plain|hashed) name or address is empty");
                    }
                }
            }

            options.State = state;
            options.Nonce = nonce;
            options.CorrelationId = correlationId;
            if (options.LoginHintToken == null)
            {
                options.LoginHint = options.LoginHint ?? LoginHint.GenerateForEncryptedMsisdn(encryptedMsisdn);
            }

            options.RedirectUrl = redirectUrl;
            options.ClientId = clientId;

            UriBuilder build = new UriBuilder(authorizeUrl);
            build.AddQueryParams(GetAuthenticationQueryParams(options, shouldUseAuthorize, currentVersion));

            Log.Info(() => $"Authentication URI={build.Uri.AbsoluteUri}");
            return new StartAuthenticationResponse() { Url = build.Uri.AbsoluteUri };
        }

        /// <summary>
        /// Make fake discovery for authorization
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <param name="clientSecret">Client secret</param>
        /// <param name="subscriberId">Subscriber ID</param>
        /// <param name="appName">Client application name</param>
        /// <param name="operatorsUrl">Operators urls</param>
        /// <returns>Generated fake discovery response</returns>
        public async Task<DiscoveryResponse> MakeDiscoveryForAuthorization(string clientId, string clientSecret,
            string appName, OperatorUrls operatorsUrl)
        {
            Validate.RejectNullOrEmpty(clientId, "clientId");
            Validate.RejectNullOrEmpty(clientSecret, "clientSecret");
            Validate.RejectNull(operatorsUrl, "operatorsUrl");

            var discoveryService = new DiscoveryService(new DiscoveryCache(), _client);

            var providerMetadata = new ProviderMetadata();

            var discoveryGenerateResponseOptions = new DiscoveryResponseGenerateOptions(clientSecret, clientId, appName, operatorsUrl.GetListOfUrls(), operatorsUrl.GetListOfRels());

            var restResponse = new RestResponse()
            {
                StatusCode = HttpStatusCode.OK,
                Content = discoveryGenerateResponseOptions.GetJsonResponse()
            };

            try
            {
                var length = discoveryGenerateResponseOptions.Response.response.apis.operatorid.link.Count;
                string providerMetadataLink = null;
                for (var i = 0; i < length; i++)
                {
                    var link = discoveryGenerateResponseOptions.Response.response.apis.operatorid.link[i];
                    if (link.rel == LinkRels.OPENID_CONFIGURATION)
                    {
                        providerMetadataLink = link.href;
                    } else if (string.IsNullOrEmpty(providerMetadataLink) && link.rel == LinkRels.ISSUER)
                    {
                        providerMetadataLink = StringUtils.concatenateURL(link.href, LinkRels.PROVIDER_METADATA_POSTFIX);
                    }
                }

                

                if (providerMetadataLink != null)
                {
                    providerMetadata = await discoveryService.RetrieveProviderMetada(providerMetadataLink);
                }
            }
            catch (Exception exception)
            {

                throw exception;
            }

            var discoveryResponse = new DiscoveryResponse(restResponse);
            discoveryResponse.ProviderMetadata = providerMetadata;

            return discoveryResponse;
        }

        /// <inheritdoc/>
        public async Task<RequestTokenResponse> RequestHeadlessAuthentication(string clientId, string correlationId, string clientSecret, string authorizeUrl, string tokenUrl, string redirectUrl,
            string state, string nonce, string encryptedMsisdn, AuthenticationOptions options, string version, CancellationToken cancellationToken = default(CancellationToken))
        {
            options = options ?? new AuthenticationOptions();

            bool shouldUseAuthorize = ShouldUseAuthorize(options);
            if (shouldUseAuthorize)
            {
                options.Prompt = Parameters.LOGIN;
            }

            string authUrl = StartAuthentication(clientId, correlationId, authorizeUrl, redirectUrl, state, nonce, encryptedMsisdn, options, version).Url;
            Uri finalRedirect = null;

            try
            {
                finalRedirect = await _client.GetFinalRedirect(authUrl, redirectUrl, options.PollFrequencyInMs, options.MaxRedirects, cancellationToken);
            }
            catch (Exception e) when (e is System.Net.WebException || e is TaskCanceledException)
            {
                Log.Error("Headless authentication was cancelled", e);
                return new RequestTokenResponse(new ErrorResponse { Error = ErrorCodes.AuthCancelled, ErrorDescription = "Headless authentication was cancelled or a timeout occurred" });
            }
            catch (HttpRequestException e)
            {
                Log.Error("Headless authentication failed", e);
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }

            var error = ErrorResponse.CreateFromUrl(finalRedirect.AbsoluteUri);

            if (error != null)
            {
                return new RequestTokenResponse(error);
            }

            var code = HttpUtils.ExtractQueryValue(finalRedirect.AbsoluteUri, "code");
            return await RequestTokenAsync(clientId, correlationId, clientSecret, tokenUrl, redirectUrl, code);
        }

        private bool ShouldUseAuthorize(AuthenticationOptions options)
        {
            int authnIndex = options.Scope.IndexOf(Constants.Scope.AUTHN, StringComparison.OrdinalIgnoreCase);
            bool authnRequested = authnIndex > -1;
            bool mcProductRequested = options.Scope.ToLower().Equals(Constants.Scope.AUTHZ.ToLower());

            if (mcProductRequested)
            {
                return true;
            }

            // If context is passed and authn not specifically requested then use authorize
            if (!authnRequested && !string.IsNullOrEmpty(options.Context))
            {
                return true;
            }

            return false;
        }
    
        /// <inheritdoc/>
        public async Task<RequestTokenResponse> RequestTokenAsync(string clientId, string correlationId, string clientSecret, string requestTokenUrl, string redirectUrl, string code, bool isBasicAuth = true)
        {
            Validate.RejectNullOrEmpty(clientId, "clientId");
            Validate.RejectNullOrEmpty(clientSecret, "clientSecret");
            Validate.RejectNullOrEmpty(requestTokenUrl, "requestTokenUrl");
            Validate.RejectNullOrEmpty(redirectUrl, "redirectUrl");
            Validate.RejectNullOrEmpty(code, "code");

            try
            {
                var formData = new List<BasicKeyValuePair>()
                {
                    new BasicKeyValuePair(Parameters.CLIENT_ID, !isBasicAuth ? clientId : null),
                    new BasicKeyValuePair(Parameters.CLIENT_SECRET, !isBasicAuth ? clientSecret : null),
                    new BasicKeyValuePair(Parameters.AUTHENTICATION_REDIRECT_URI, redirectUrl),
                    new BasicKeyValuePair(Parameters.CODE, code),
                    new BasicKeyValuePair(Parameters.GRANT_TYPE, DefaultOptions.GRANT_TYPE),
                    new BasicKeyValuePair(Parameters.CORRELATION_ID, correlationId)
                };
                RestResponse response = await _client.PostAsync(requestTokenUrl, isBasicAuth ? RestAuthentication.Basic(clientId, clientSecret) : null, formData, null, null);
                var tokenResponse = new RequestTokenResponse(response);

                return tokenResponse;
            }
            catch (Exception e) when (e is HttpRequestException || e is System.Net.WebException || e is TaskCanceledException)
            {
                Log.Error(() => $"Error occurred while requesting token url={requestTokenUrl}", e);
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }
        }

        /// <inheritdoc/>
        public RequestTokenResponse RequestToken(string clientId, string correlationId, string clientSecret, string requestTokenUrl, string redirectUrl, string code)
        {
            return RequestTokenAsync(clientId, correlationId, clientSecret, requestTokenUrl, redirectUrl, code).Result;
        }

        /// <inheritdoc/>
        public async Task<RequestTokenResponse> RefreshTokenAsync(string clientId, string clientSecret, string refreshTokenUrl, string refreshToken, bool isBasicAuth = true)
        {
            Validate.RejectNullOrEmpty(clientId, "clientId");
            Validate.RejectNullOrEmpty(clientSecret, "clientSecret");
            Validate.RejectNullOrEmpty(refreshTokenUrl, "refreshTokenUrl");
            Validate.RejectNullOrEmpty(refreshToken, "refreshToken");

            var formData = new List<BasicKeyValuePair>()
            {
                new BasicKeyValuePair(Parameters.REFRESH_TOKEN, refreshToken),
                new BasicKeyValuePair(Parameters.GRANT_TYPE, GrantTypes.REFRESH_TOKEN),
            };
            var authentication = RestAuthentication.Basic(clientId, clientSecret);

            RestResponse restResponse;
            try
            {
                restResponse = await _client.PostAsync(refreshTokenUrl, isBasicAuth ? authentication : null, formData, null, null);
            }
            catch (Exception e) when (e is HttpRequestException || e is System.Net.WebException || e is TaskCanceledException)
            {
                Log.Error(() => $"Error occurred while refreshing token url={refreshTokenUrl}", e);
                throw new MobileConnectEndpointHttpException(e.Message, e);
            }

            return new RequestTokenResponse(restResponse);
        }

        /// <inheritdoc/>
        public RequestTokenResponse RefreshToken(string clientId, string clientSecret, string refreshTokenUrl, string refreshToken)
        {
            return RefreshTokenAsync(clientId, clientSecret, refreshTokenUrl, refreshToken).Result;
        }

        /// <inheritdoc/>
        public async Task<RevokeTokenResponse> RevokeTokenAsync(string clientId, string clientSecret, string revokeTokenUrl, string token, string tokenTypeHint, bool isBasicAuth = true)
        {
            Validate.RejectNullOrEmpty(clientId, "clientId");
            Validate.RejectNullOrEmpty(clientSecret, "clientSecret");
            Validate.RejectNullOrEmpty(revokeTokenUrl, "revokeTokenUrl");
            Validate.RejectNullOrEmpty(token, "token");

            var formData = new List<BasicKeyValuePair>()
            {
                new BasicKeyValuePair(Parameters.TOKEN, token)
            };

            if (tokenTypeHint != null)
            {
                formData.Add(new BasicKeyValuePair(Parameters.TOKEN_TYPE_HINT, tokenTypeHint));
            }

            var authentication = RestAuthentication.Basic(clientId, clientSecret);
            var restResponse = await _client.PostAsync(revokeTokenUrl, isBasicAuth ? authentication : null, formData, null, null);
            return new RevokeTokenResponse(restResponse);
        }

        /// <inheritdoc/>
        public RevokeTokenResponse RevokeToken(string clientId, string clientSecret, string revokeTokenUrl, string token, string tokenTypeHint)
        {
            return RevokeTokenAsync(clientId, clientSecret, revokeTokenUrl, token, tokenTypeHint).Result;
        }

        /// <inheritdoc/>
        public TokenValidationResult ValidateTokenResponse(RequestTokenResponse tokenResponse, string clientId, string issuer, string nonce, int? maxAge, JWKeyset keyset, string version)
        {
            if (tokenResponse?.ResponseData == null)
            {
                Log.Warning(() => $"Token was incomplete from issuer={issuer}");
                return TokenValidationResult.IncompleteTokenResponse;
            }

            TokenValidationResult result = TokenValidation.ValidateAccessToken(tokenResponse.ResponseData);
            if (result != TokenValidationResult.Valid)
            {
                Log.Warning(() => $"Access token was invalid from issuer={issuer}");
                return result;
            }

            result = TokenValidation.ValidateIdToken(tokenResponse.ResponseData.IdToken, clientId, issuer, nonce, maxAge, keyset, version);
            if (result != TokenValidationResult.Valid)
            {
                Log.Warning(() => $"IDToken was invalid from issuer={issuer} for reason={result}");
            }

            return result;
        }

        /// <inheritdoc/>
        private List<BasicKeyValuePair> GetAuthenticationQueryParams(AuthenticationOptions options, bool useAuthorize, string version)
        {
            string kycClaimsJson = null;
            if (options.KycClaims != null)
            {
                kycClaimsJson = options.KycClaims.ToJson();
            }


            var authParameters = new List<BasicKeyValuePair>
            {
                new BasicKeyValuePair(Parameters.AUTHENTICATION_REDIRECT_URI, options.RedirectUrl),
                new BasicKeyValuePair(Parameters.CLIENT_ID, options.ClientId),
                new BasicKeyValuePair(Parameters.RESPONSE_TYPE, DefaultOptions.AUTHENTICATION_RESPONSE_TYPE),
                new BasicKeyValuePair(Parameters.SCOPE, options.Scope),
                new BasicKeyValuePair(Parameters.ACR_VALUES, options.AcrValues),
                new BasicKeyValuePair(Parameters.STATE, options.State),
                new BasicKeyValuePair(Parameters.NONCE, options.Nonce),
                new BasicKeyValuePair(Parameters.DISPLAY, options.Display),
                new BasicKeyValuePair(Parameters.PROMPT, getPrompt(options.Prompt, version)),
                new BasicKeyValuePair(Parameters.MAX_AGE, options.MaxAge.ToString()),
                new BasicKeyValuePair(Parameters.UI_LOCALES, options.UiLocales),
                new BasicKeyValuePair(Parameters.CLAIMS_LOCALES, options.ClaimsLocales),
                new BasicKeyValuePair(Parameters.ID_TOKEN_HINT, options.IdTokenHint),
                new BasicKeyValuePair(Parameters.LOGIN_HINT, options.LoginHint),
                new BasicKeyValuePair(Parameters.LOGIN_HINT_TOKEN, options.LoginHintToken),
                new BasicKeyValuePair(Parameters.DTBS, options.Dtbs),
                new BasicKeyValuePair(Parameters.CLAIMS, GetClaimsString(options)),
                new BasicKeyValuePair(Parameters.VERSION, version),
                new BasicKeyValuePair(Parameters.BINDING_MESSAGE, options.BindingMessage),
                new BasicKeyValuePair(Parameters.CONTEXT, options.Context),
                new BasicKeyValuePair(Parameters.CLIENT_NAME, options.ClientName),
                new BasicKeyValuePair(Parameters.CORRELATION_ID, options.CorrelationId)
            };

            if (kycClaimsJson != null)
            {
                authParameters.Add(new BasicKeyValuePair(Parameters.CLAIMS, kycClaimsJson));
            }

            if (useAuthorize)
            {
                authParameters.Add(new BasicKeyValuePair(Parameters.CLIENT_NAME, options.ClientName));
                authParameters.Add(new BasicKeyValuePair(Parameters.CONTEXT, options.Context));
                authParameters.Add(new BasicKeyValuePair(Parameters.BINDING_MESSAGE, options.BindingMessage));
            }

            return authParameters;
        }

        private String getPrompt(string currentPrompt, string currentVersion)
        {
            if (string.IsNullOrEmpty(currentPrompt))
            {
                return null;
            }

            if (!currentVersion.Equals(Version.MC_DI_V3_0))
            {
                if (currentPrompt.Equals(Parameters.CONSENT) || currentPrompt.Equals(Parameters.SELECT_ACCOUNT))
                {
                    return currentPrompt;
                }
            }

            if (currentPrompt.Equals(Parameters.NONE) || currentPrompt.Equals(Parameters.LOGIN)
                                                      || currentPrompt.Equals(Parameters.NO_SEAM))
            {
                return currentPrompt;
            }

            return null;
        }

        private string GetClaimsString(AuthenticationOptions options)
        {
            if (!string.IsNullOrEmpty(options.ClaimsJson))
            {
                return options.ClaimsJson;
            }

            return options.Claims != null && !options.Claims.IsEmpty ? JsonConvert.SerializeObject(options.Claims, JsonSettings) : null;
        }
    }
}
