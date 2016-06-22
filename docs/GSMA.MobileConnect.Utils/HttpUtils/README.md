HttpUtils Class
===============
Static Helper Class containing various methods and extensions required for Http Requests


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Utils.HttpUtils**  

**Namespace:** [GSMA.MobileConnect.Utils][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static class HttpUtils
```

The **HttpUtils** type exposes the following members.


Methods
-------

                                 | Name                      | Description                                                                                           
-------------------------------- | ------------------------- | ----------------------------------------------------------------------------------------------------- 
![Public method]![Static member] | [AddQueryParams][3]       | Extension method to add list of queryparams to a UriBuilder as a querystring                          
![Public method]![Static member] | [ExtractQueryValue][4]    | Extracts an unescaped value from the query string if found                                            
![Public method]![Static member] | [GetCookies][5]           | Extension method to retrieve all cookies from a [HttpRequestMessage][6] in the form of KeyValue pairs 
![Public method]![Static member] | [IsHttpErrorCode][7]      | Returns true if status code is an error type (400s and 500s)                                          
![Public method]![Static member] | [ParseQueryString][8]     | Parses a query string to return a dictionary of all key/value pairs                                   
![Public method]![Static member] | [ProxyRequiredCookies][9] | Filters a list of cookies to return only the cookies required                                         


See Also
--------

#### Reference
[GSMA.MobileConnect.Utils Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: AddQueryParams.md
[4]: ExtractQueryValue.md
[5]: GetCookies.md
[6]: http://msdn.microsoft.com/en-us/library/hh159020
[7]: IsHttpErrorCode.md
[8]: ParseQueryString.md
[9]: ProxyRequiredCookies.md
[10]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"