IAuthenticationService.RevokeTokenAsync Method
==============================================
Allows an application to use the access token or the refresh token obtained from request token response and request for a token revocation This function requires either a valid access token or a refresh token to be provided

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
Task<RevokeTokenResponse> RevokeTokenAsync(
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
Type: [Task][3]&lt;[RevokeTokenResponse][4]>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Authentication.IAuthenticationService.RevokeTokenAsync(System.String,System.String,System.String,System.String,System.String)"]


See Also
--------

#### Reference
[IAuthenticationService Interface][5]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: ../RevokeTokenResponse/README.md
[5]: README.md
[6]: ../../_icons/Help.png