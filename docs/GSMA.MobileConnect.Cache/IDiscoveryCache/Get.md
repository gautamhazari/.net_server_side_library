IDiscoveryCache.Get Method (String, String)
===========================================
Return a cached value based on the mcc and mnc

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
Task<DiscoveryResponse> Get(
	string mcc,
	string mnc
)
```

#### Parameters

##### *mcc*
Type: [System.String][2]  
Mobile Country Code (Required)

##### *mnc*
Type: [System.String][2]  
Mobile Network Code (Required)

#### Return Value
Type: [Task][3]&lt;[DiscoveryResponse][4]>  
The cached value if present, null otherwise

See Also
--------

#### Reference
[IDiscoveryCache Interface][5]  
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[5]: README.md
[6]: ../../_icons/Help.png