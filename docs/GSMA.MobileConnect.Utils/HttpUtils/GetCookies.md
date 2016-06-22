HttpUtils.GetCookies Method
===========================
Extension method to retrieve all cookies from a [HttpRequestMessage][1] in the form of KeyValue pairs

**Namespace:** [GSMA.MobileConnect.Utils][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static IEnumerable<BasicKeyValuePair> GetCookies(
	this HttpRequestMessage request
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][1]  
Request with cookies

#### Return Value
Type: [IEnumerable][3]&lt;[BasicKeyValuePair][4]>  
List of cookies or null if Cookie header does not exist
#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [HttpRequestMessage][1]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

See Also
--------

#### Reference
[HttpUtils Class][7]  
[GSMA.MobileConnect.Utils Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/hh159020
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/9eekhta0
[4]: ../BasicKeyValuePair/README.md
[5]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[6]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[7]: README.md
[8]: ../../_icons/Help.png