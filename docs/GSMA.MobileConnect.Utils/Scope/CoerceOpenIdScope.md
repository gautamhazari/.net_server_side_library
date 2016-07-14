Scope.CoerceOpenIdScope Method (IList&lt;String>, String)
=========================================================
Returns a list of scope values that is ensured to contain the defaultScope values and has any duplication of values removed. This can be used when multiple modifications of scope are required to be chained

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static List<string> CoerceOpenIdScope(
	IList<string> scopeValues,
	string defaultScope = "openid"
)
```

#### Parameters

##### *scopeValues*
Type: [System.Collections.Generic.IList][2]&lt;[String][3]>  
Scope to coerce

##### *defaultScope* (Optional)
Type: [System.String][3]  
Required default scope

#### Return Value
Type: [List][4]&lt;[String][3]>  
List of scope values containing default scope values and no duplicated values

See Also
--------

#### Reference
[Scope Class][5]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/5y536ey6
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/6sh2ey19
[5]: README.md
[6]: ../../_icons/Help.png