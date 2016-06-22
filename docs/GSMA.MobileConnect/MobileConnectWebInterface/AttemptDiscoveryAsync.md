MobileConnectWebInterface.AttemptDiscoveryAsync Method
======================================================
Attempt discovery using the supplied parameters. If msisdn, mcc and mnc are null the result will be operator selection, otherwise valid parameters will result in a StartAuthorization status

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> AttemptDiscoveryAsync(
	HttpRequestMessage request,
	string msisdn,
	string mcc,
	string mnc,
	bool shouldProxyCookies,
	MobileConnectRequestOptions options
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][2]  
Originating web request

##### *msisdn*
Type: [System.String][3]  
MSISDN from user

##### *mcc*
Type: [System.String][3]  
Mobile Country Code

##### *mnc*
Type: [System.String][3]  
Mobile Network Code

##### *shouldProxyCookies*
Type: [System.Boolean][4]  
If cookies from the original request should be sent onto the discovery service

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
[4]: http://msdn.microsoft.com/en-us/library/a28wyd50
[5]: ../MobileConnectRequestOptions/README.md
[6]: http://msdn.microsoft.com/en-us/library/dd321424
[7]: ../MobileConnectStatus/README.md
[8]: README.md
[9]: ../../_icons/Help.png