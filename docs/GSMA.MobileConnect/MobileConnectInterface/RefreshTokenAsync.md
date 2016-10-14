MobileConnectInterface.RefreshTokenAsync Method
===============================================
Refresh token using using the refresh token provided in the RequestToken response

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RefreshTokenAsync(
	string refreshToken,
	DiscoveryResponse discoveryResponse
)
```

#### Parameters

##### *refreshToken*
Type: [System.String][2]  
Refresh token returned from RefreshToken request

##### *discoveryResponse*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][3]  
The response returned by the discovery process

#### Return Value
Type: [Task][4]&lt;[MobileConnectStatus][5]>  
Object with required information for continuing the mobile connect process

See Also
--------

#### Reference
[MobileConnectInterface Class][6]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[4]: http://msdn.microsoft.com/en-us/library/dd321424
[5]: ../MobileConnectStatus/README.md
[6]: README.md
[7]: ../../_icons/Help.png