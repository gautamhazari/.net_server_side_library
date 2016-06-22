IDiscoveryCache.SetCacheExpiryTime&lt;T> Method
===============================================
Set length of time before cached values of the specified type are marked as expired.

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
void SetCacheExpiryTime<T>(
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


See Also
--------

#### Reference
[IDiscoveryCache Interface][3]  
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/269ew577
[3]: README.md
[4]: ../../_icons/Help.png