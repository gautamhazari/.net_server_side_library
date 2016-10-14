MobileConnectWebInterface.RevokeTokenAsync Method (HttpRequestMessage, String, String, DiscoveryResponse)
=========================================================================================================
Revoke token using using the access / refresh token provided in the RequestToken response

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RevokeTokenAsync(
	HttpRequestMessage request,
	string token,
	string tokenTypeHint,
	DiscoveryResponse discoveryResponse
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][2]  
Originating web request

##### *token*
Type: [System.String][3]  
Access/Refresh token returned from RequestToken request

##### *tokenTypeHint*
Type: [System.String][3]  
Hint to indicate the type of token being passed in

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