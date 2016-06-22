HttpUtils.ExtractQueryValue Method
==================================
Extracts an unescaped value from the query string if found

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static string ExtractQueryValue(
	string queryString,
	string key
)
```

#### Parameters

##### *queryString*
Type: [System.String][2]  
Full query string or url with query string

##### *key*
Type: [System.String][2]  
Key to be extracted from query

#### Return Value
Type: [String][2]  
Unescaped value of key if found, otherwise null

Remarks
-------
If key exists multiple times in query string the last value will be returned

See Also
--------

#### Reference
[HttpUtils Class][3]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png