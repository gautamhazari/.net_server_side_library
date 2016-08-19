ConcurrentCache.InternalGet&lt;T> Method
========================================
Get value from internal cache with given key

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
protected override Task<T> InternalGet<T>(
	string key
)
where T : ICacheable

```

#### Parameters

##### *key*
Type: [System.String][2]  
Cache key to return

#### Type Parameters

##### *T*
Type to be returned from cache

#### Return Value
Type: [Task][3]&lt;**T**>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Cache.ConcurrentCache.InternalGet``1(System.String)"]


See Also
--------

#### Reference
[ConcurrentCache Class][4]  
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: README.md
[5]: ../../_icons/Help.png