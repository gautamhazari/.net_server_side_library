IAuthenticationService.RequestToken Method
==========================================
Synchronous wrapper for [RequestTokenAsync(String, String, String, String, String)][1]

**Namespace:** [GSMA.MobileConnect.Authentication][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
RequestTokenResponse RequestToken(
	string clientId,
	string clientSecret,
	string requestTokenUrl,
	string redirectUrl,
	string code
)
```

#### Parameters

##### *clientId*
Type: [System.String][3]  
The registered application ClientId (Required)

##### *clientSecret*
Type: [System.String][3]  
The registered application ClientSecret (Required)

##### *requestTokenUrl*
Type: [System.String][3]  
The url for token requests recieved from the discovery process (Required)

##### *redirectUrl*
Type: [System.String][3]  
Confirms the redirectURI that the application used when the authorization request (Required)

##### *code*
Type: [System.String][3]  
The authorization code provided to the application via the call to the authentication/authorization API (Required)

#### Return Value
Type: [RequestTokenResponse][4]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Authentication.IAuthenticationService.RequestToken(System.String,System.String,System.String,System.String,System.String)"]


See Also
--------

#### Reference
[IAuthenticationService Interface][5]  
[GSMA.MobileConnect.Authentication Namespace][2]  

[1]: RequestTokenAsync.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../RequestTokenResponse/README.md
[5]: README.md
[6]: ../../_icons/Help.png