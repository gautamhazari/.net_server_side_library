BaseCache.CheckIsExpired Method
===============================
Checks if a object has been cached past the defined caching time or if internally the object has been marked as expired

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
protected bool CheckIsExpired(
	ICacheable value
)
```

#### Parameters

##### *value*
Type: [GSMA.MobileConnect.Cache.ICacheable][2]  
Object to check for expiry

#### Return Value
Type: [Boolean][3]  
True if the object has expired

See Also
--------

#### Reference
[BaseCache Class][4]  
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: ../ICacheable/README.md
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: README.md
[5]: ../../_icons/Help.png