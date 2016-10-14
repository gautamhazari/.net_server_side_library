AuthenticationService.RevokeToken Method
========================================
Synchronous wrapper for [RevokeToken(String, String, String, String, String)][1]

**Namespace:** [GSMA.MobileConnect.Authentication][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public RevokeTokenResponse RevokeToken(
	string clientId,
	string clientSecret,
	string revokeTokenUrl,
	string token,
	string tokenTypeHint
)
```

#### Parameters

##### *clientId*
Type: [System.String][3]  
The application ClientId returned by the discovery process

##### *clientSecret*
Type: [System.String][3]  
The ClientSecret returned by the discovery response

##### *revokeTokenUrl*
Type: [System.String][3]  
The url for token refresh received from the discovery process

##### *token*
Type: [System.String][3]  
Access/Refresh token returned from RequestToken request

##### *tokenTypeHint*
Type: [System.String][3]  
Hint to indicate the type of token being passed in

#### Return Value
Type: [RevokeTokenResponse][4]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Authentication.AuthenticationService.RevokeToken(System.String,System.String,System.String,System.String,System.String)"]

#### Implements
[IAuthenticationService.RevokeToken(String, String, String, String, String)][1]  


See Also
--------

#### Reference
[AuthenticationService Class][5]  
[GSMA.MobileConnect.Authentication Namespace][2]  

[1]: ../IAuthenticationService/RevokeToken.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../RevokeTokenResponse/README.md
[5]: README.md
[6]: ../../_icons/Help.png