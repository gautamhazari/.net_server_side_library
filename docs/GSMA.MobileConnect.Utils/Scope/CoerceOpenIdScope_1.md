Scope.CoerceOpenIdScope Method (String, String)
===============================================
Returns a scope that is ensured to contain the defaultScope and has any duplication of values removed

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static string CoerceOpenIdScope(
	string scope,
	string defaultScope = "openid"
)
```

#### Parameters

##### *scope*
Type: [System.String][2]  
Scope to coerce

##### *defaultScope* (Optional)
Type: [System.String][2]  
Required default scope

#### Return Value
Type: [String][2]  
Scope containing default scope values and no duplicated values

See Also
--------

#### Reference
[Scope Class][3]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png