MobileConnectInterface.RequestUserInfoAsync Method
==================================================
Request user info using the access token returned by [RequestTokenAsync(DiscoveryResponse, Uri, String, String)][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RequestUserInfoAsync(
	DiscoveryResponse discoveryResponse,
	string accessToken,
	ClaimsParameter claims,
	MobileConnectRequestOptions options
)
```

#### Parameters

##### *discoveryResponse*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][3]  
The response returned by the discovery process

##### *accessToken*
Type: [System.String][4]  
Access token from RequestToken stage

##### *claims*
Type: [GSMA.MobileConnect.Claims.ClaimsParameter][5]  
Claims requested from UserInfo service (Optional)

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][6]  
Additional optional parameters

#### Return Value
Type: [Task][7]&lt;[MobileConnectStatus][8]>  
MobileConnectStatus object with UserInfo information

See Also
--------

#### Reference
[MobileConnectInterface Class][9]  
[GSMA.MobileConnect Namespace][2]  

[1]: RequestTokenAsync.md
[2]: ../README.md
[3]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../../GSMA.MobileConnect.Claims/ClaimsParameter/README.md
[6]: ../MobileConnectRequestOptions/README.md
[7]: http://msdn.microsoft.com/en-us/library/dd321424
[8]: ../MobileConnectStatus/README.md
[9]: README.md
[10]: ../../_icons/Help.png