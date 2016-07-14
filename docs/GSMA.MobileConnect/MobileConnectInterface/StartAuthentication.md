MobileConnectInterface.StartAuthentication Method
=================================================
Creates an authorization url with parameters to begin the authorization process

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public MobileConnectStatus StartAuthentication(
	DiscoveryResponse discoveryResponse,
	string encryptedMSISDN,
	string state,
	string nonce,
	MobileConnectRequestOptions options
)
```

#### Parameters

##### *discoveryResponse*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][2]  
The response returned by the discovery process

##### *encryptedMSISDN*
Type: [System.String][3]  
Encrypted MSISDN/Subscriber Id returned from the Discovery process

##### *state*
Type: [System.String][3]  
Unique state value, this will be returned by the authorization process and should be checked for equality as a security measure

##### *nonce*
Type: [System.String][3]  
Unique value to associate a client session with an id token

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][4]  
Optional parameters

#### Return Value
Type: [MobileConnectStatus][5]  
MobileConnectStatus object with required information for continuing the mobileconnect process

See Also
--------

#### Reference
[MobileConnectInterface Class][6]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../MobileConnectRequestOptions/README.md
[5]: ../MobileConnectStatus/README.md
[6]: README.md
[7]: ../../_icons/Help.png