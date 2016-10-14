MobileConnectWebInterface.RefreshTokenAsync Method (HttpRequestMessage, String, DiscoveryResponse)
==================================================================================================
Refresh token using using the refresh token provided in the RequestToken response

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RefreshTokenAsync(
	HttpRequestMessage request,
	string refreshToken,
	DiscoveryResponse discoveryResponse
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][2]  
Originating web request

##### *refreshToken*
Type: [System.String][3]  
Refresh token returned from RefreshToken request

##### *discoveryResponse*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][4]  
The response returned by the discovery process

#### Return Value
Type: [Task][5]&lt;[MobileConnectStatus][6]>  
Object with required information for continuing the mobile connect process

See Also
--------

#### Reference
[MobileConnectWebInterface Class][7]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/hh159020
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[5]: http://msdn.microsoft.com/en-us/library/dd321424
[6]: ../MobileConnectStatus/README.md
[7]: README.md
[8]: ../../_icons/Help.png