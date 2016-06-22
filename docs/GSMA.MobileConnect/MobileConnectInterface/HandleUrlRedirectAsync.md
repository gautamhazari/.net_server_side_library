MobileConnectInterface.HandleUrlRedirectAsync Method
====================================================
Handles continuation of the process following a completed redirect. Only the redirectedUrl is required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required.

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> HandleUrlRedirectAsync(
	Uri redirectedUrl,
	DiscoveryResponse discoveryResponse = null,
	string expectedState = null,
	string expectedNonce = null
)
```

#### Parameters

##### *redirectedUrl*
Type: [System.Uri][2]  
Url redirected to by the completion of the previous step

##### *discoveryResponse* (Optional)
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][3]  
The response returned by the discovery process

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
[MobileConnectInterface Class][7]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/txt7706a
[3]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: http://msdn.microsoft.com/en-us/library/dd321424
[6]: ../MobileConnectStatus/README.md
[7]: README.md
[8]: ../../_icons/Help.png