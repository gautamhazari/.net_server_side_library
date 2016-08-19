MobileConnectWebInterface.RequestTokenAsync Method (HttpRequestMessage, String, Uri, String, String, MobileConnectRequestOptions)
=================================================================================================================================
Request token using the values returned from the authorization redirect

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RequestTokenAsync(
	HttpRequestMessage request,
	string sdkSession,
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

##### *sdkSession*
Type: [System.String][3]  
SDKSession id used to fetch the discovery response with additional parameters that are required to request a token

##### *redirectedUrl*
Type: [System.Uri][4]  
Uri redirected to by the completion of the authorization UI

##### *expectedState*
Type: [System.String][3]  
The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process

##### *expectedNonce*
Type: [System.String][3]  
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
[MobileConnectWebInterface Class][8]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/hh159020
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/txt7706a
[5]: ../MobileConnectRequestOptions/README.md
[6]: http://msdn.microsoft.com/en-us/library/dd321424
[7]: ../MobileConnectStatus/README.md
[8]: README.md
[9]: ../../_icons/Help.png