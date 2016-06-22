BaseDiscoveryCache.Add Method (String, String, DiscoveryResponse)
=================================================================
Add a value to the cache with the specified mcc and mnc

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task Add(
	string mcc,
	string mnc,
	DiscoveryResponse value
)
```

#### Parameters

##### *mcc*
Type: [System.String][2]  
Mobile Country Code (Required)

##### *mnc*
Type: [System.String][2]  
Mobile Network Code (Required)

##### *value*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][3]  
Value (Required)

#### Return Value
Type: [Task][4]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Cache.BaseDiscoveryCache.Add(System.String,System.String,GSMA.MobileConnect.Discovery.DiscoveryResponse)"]

#### Implements
[IDiscoveryCache.Add(String, String, DiscoveryResponse)][5]  


See Also
--------

#### Reference
[BaseDiscoveryCache Class][6]  
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[4]: http://msdn.microsoft.com/en-us/library/dd235678
[5]: ../IDiscoveryCache/Add.md
[6]: README.md
[7]: ../../_icons/Help.png