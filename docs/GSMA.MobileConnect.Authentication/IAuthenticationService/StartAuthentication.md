IAuthenticationService.StartAuthentication Method
=================================================
Generates an authorisation url based on the supplied options and previous discovery response

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
StartAuthenticationResponse StartAuthentication(
	string clientId,
	string authorizeUrl,
	string redirectUrl,
	string state,
	string nonce,
	string encryptedMSISDN,
	SupportedVersions versions,
	AuthenticationOptions options
)
```

#### Parameters

##### *clientId*
Type: [System.String][2]  
The registered application ClientId (Required)

##### *authorizeUrl*
Type: [System.String][2]  
The authorization url returned by the discovery process (Required)

##### *redirectUrl*
Type: [System.String][2]  
On completion or error where the result information is sent using a HTTP 302 redirect (Required)

##### *state*
Type: [System.String][2]  
Application specified unique scope value

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

#### Return Value
Type: [StartAuthenticationResponse][6]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Authentication.IAuthenticationService.StartAuthentication(System.String,System.String,System.String,System.String,System.String,System.String,GSMA.MobileConnect.Discovery.SupportedVersions,GSMA.MobileConnect.Authentication.AuthenticationOptions)"]


See Also
--------

#### Reference
[IAuthenticationService Interface][7]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../../GSMA.MobileConnect.Discovery/SupportedVersions/README.md
[4]: ../../GSMA.MobileConnect.Discovery/ProviderMetadata/README.md
[5]: ../AuthenticationOptions/README.md
[6]: ../StartAuthenticationResponse/README.md
[7]: README.md
[8]: ../../_icons/Help.png