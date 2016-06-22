MobileConnectWebInterface.StartAuthorization Method (HttpRequestMessage, String, String, String, String, MobileConnectRequestOptions)
=====================================================================================================================================
Creates an authorization url with parameters to begin the authorization process, the SDKSession id is used to fetch the discovery response

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> StartAuthorization(
	HttpRequestMessage request,
	string sdkSession,
	string encryptedMSISDN,
	string state,
	string nonce,
	MobileConnectRequestOptions options
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][2]  
Originating web request

##### *sdkSession*
Type: [System.String][3]  
SDKSession id used to fetch the discovery response with additional parameters that are required to generate the url

##### *encryptedMSISDN*
Type: [System.String][3]  
Encrypted MSISDN/Subscriber Id returned from the Discovery process

##### *state*
Type: [System.String][3]  
Unique string to be used to prevent Cross Site Forgery Request attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)

##### *nonce*
Type: [System.String][3]  
Unique string to be used to prevent replay attacks during request token process (defaults to guid if not supplied, value will be returned in MobileConnectStatus object)

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][4]  
Optional parameters

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
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../MobileConnectRequestOptions/README.md
[5]: http://msdn.microsoft.com/en-us/library/dd321424
[6]: ../MobileConnectStatus/README.md
[7]: README.md
[8]: ../../_icons/Help.png