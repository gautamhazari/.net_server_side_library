MobileConnectWebInterface.RequestIdentityAsync Method (HttpRequestMessage, DiscoveryResponse, String, MobileConnectRequestOptions)
==================================================================================================================================
Request identity using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RequestIdentityAsync(
	HttpRequestMessage request,
	DiscoveryResponse discoveryResponse,
	string accessToken,
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

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][6]  
Optional parameters

#### Return Value
Type: [Task][7]&lt;[MobileConnectStatus][8]>  
MobileConnectStatus object with requested Identity information

See Also
--------

#### Reference
[MobileConnectWebInterface Class][9]  
[GSMA.MobileConnect Namespace][2]  

[1]: RequestTokenAsync.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/hh159020
[4]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: ../MobileConnectRequestOptions/README.md
[7]: http://msdn.microsoft.com/en-us/library/dd321424
[8]: ../MobileConnectStatus/README.md
[9]: README.md
[10]: ../../_icons/Help.png