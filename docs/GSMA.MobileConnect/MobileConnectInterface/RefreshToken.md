MobileConnectInterface.RefreshToken Method
==========================================
Synchronous wrapper for [RefreshTokenAsync(String, DiscoveryResponse)][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public MobileConnectStatus RefreshToken(
	string refreshToken,
	DiscoveryResponse discoveryResponse
)
```

#### Parameters

##### *refreshToken*
Type: [System.String][3]  
Refresh token returned from RefreshToken request

##### *discoveryResponse*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][4]  
The response returned by the discovery process

#### Return Value
Type: [MobileConnectStatus][5]  
Object with required information for continuing the mobile connect process

See Also
--------

#### Reference
[MobileConnectInterface Class][6]  
[GSMA.MobileConnect Namespace][2]  

[1]: RefreshTokenAsync.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[5]: ../MobileConnectStatus/README.md
[6]: README.md
[7]: ../../_icons/Help.png