MobileConnectInterface.RequestTokenAsync Method
===============================================
Request token using the values returned from the authorization redirect

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RequestTokenAsync(
	DiscoveryResponse discoveryResponse,
	Uri redirectedUrl,
	string expectedState,
	string expectedNonce,
	MobileConnectRequestOptions options
)
```

#### Parameters

##### *discoveryResponse*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][2]  
The response returned by the discovery process

##### *redirectedUrl*
Type: [System.Uri][3]  
Uri redirected to by the completion of the authorization UI

##### *expectedState*
Type: [System.String][4]  
The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process

##### *expectedNonce*
Type: [System.String][4]  
The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][5]  
Optional parameters

#### Return Value
Type: [Task][6]&lt;[MobileConnectStatus][7]>  
MobileConnectStatus object with required information for continuing the mobileconnect process

See Also
--------

#### Reference
[MobileConnectInterface Class][8]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[3]: http://msdn.microsoft.com/en-us/library/txt7706a
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../MobileConnectRequestOptions/README.md
[6]: http://msdn.microsoft.com/en-us/library/dd321424
[7]: ../MobileConnectStatus/README.md
[8]: README.md
[9]: ../../_icons/Help.png