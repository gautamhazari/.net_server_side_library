MobileConnectWebInterface.RequestUserInfoAsync Method (HttpRequestMessage, DiscoveryResponse, String, ClaimsParameter, MobileConnectRequestOptions)
===================================================================================================================================================
Request user info using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RequestUserInfoAsync(
	HttpRequestMessage request,
	DiscoveryResponse discoveryResponse,
	string accessToken,
	ClaimsParameter claims,
	MobileConnectRequestOptions options
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][3]  
Originating web request

##### *discoveryResponse*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][4]  
The response returned by the discovery process

##### *accessToken*
Type: [System.String][5]  
Access token returned from RequestToken required to authenticate the request

##### *claims*
Type: [GSMA.MobileConnect.Claims.ClaimsParameter][6]  
ClaimsParameter describing the requested claims (Optional)

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][7]  
Optional parameters

#### Return Value
Type: [Task][8]&lt;[MobileConnectStatus][9]>  
MobileConnectStatus object with requested UserInfo information

See Also
--------

#### Reference
[MobileConnectWebInterface Class][10]  
[GSMA.MobileConnect Namespace][2]  

[1]: RequestTokenAsync.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/hh159020
[4]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: ../../GSMA.MobileConnect.Claims/ClaimsParameter/README.md
[7]: ../MobileConnectRequestOptions/README.md
[8]: http://msdn.microsoft.com/en-us/library/dd321424
[9]: ../MobileConnectStatus/README.md
[10]: README.md
[11]: ../../_icons/Help.png