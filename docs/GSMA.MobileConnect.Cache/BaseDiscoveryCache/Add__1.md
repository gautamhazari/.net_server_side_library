BaseDiscoveryCache.Add&lt;T> Method (String, T)
===============================================
Add a value with the specified key

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task Add<T>(
	string key,
	T value
)
where T : ICacheable

```

#### Parameters

##### *key*
Type: [System.String][2]  
Key (Required)

##### *value*
Type: **T**  
Value (Required)

#### Type Parameters

##### *T*
Type of value to be added to the cache

#### Return Value
Type: [Task][3]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Cache.BaseDiscoveryCache.Add``1(System.String,``0)"]

#### Implements
[IDiscoveryCache.Add&lt;T>(String, T)][4]  


See Also
--------

#### Reference
[BaseDiscoveryCache Class][5]  
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd235678
[4]: ../IDiscoveryCache/Add__1.md
[5]: README.md
[6]: ../../_icons/Help.png