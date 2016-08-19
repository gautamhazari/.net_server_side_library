JWKeyset.MarkExpired Method
===========================
Mark the object as expired, this method should only cause HasExpired to move from false to true, not true to false

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public void MarkExpired(
	bool isExpired
)
```

#### Parameters

##### *isExpired*
Type: [System.Boolean][2]  
True if should mark object as expired

#### Implements
[ICacheable.MarkExpired(Boolean)][3]  


See Also
--------

#### Reference
[JWKeyset Class][4]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/a28wyd50
[3]: ../../GSMA.MobileConnect.Cache/ICacheable/MarkExpired.md
[4]: README.md
[5]: ../../_icons/Help.png