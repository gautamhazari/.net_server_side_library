MobileConnectInterface.AttemptDiscoveryAsync Method
===================================================
Attempt discovery using the supplied parameters. If msisdn, mcc and mnc are null the result will be operator selection, otherwise valid parameters will result in a StartAuthorization status

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> AttemptDiscoveryAsync(
	string msisdn,
	string mcc,
	string mnc,
	MobileConnectRequestOptions options
)
```

#### Parameters

##### *msisdn*
Type: [System.String][2]  
MSISDN from user

##### *mcc*
Type: [System.String][2]  
Mobile Country Code

##### *mnc*
Type: [System.String][2]  
Mobile Network Code

##### *options*
Type: [GSMA.MobileConnect.MobileConnectRequestOptions][3]  
Optional parameters

#### Return Value
Type: [Task][4]&lt;[MobileConnectStatus][5]>  
MobileConnectStatus object with required information for continuing the mobileconnect process

See Also
--------

#### Reference
[MobileConnectInterface Class][6]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../MobileConnectRequestOptions/README.md
[4]: http://msdn.microsoft.com/en-us/library/dd321424
[5]: ../MobileConnectStatus/README.md
[6]: README.md
[7]: ../../_icons/Help.png