HttpUtils.ProxyRequiredCookies Method
=====================================
Filters a list of cookies to return only the cookies required

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static List<BasicKeyValuePair> ProxyRequiredCookies(
	IEnumerable<string> requiredCookies,
	IEnumerable<BasicKeyValuePair> currentCookies
)
```

#### Parameters

##### *requiredCookies*
Type: [System.Collections.Generic.IEnumerable][2]&lt;[String][3]>  
List of required cookie keys

##### *currentCookies*
Type: [System.Collections.Generic.IEnumerable][2]&lt;[BasicKeyValuePair][4]>  
Complete list of cookies from originating Http request

#### Return Value
Type: [List][5]&lt;[BasicKeyValuePair][4]>  
List containing only cookies with keys in requiredCookies

See Also
--------

#### Reference
[HttpUtils Class][6]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/9eekhta0
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../BasicKeyValuePair/README.md
[5]: http://msdn.microsoft.com/en-us/library/6sh2ey19
[6]: README.md
[7]: ../../_icons/Help.png