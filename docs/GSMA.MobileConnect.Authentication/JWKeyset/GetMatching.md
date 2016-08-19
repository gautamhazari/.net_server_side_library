JWKeyset.GetMatching Method
===========================
Return all keys matching the predicate

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public IEnumerable<JWKey> GetMatching(
	Func<JWKey, bool> predicate
)
```

#### Parameters

##### *predicate*
Type: [System.Func][2]&lt;[JWKey][3], [Boolean][4]>  
A function to test each key for eligibility

#### Return Value
Type: [IEnumerable][5]&lt;[JWKey][3]>  
Ienumerable containing matching elements

See Also
--------

#### Reference
[JWKeyset Class][6]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/bb549151
[3]: ../JWKey/README.md
[4]: http://msdn.microsoft.com/en-us/library/a28wyd50
[5]: http://msdn.microsoft.com/en-us/library/9eekhta0
[6]: README.md
[7]: ../../_icons/Help.png