ConcurrentDiscoveryCache.Get Method (String, String)
====================================================
Retrieves a copy of the cached response if found and has not expired

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<DiscoveryResponse> Get(
	string mcc,
	string mnc
)
```

#### Parameters

##### *mcc*
Type: [System.String][2]  
Mobile Country Code

##### *mnc*
Type: [System.String][2]  
Mobile Network Code

#### Return Value
Type: [Task][3]&lt;[DiscoveryResponse][4]>  
A copy of the cached value or null if no cached value or cached value has expired
#### Implements
[IDiscoveryCache.Get(String, String)][5]  


See Also
--------

#### Reference
[ConcurrentDiscoveryCache Class][6]  
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[5]: ../IDiscoveryCache/Get_1.md
[6]: README.md
[7]: ../../_icons/Help.png