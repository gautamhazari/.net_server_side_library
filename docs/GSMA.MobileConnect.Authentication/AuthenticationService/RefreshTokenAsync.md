AuthenticationService.RefreshTokenAsync Method
==============================================
Allows an application to use the refresh token obtained from request token response and request for a token refresh. This function requires a valid refresh token to be provided

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<RequestTokenResponse> RefreshTokenAsync(
	string clientId,
	string clientSecret,
	string refreshTokenUrl,
	string refreshToken
)
```

#### Parameters

##### *clientId*
Type: [System.String][2]  
The application ClientId returned by the discovery process

##### *clientSecret*
Type: [System.String][2]  
The ClientSecret returned by the discovery response

##### *refreshTokenUrl*
Type: [System.String][2]  
The url for token refresh received from the discovery process

##### *refreshToken*
Type: [System.String][2]  
Refresh token returned from RequestToken request

#### Return Value
Type: [Task][3]&lt;[RequestTokenResponse][4]>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Authentication.AuthenticationService.RefreshTokenAsync(System.String,System.String,System.String,System.String)"]

#### Implements
[IAuthenticationService.RefreshTokenAsync(String, String, String, String)][5]  


See Also
--------

#### Reference
[AuthenticationService Class][6]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: ../RequestTokenResponse/README.md
[5]: ../IAuthenticationService/RefreshTokenAsync.md
[6]: README.md
[7]: ../../_icons/Help.png