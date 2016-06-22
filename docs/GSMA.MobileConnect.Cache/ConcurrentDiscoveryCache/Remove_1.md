ConcurrentDiscoveryCache.Remove Method (String, String)
=======================================================
Remove an entry from the cache that matches the mcc and mnc

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public override Task Remove(
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
Type: [Task][3]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Cache.ConcurrentDiscoveryCache.Remove(System.String,System.String)"]

#### Implements
[IDiscoveryCache.Remove(String, String)][4]  


See Also
--------

#### Reference
[ConcurrentDiscoveryCache Class][5]  
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd235678
[4]: ../IDiscoveryCache/Remove_1.md
[5]: README.md
[6]: ../../_icons/Help.png