MobileConnectWebInterface.RefreshTokenAsync Method (HttpRequestMessage, String, String)
=======================================================================================
Refresh token using using the refresh token provided in the RequestToken response

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RefreshTokenAsync(
	HttpRequestMessage request,
	string refreshToken,
	string sdkSession
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][2]  
Originating web request

##### *refreshToken*
Type: [System.String][3]  
Refresh token returned from RefreshToken request

##### *sdkSession*
Type: [System.String][3]  
SDKSession id used to fetch the discovery response with additional parameters that are required to refresh a token

#### Return Value
Type: [Task][4]&lt;[MobileConnectStatus][5]>  
Object with required information for continuing the mobile connect process

See Also
--------

#### Reference
[MobileConnectWebInterface Class][6]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/hh159020
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/dd321424
[5]: ../MobileConnectStatus/README.md
[6]: README.md
[7]: ../../_icons/Help.png