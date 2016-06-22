Extensions.ContainsAllValues Method (IEnumerable&lt;String>, List&lt;String>, StringComparison)
===============================================================================================
Checks for the IEnumerable to contain all values in the value list

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static bool ContainsAllValues(
	this IEnumerable<string> enumerable,
	List<string> values,
	StringComparison stringComparison
)
```

#### Parameters

##### *enumerable*
Type: [System.Collections.Generic.IEnumerable][2]&lt;[String][3]>  
IEnumerable with available values

##### *values*
Type: [System.Collections.Generic.List][4]&lt;[String][3]>  
Values required

##### *stringComparison*
Type: [System.StringComparison][5]  
One of the enumeration values that specifies the rules of comparison

#### Return Value
Type: [Boolean][6]  
True if all strings in the values list are present in the enumerable
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [IEnumerable][2]&lt;[String][3]>. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][7] or [Extension Methods (C# Programming Guide)][8].

See Also
--------

#### Reference
[Extensions Class][9]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/9eekhta0
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/6sh2ey19
[5]: http://msdn.microsoft.com/en-us/library/8d9k4871
[6]: http://msdn.microsoft.com/en-us/library/a28wyd50
[7]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[8]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[9]: README.md
[10]: ../../_icons/Help.png