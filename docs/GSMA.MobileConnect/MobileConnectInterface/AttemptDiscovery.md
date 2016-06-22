MobileConnectInterface.AttemptDiscovery Method
==============================================
Synchronous wrapper for [AttemptDiscoveryAsync(String, String, String, MobileConnectRequestOptions)][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public MobileConnectStatus AttemptDiscovery(
	string msisdn,
	string mcc,
	string mnc,
	MobileConnectRequestOptions options
)
```

#### Parameters

##### *msisdn*
Type: [System.String][3]  
MSISDN from user

##### *mcc*
Type: [System.String][3]  
Mobile Country Code

##### *mnc*
Type: [System.String][3]  
Mobile Network Code

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
[GSMA.MobileConnect Namespace][2]  

[1]: AttemptDiscoveryAsync.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../MobileConnectRequestOptions/README.md
[5]: ../MobileConnectStatus/README.md
[6]: README.md
[7]: ../../_icons/Help.png