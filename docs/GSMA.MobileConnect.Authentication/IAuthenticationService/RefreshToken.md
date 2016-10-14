IAuthenticationService.RefreshToken Method
==========================================
Synchronous wrapper for [RefreshTokenAsync(String, String, String, String)][1]

**Namespace:** [GSMA.MobileConnect.Authentication][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
RequestTokenResponse RefreshToken(
	string clientId,
	string clientSecret,
	string refreshTokenUrl,
	string refreshToken
)
```

#### Parameters

##### *clientId*
Type: [System.String][3]  
The application ClientId returned by the discovery process

##### *clientSecret*
Type: [System.String][3]  
The ClientSecret returned by the discovery response

##### *refreshTokenUrl*
Type: [System.String][3]  
The url for token refresh received from the discovery process

##### *refreshToken*
Type: [System.String][3]  
Refresh token returned from RequestToken request

#### Return Value
Type: [RequestTokenResponse][4]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Authentication.IAuthenticationService.RefreshToken(System.String,System.String,System.String,System.String)"]


See Also
--------

#### Reference
[IAuthenticationService Interface][5]  
[GSMA.MobileConnect.Authentication Namespace][2]  

[1]: RefreshTokenAsync.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../RequestTokenResponse/README.md
[5]: README.md
[6]: ../../_icons/Help.png