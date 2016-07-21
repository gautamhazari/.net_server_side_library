IDiscoveryService.GetCachedDiscoveryResultAsync Method
======================================================
Helper function which retrieves a discovery response (if available) from the discovery cache which corresponds with the operator details

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
Task<DiscoveryResponse> GetCachedDiscoveryResultAsync(
	string mcc,
	string mnc
)
```

#### Parameters

##### *mcc*
Type: [System.String][2]  
The Mobile Country Code (Required)

##### *mnc*
Type: [System.String][2]  
The Mobile Network Code (Required)

#### Return Value
Type: [Task][3]&lt;[DiscoveryResponse][4]>  
A cached entry if found, otherwise null

See Also
--------

#### Reference
[IDiscoveryService Interface][5]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: ../DiscoveryResponse/README.md
[5]: README.md
[6]: ../../_icons/Help.png