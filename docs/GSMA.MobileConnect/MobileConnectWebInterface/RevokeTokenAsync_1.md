MobileConnectWebInterface.RevokeTokenAsync Method (HttpRequestMessage, String, String, String)
==============================================================================================
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
	string sdkSession
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

##### *sdkSession*
Type: [System.String][3]  
SDKSession id used to fetch the discovery response with additional parameters that are required to revoke a token

#### Return Value
Type: [Task][4]&lt;[MobileConnectStatus][5]>  
Object with required information for continuing the mobile connect process

See Also
--------

#### Reference
[MobileConnectWebInterface Class][6]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/hh159020
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/dd321424
[5]: ../MobileConnectStatus/README.md
[6]: README.md
[7]: ../../_icons/Help.png