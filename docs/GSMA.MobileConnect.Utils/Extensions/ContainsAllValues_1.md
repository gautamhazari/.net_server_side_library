Extensions.ContainsAllValues Method (IEnumerable&lt;String>, String, StringComparison, Char[])
==============================================================================================
Checks for the IEnumerable to contain all the values specified in the values string after being separated using the separators

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static bool ContainsAllValues(
	this IEnumerable<string> enumerable,
	string values,
	StringComparison stringComparison,
	params char[] separators
)
```

#### Parameters

##### *enumerable*
Type: [System.Collections.Generic.IEnumerable][2]&lt;[String][3]>  
IEnumerable with available values

##### *values*
Type: [System.String][3]  
Values required as a delimited string

##### *stringComparison*
Type: [System.StringComparison][4]  
One of the enumeration values that specifies the rules of comparison

##### *separators*
Type: [System.Char][5][]  
Delimiters for values string, if not supplied the string will be split on whitespace characters

#### Return Value
Type: [Boolean][6]  
True if all tokens in the values string are present in the enumerable
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
[4]: http://msdn.microsoft.com/en-us/library/8d9k4871
[5]: http://msdn.microsoft.com/en-us/library/k493b04s
[6]: http://msdn.microsoft.com/en-us/library/a28wyd50
[7]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[8]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[9]: README.md
[10]: ../../_icons/Help.png