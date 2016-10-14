IAuthenticationService.RevokeToken Method
=========================================
Synchronous wrapper for **RevokeToken(String, String, String, String, String)**

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
RevokeTokenResponse RevokeToken(
	string clientId,
	string clientSecret,
	string revokeTokenUrl,
	string token,
	string tokenTypeHint
)
```

#### Parameters

##### *clientId*
Type: [System.String][2]  
The application ClientId returned by the discovery process

##### *clientSecret*
Type: [System.String][2]  
The ClientSecret returned by the discovery response

##### *revokeTokenUrl*
Type: [System.String][2]  
The url for token refresh received from the discovery process

##### *token*
Type: [System.String][2]  
Access/Refresh token returned from RequestToken request

##### *tokenTypeHint*
Type: [System.String][2]  
Hint to indicate the type of token being passed in

#### Return Value
Type: [RevokeTokenResponse][3]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Authentication.IAuthenticationService.RevokeToken(System.String,System.String,System.String,System.String,System.String)"]


See Also
--------

#### Reference
[IAuthenticationService Interface][4]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../RevokeTokenResponse/README.md
[4]: README.md
[5]: ../../_icons/Help.png