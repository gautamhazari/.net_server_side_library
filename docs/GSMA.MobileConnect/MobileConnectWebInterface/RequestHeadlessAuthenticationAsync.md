MobileConnectWebInterface.RequestHeadlessAuthenticationAsync Method (HttpRequestMessage, DiscoveryResponse, String, String, String, MobileConnectRequestOptions, CancellationToken)
===================================================================================================================================================================================
Performs headless authentication followed by request token if successful. Tokens will be validated before being returned. This may be a long running method as it waits for the authenticating user to respond using their authenticating device.

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> RequestHeadlessAuthenticationAsync(
	HttpRequestMessage request,
	DiscoveryResponse discoveryResponse,
	string encryptedMSISDN,
	string state,
	string nonce,
	MobileConnectRequestOptions options,
	CancellationToken cancellationToken = null
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][2]  
Originating web request

##### *discoveryResponse*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][3]  
The response returned by the discovery process

##### *encryptedMSISDN*
Type: [System.String][4]  
Encrypted MSISDN/Subscriber Id returned from the Discovery process

##### *state*
Type: [System.String][4]  
Unique string to be used to prevent Cross Site Forgery Request attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)

##### *nonce*
Type: [System.String][4]  
Unique string to be used to prevent replay attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][5]  
Optional parameters

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][6]  
Cancellation token that can be used to cancel long running requests

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
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../MobileConnectRequestOptions/README.md
[6]: http://msdn.microsoft.com/en-us/library/dd384802
[7]: http://msdn.microsoft.com/en-us/library/dd321424
[8]: ../MobileConnectStatus/README.md
[9]: README.md
[10]: ../../_icons/Help.png