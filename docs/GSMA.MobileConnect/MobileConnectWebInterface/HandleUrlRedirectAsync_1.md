MobileConnectWebInterface.HandleUrlRedirectAsync Method (HttpRequestMessage, Uri, String, String, String)
=========================================================================================================
Handles continuation of the process following a completed redirect, the request token url must be provided if it has been returned by the discovery process. Only the request and redirectedUrl are required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required.

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> HandleUrlRedirectAsync(
	HttpRequestMessage request,
	Uri redirectedUrl,
	string sdkSession = null,
	string expectedState = null,
	string expectedNonce = null
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][2]  
Originating web request

##### *redirectedUrl*
Type: [System.Uri][3]  
Url redirected to by the completion of the previous step

##### *sdkSession* (Optional)
Type: [System.String][4]  
SDKSession id used to fetch the discovery response with additional parameters that are required to request a token

##### *expectedState* (Optional)
Type: [System.String][4]  
The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process

##### *expectedNonce* (Optional)
Type: [System.String][4]  
The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack

#### Return Value
Type: [Task][5]&lt;[MobileConnectStatus][6]>  
MobileConnectStatus object with required information for continuing the mobileconnect process

See Also
--------

#### Reference
[MobileConnectWebInterface Class][7]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/hh159020
[3]: http://msdn.microsoft.com/en-us/library/txt7706a
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: http://msdn.microsoft.com/en-us/library/dd321424
[6]: ../MobileConnectStatus/README.md
[7]: README.md
[8]: ../../_icons/Help.png