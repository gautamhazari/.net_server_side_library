Extensions.RemoveFromDelimitedString Method
===========================================
Remove a specified value from a delimited string if found

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static string RemoveFromDelimitedString(
	this string value,
	string toRemove,
	StringComparison stringComparison,
	Nullable<char> separator = null
)
```

#### Parameters

##### *value*
Type: [System.String][2]  
Delimited string to remove value from

##### *toRemove*
Type: [System.String][2]  
Value to remove

##### *stringComparison*
Type: [System.StringComparison][3]  
One of the enumeration values that specifies the rules of comparison

##### *separator* (Optional)
Type: [System.Nullable][4]&lt;[Char][5]>  
Seperator to split and join values on, if null will split on whitespace and join using the space character

#### Return Value
Type: [String][2]  
String with instance of toRemove removed
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [String][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][6] or [Extension Methods (C# Programming Guide)][7].

See Also
--------

#### Reference
[Extensions Class][8]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/8d9k4871
[4]: http://msdn.microsoft.com/en-us/library/b3h38hb0
[5]: http://msdn.microsoft.com/en-us/library/k493b04s
[6]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[7]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[8]: README.md
[9]: ../../_icons/Help.png