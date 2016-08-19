MobileConnectInterface.HandleUrlRedirect Method
===============================================
Synchronous wrapper for [HandleUrlRedirectAsync(Uri, DiscoveryResponse, String, String, MobileConnectRequestOptions)][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public MobileConnectStatus HandleUrlRedirect(
	Uri redirectedUrl,
	DiscoveryResponse discoveryResponse = null,
	string expectedState = null,
	string expectedNonce = null,
	MobileConnectRequestOptions options = null
)
```

#### Parameters

##### *redirectedUrl*
Type: [System.Uri][3]  
Url redirected to by the completion of the previous step

##### *discoveryResponse* (Optional)
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][4]  
The response returned by the discovery process

##### *expectedState* (Optional)
Type: [System.String][5]  
The state value returned from the StartAuthorization call should be passed here, it will be used to validate the authenticity of the authorization process

##### *expectedNonce* (Optional)
Type: [System.String][5]  
The nonce value returned from the StartAuthorization call should be passed here, it will be used to ensure the token was not requested using a replay attack

##### *options* (Optional)
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][6]  
Optional parameters

#### Return Value
Type: [MobileConnectStatus][7]  
MobileConnectStatus object with required information for continuing the mobileconnect process

See Also
--------

#### Reference
[MobileConnectInterface Class][8]  
[GSMA.MobileConnect Namespace][2]  

[1]: HandleUrlRedirectAsync.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/txt7706a
[4]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: ../MobileConnectRequestOptions/README.md
[7]: ../MobileConnectStatus/README.md
[8]: README.md
[9]: ../../_icons/Help.png