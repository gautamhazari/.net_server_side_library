RestClient.PostAsync Method (String, RestAuthentication, String, String, String, IEnumerable&lt;BasicKeyValuePair>)
===================================================================================================================
Executes a HTTP POST to the supplied uri with the supplied content type and content, with optional cookies

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public virtual Task<RestResponse> PostAsync(
	string uri,
	RestAuthentication authentication,
	string content,
	string contentType,
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
Type: [System.String][2]  
Content of the POST request

##### *contentType*
Type: [System.String][2]  
Content type of the POST request

##### *sourceIp*
Type: [System.String][2]  
Source request IP (if identified)

##### *cookies* (Optional)
Type: [System.Collections.Generic.IEnumerable][4]&lt;[BasicKeyValuePair][5]>  
Cookies to be added to the request (if required)

#### Return Value
Type: [Task][6]&lt;[RestResponse][7]>  
RestResponse containing status code, headers and content

See Also
--------

#### Reference
[RestClient Class][8]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../RestAuthentication/README.md
[4]: http://msdn.microsoft.com/en-us/library/9eekhta0
[5]: ../BasicKeyValuePair/README.md
[6]: http://msdn.microsoft.com/en-us/library/dd321424
[7]: ../RestResponse/README.md
[8]: README.md
[9]: ../../_icons/Help.png