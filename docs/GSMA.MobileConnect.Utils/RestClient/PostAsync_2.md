RestClient.PostAsync Method (String, RestAuthentication, Object, String, IEnumerable&lt;BasicKeyValuePair>)
===========================================================================================================
Executes a HTTP POST to the supplied uri with application/json content and optional cookies

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public virtual Task<RestResponse> PostAsync(
	string uri,
	RestAuthentication authentication,
	Object content,
	string sourceIp,
	IEnumerable<BasicKeyValuePair> cookies = null
)
```

#### Parameters

##### *uri*
Type: [System.String][2]  
Base uri of the POST

##### *authentication*
Type: [GSMA.MobileConnect.Utils.RestAuthentication][3]  
Authentication value to be used (if auth required)

##### *content*
Type: [System.Object][4]  
Object to be serialized as JSON for POST content

##### *sourceIp*
Type: [System.String][2]  
Source request IP (if identified)

##### *cookies* (Optional)
Type: [System.Collections.Generic.IEnumerable][5]&lt;[BasicKeyValuePair][6]>  
Cookies to be added to the request (if required)

#### Return Value
Type: [Task][7]&lt;[RestResponse][8]>  
RestResponse containing status code, headers and content

See Also
--------

#### Reference
[RestClient Class][9]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../RestAuthentication/README.md
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: http://msdn.microsoft.com/en-us/library/9eekhta0
[6]: ../BasicKeyValuePair/README.md
[7]: http://msdn.microsoft.com/en-us/library/dd321424
[8]: ../RestResponse/README.md
[9]: README.md
[10]: ../../_icons/Help.png