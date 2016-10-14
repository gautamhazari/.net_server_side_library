MobileConnectInterface.RevokeTokenAsync Method
==============================================
Revoke token using using the access / refresh token provided in the RequestToken response

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RevokeTokenAsync(
	string token,
	string tokenTypeHint,
	DiscoveryResponse discoveryResponse
)
```

#### Parameters

##### *token*
Type: [System.String][2]  
Access/Refresh token returned from RequestToken request

##### *tokenTypeHint*
Type: [System.String][2]  
Hint to indicate the type of token being passed in

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