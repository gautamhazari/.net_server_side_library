ConcurrentDiscoveryCache.Add Method (String, String, DiscoveryResponse)
=======================================================================
Adds the DiscoveryResponse to the cache with the supplied MCC and MNC values

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
Mobile Country Code

##### *mnc*
Type: [System.String][2]  
Mobile Network Code

##### *value*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][3]  
Value to be cached

#### Return Value
Type: [Task][4]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Cache.ConcurrentDiscoveryCache.Add(System.String,System.String,GSMA.MobileConnect.Discovery.DiscoveryResponse)"]

#### Implements
[IDiscoveryCache.Add(String, String, DiscoveryResponse)][5]  


Remarks
-------
Value will not be cached if MCC or MNC are null or empty

See Also
--------

#### Reference
[ConcurrentDiscoveryCache Class][6]  
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[4]: http://msdn.microsoft.com/en-us/library/dd235678
[5]: ../IDiscoveryCache/Add_1.md
[6]: README.md
[7]: ../../_icons/Help.png