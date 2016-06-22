RestClient.GetAsync Method
==========================
Executes a HTTP GET to the supplied uri with optional basic auth, cookies and query params

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public virtual Task<RestResponse> GetAsync(
	string uri,
	string basicAuthenticationEncoded,
	string sourceIp = null,
	IEnumerable<BasicKeyValuePair> queryParams = null,
	IEnumerable<BasicKeyValuePair> cookies = null
)
```

#### Parameters

##### *uri*
Type: [System.String][2]  
Base uri of GET request

##### *basicAuthenticationEncoded*
Type: [System.String][2]  
Encoded basic authenticaion string (if auth required)

##### *sourceIp* (Optional)
Type: [System.String][2]  
Source request IP (if identified)

##### *queryParams* (Optional)
Type: [System.Collections.Generic.IEnumerable][3]&lt;[BasicKeyValuePair][4]>  
Query params to be added to the base url (if required)

##### *cookies* (Optional)
Type: [System.Collections.Generic.IEnumerable][3]&lt;[BasicKeyValuePair][4]>  
Cookies to be added to the request (if required)

#### Return Value
Type: [Task][5]&lt;[RestResponse][6]>  
RestResponse containing status code, headers and content

See Also
--------

#### Reference
[RestClient Class][7]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/9eekhta0
[4]: ../BasicKeyValuePair/README.md
[5]: http://msdn.microsoft.com/en-us/library/dd321424
[6]: ../RestResponse/README.md
[7]: README.md
[8]: ../../_icons/Help.png