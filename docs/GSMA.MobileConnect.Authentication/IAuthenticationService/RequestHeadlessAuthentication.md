IAuthenticationService.RequestHeadlessAuthentication Method
===========================================================
Initiates headless authentication, if authentication is successful a token will be returned. This may be a long running operation as response from the user on their authentication device is required.

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
Task<RequestTokenResponse> RequestHeadlessAuthentication(
	string clientId,
	string clientSecret,
	string authorizeUrl,
	string tokenUrl,
	string redirectUrl,
	string state,
	string nonce,
	string encryptedMSISDN,
	SupportedVersions versions,
	AuthenticationOptions options,
	CancellationToken cancellationToken = null
)
```

#### Parameters

##### *clientId*
Type: [System.String][2]  
The application ClientId returned by the discovery process (Required)

##### *clientSecret*
Type: [System.String][2]  
The ClientSecret returned by the discovery response (Required)

##### *authorizeUrl*
Type: [System.String][2]  
The authorization url returned by the discovery process (Required)

##### *tokenUrl*
Type: [System.String][2]  
The token url returned by the discovery process (Required)

##### *redirectUrl*
Type: [System.String][2]  
On completion or error where the result information is sent using a HTTP 302 redirect (Required)

##### *state*
Type: [System.String][2]  
Application specified unique state value (Required)

##### *nonce*
Type: [System.String][2]  
Application specified nonce value. (Required)

##### *encryptedMSISDN*
Type: [System.String][2]  
Encrypted MSISDN for user if returned from discovery service

##### *versions*
Type: [GSMA.MobileConnect.Discovery.SupportedVersions][3]  
SupportedVersions from [ProviderMetadata][4] if null default supported versions will be used to generate the auth url

##### *options*
Type: [GSMA.MobileConnect.Authentication.AuthenticationOptions][5]  
Optional parameters

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][6]  
Cancellation token that can be used to cancel long running requests

#### Return Value
Type: [Task][7]&lt;[RequestTokenResponse][8]>  
Token if headless authentication is successful

See Also
--------

#### Reference
[IAuthenticationService Interface][9]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../../GSMA.MobileConnect.Discovery/SupportedVersions/README.md
[4]: ../../GSMA.MobileConnect.Discovery/ProviderMetadata/README.md
[5]: ../AuthenticationOptions/README.md
[6]: http://msdn.microsoft.com/en-us/library/dd384802
[7]: http://msdn.microsoft.com/en-us/library/dd321424
[8]: ../RequestTokenResponse/README.md
[9]: README.md
[10]: ../../_icons/Help.png