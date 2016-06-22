RestClient.PostAsync Method (String, String, IEnumerable&lt;BasicKeyValuePair>, String, IEnumerable&lt;BasicKeyValuePair>)
==========================================================================================================================
Executes a HTTP POST to the supplied uri with x-www-form-urlencoded content and optional cookies

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public virtual Task<RestResponse> PostAsync(
	string uri,
	string basicAuthenticationEncoded,
	IEnumerable<BasicKeyValuePair> formData,
	string sourceIp,
	IEnumerable<BasicKeyValuePair> cookies = null
)
```

#### Parameters

##### *uri*
Type: [System.String][2]  
Base uri of the POST

##### *basicAuthenticationEncoded*
Type: [System.String][2]  
Encoded basic authenticaion string (if auth required)

##### *formData*
Type: [System.Collections.Generic.IEnumerable][3]&lt;[BasicKeyValuePair][4]>  
Form data to be added as POST content

##### *sourceIp*
Type: [System.String][2]  
Source request IP (if identified)

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