using System;
using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Claims;
using GSMA.MobileConnect.Discovery;

namespace GSMA.MobileConnect
{
    /// <summary>
    /// Options for a single request to <see cref="MobileConnectInterface"/>. 
    /// Not all options are valid for all calls that accept an instance of this class, 
    /// only options that are relevant to the method being called will be used.
    /// </summary>
    public class MobileConnectRequestOptions
    {
        private readonly DiscoveryOptions _discoveryOptions = new DiscoveryOptions();
        private readonly AuthenticationOptions _authOptions = new AuthenticationOptions();
        private readonly TokenValidationOptions _validationOptions = new TokenValidationOptions();

        /// <inheritdoc cref="DiscoveryOptions.IsUsingMobileData"/>
        public bool IsUsingMobileData
        {
            get { return _discoveryOptions.IsUsingMobileData; }
            set { _discoveryOptions.IsUsingMobileData = value; }
        }

        /// <inheritdoc cref="DiscoveryOptions.LocalClientIP"/>
        public string LocalClientIP
        {
            get { return _discoveryOptions.LocalClientIP; }
            set { _discoveryOptions.LocalClientIP = value; }
        }

        /// <inheritdoc cref="DiscoveryOptions.ClientIP"/>
        public string ClientIP
        {
            get { return _discoveryOptions.ClientIP; }
            set { _discoveryOptions.ClientIP = value; }
        }

        /// <summary>
        /// Filled discovery options instance
        /// </summary>
        public DiscoveryOptions DiscoveryOptions
        {
            get { return _discoveryOptions; }
        }

        /// <inheritdoc cref="AuthenticationOptions.Display"/>
        public string Display
        {
            get { return _authOptions.Display; }
            set { _authOptions.Display = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.Prompt"/>
        public string Prompt
        {
            get { return _authOptions.Prompt; }
            set { _authOptions.Prompt = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.UiLocales"/>
        public string UiLocales
        {
            get { return _authOptions.UiLocales; }
            set { _authOptions.UiLocales = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.ClaimsLocales"/>
        public string ClaimsLocales
        {
            get { return _authOptions.ClaimsLocales; }
            set { _authOptions.ClaimsLocales = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.IdTokenHint"/>
        public string IdTokenHint
        {
            get { return _authOptions.IdTokenHint; }
            set { _authOptions.IdTokenHint = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.LoginHint"/>
        public string LoginHint
        {
            get { return _authOptions.LoginHint; }
            set { _authOptions.LoginHint = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.LoginHintToken"/>
        public string LoginHintToken
        {
            get { return _authOptions.LoginHintToken; }
            set { _authOptions.LoginHintToken = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.Dtbs"/>
        public string Dtbs
        {
            get { return _authOptions.Dtbs; }
            set { _authOptions.Dtbs = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.Scope" />
        public string Scope
        {
            get { return _authOptions.Scope; }
            set { _authOptions.Scope = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.AcrValues" />
        public string AcrValues
        {
            get { return _authOptions.AcrValues; }
            set { _authOptions.AcrValues = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.MaxAge" />
        public int MaxAge
        {
            get { return _authOptions.MaxAge; }
            set { _authOptions.MaxAge = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.Context" />
        public string Context
        {
            get { return _authOptions.Context; }
            set { _authOptions.Context = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.Version" />
        public string Version
        {
            get { return _authOptions.Version; }
            set { _authOptions.Version = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.BindingMessage" />
        public string BindingMessage
        {
            get { return _authOptions.BindingMessage; }
            set { _authOptions.BindingMessage = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.ClaimsJson" />
        public string ClaimsJson
        {
            get { return _authOptions.ClaimsJson; }
            set { _authOptions.ClaimsJson = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.ClaimsJson" />
        public ClaimsParameter Claims
        {
            get { return _authOptions.Claims; }
            set { _authOptions.Claims = value; }
        }

        /// <inheritdoc cref="AuthenticationOptions.ClientName" />
        public string ClientName
        {
            get { return _authOptions.ClientName; }
            set { _authOptions.ClientName = value; }
        }

        /// <summary>
        /// Filled authentication options instance
        /// </summary>
        public AuthenticationOptions AuthenticationOptions
        {
            get { return _authOptions; }
        }

        /// <summary>
        /// Whether identity should be automatically retrieved when making a headless Authentication call
        /// </summary>
        public bool AutoRetrieveIdentityHeadless { get; set; }

        /// <inheritdoc cref="TokenValidationOptions.AcceptedValidationResults"/>
        public TokenValidationResult AcceptedValidationResults
        {
            get { return _validationOptions.AcceptedValidationResults; }
            set { _validationOptions.AcceptedValidationResults = value; }
        }

        /// <summary>
        /// Filled token validation options instance
        /// </summary>
        public TokenValidationOptions TokenValidationOptions
        {
            get { return _validationOptions; }
        }
    }
}
