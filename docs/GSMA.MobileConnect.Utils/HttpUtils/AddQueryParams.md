HttpUtils.AddQueryParams Method
===============================
Extension method to add list of queryparams to a UriBuilder as a querystring

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static void AddQueryParams(
	this UriBuilder builder,
	IEnumerable<BasicKeyValuePair> queryParams
)
```

#### Parameters

##### *builder*
Type: [System.UriBuilder][2]  
Builder to add query string to

##### *queryParams*
Type: [System.Collections.Generic.IEnumerable][3]&lt;[BasicKeyValuePair][4]>  
List of params to add to query string

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type [UriBuilder][2]. When you use instance method syntax to call this method, omit the first parameter. For more information, see [Extension Methods (Visual Basic)][5] or [Extension Methods (C# Programming Guide)][6].

See Also
--------

#### Reference
[HttpUtils Class][7]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/0tf6x8z6
[3]: http://msdn.microsoft.com/en-us/library/9eekhta0
[4]: ../BasicKeyValuePair/README.md
[5]: http://msdn.microsoft.com/en-us/library/bb384936.aspx
[6]: http://msdn.microsoft.com/en-us/library/bb383977.aspx
[7]: README.md
[8]: ../../_icons/Help.png