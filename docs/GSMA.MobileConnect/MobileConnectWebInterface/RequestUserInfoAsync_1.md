MobileConnectWebInterface.RequestUserInfoAsync Method (HttpRequestMessage, String, String, ClaimsParameter, MobileConnectRequestOptions)
========================================================================================================================================
Request user info using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RequestUserInfoAsync(
	HttpRequestMessage request,
	string sdkSession,
	string accessToken,
	ClaimsParameter claims,
	MobileConnectRequestOptions options
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][3]  
Originating web request

##### *sdkSession*
Type: [System.String][4]  
SDKSession id used to fetch the discovery response with additional parameters that are required to request a user info

##### *accessToken*
Type: [System.String][4]  
Access token returned from RequestToken required to authenticate the request

##### *claims*
Type: [GSMA.MobileConnect.Claims.ClaimsParameter][5]  
ClaimsParameter describing the requested claims (Optional)

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][6]  
Additional optional parameters

#### Return Value
Type: [Task][7]&lt;[MobileConnectStatus][8]>  
MobileConnectStatus object with requested UserInfo information

See Also
--------

#### Reference
[MobileConnectWebInterface Class][9]  
[GSMA.MobileConnect Namespace][2]  

[1]: RequestTokenAsync.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/hh159020
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../../GSMA.MobileConnect.Claims/ClaimsParameter/README.md
[6]: ../MobileConnectRequestOptions/README.md
[7]: http://msdn.microsoft.com/en-us/library/dd321424
[8]: ../MobileConnectStatus/README.md
[9]: README.md
[10]: ../../_icons/Help.png