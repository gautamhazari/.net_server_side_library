MobileConnectWebInterface.RequestUserInfoAsync Method (HttpRequestMessage, String, String, MobileConnectRequestOptions)
=======================================================================================================================
Request user info using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String, MobileConnectRequestOptions)][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RequestUserInfoAsync(
	HttpRequestMessage request,
	string sdkSession,
	string accessToken,
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

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][5]  
Additional optional parameters

#### Return Value
Type: [Task][6]&lt;[MobileConnectStatus][7]>  
MobileConnectStatus object with requested UserInfo information

See Also
--------

#### Reference
[MobileConnectWebInterface Class][8]  
[GSMA.MobileConnect Namespace][2]  

[1]: RequestTokenAsync.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/hh159020
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../MobileConnectRequestOptions/README.md
[6]: http://msdn.microsoft.com/en-us/library/dd321424
[7]: ../MobileConnectStatus/README.md
[8]: README.md
[9]: ../../_icons/Help.png