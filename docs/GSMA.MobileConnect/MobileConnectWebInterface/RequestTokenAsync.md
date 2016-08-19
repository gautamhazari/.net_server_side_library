MobileConnectWebInterface.RequestTokenAsync Method (HttpRequestMessage, DiscoveryResponse, Uri, String, String, MobileConnectRequestOptions)
============================================================================================================================================
Request token using the values returned from the authorization redirect

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RequestTokenAsync(
	HttpRequestMessage request,
	DiscoveryResponse discoveryResponse,
	Uri redirectedUrl,
	string expectedState,
	string expectedNonce,
	MobileConnectRequestOptions options
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][2]  
Originating web request

##### *discoveryResponse*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][3]  
The response returned by the discovery process

##### *redirectedUrl*
Type: [System.Uri][4]  
Uri redirected to by the completion of the authorization UI

##### *expectedState*
Type: [System.String][5]  
The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process

##### *expectedNonce*
Type: [System.String][5]  
The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][6]  
Optional parameters

#### Return Value
Type: [Task][7]&lt;[MobileConnectStatus][8]>  
MobileConnectStatus object with required information for continuing the mobileconnect process

See Also
--------

#### Reference
[MobileConnectWebInterface Class][9]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/hh159020
[3]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[4]: http://msdn.microsoft.com/en-us/library/txt7706a
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: ../MobileConnectRequestOptions/README.md
[7]: http://msdn.microsoft.com/en-us/library/dd321424
[8]: ../MobileConnectStatus/README.md
[9]: README.md
[10]: ../../_icons/Help.png