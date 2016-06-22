BaseDiscoveryCache.SetCacheExpiryTime&lt;T> Method
==================================================
Set length of time before cached values of the specified type are marked as expired.

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public void SetCacheExpiryTime<T>(
	TimeSpan cacheTime
)
where T : ICacheable

```

#### Parameters

##### *cacheTime*
Type: [System.TimeSpan][2]  
Length of time before expiry

#### Type Parameters

##### *T*
Type of cached value

#### Implements
[IDiscoveryCache.SetCacheExpiryTime&lt;T>(TimeSpan)][3]  


See Also
--------

#### Reference
[BaseDiscoveryCache Class][4]  
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/269ew577
[3]: ../IDiscoveryCache/SetCacheExpiryTime__1.md
[4]: README.md
[5]: ../../_icons/Help.png