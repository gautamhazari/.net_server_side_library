MobileConnectInterface.RequestIdentity Method
=============================================
Syncronous wrapper for [RequestIdentityAsync(DiscoveryResponse, String, MobileConnectRequestOptions)][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public MobileConnectStatus RequestIdentity(
	DiscoveryResponse discoveryResponse,
	string accessToken,
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

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][5]  
Additional optional parameters

#### Return Value
Type: [MobileConnectStatus][6]  
MobileConnectStatus object with UserInfo information

See Also
--------

#### Reference
[MobileConnectInterface Class][7]  
[GSMA.MobileConnect Namespace][2]  

[1]: RequestIdentityAsync.md
[2]: ../README.md
[3]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../MobileConnectRequestOptions/README.md
[6]: ../MobileConnectStatus/README.md
[7]: README.md
[8]: ../../_icons/Help.png