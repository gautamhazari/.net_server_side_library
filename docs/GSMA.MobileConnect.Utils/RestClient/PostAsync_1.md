RestClient.PostAsync Method (String, String, HttpContent, String, IEnumerable&lt;BasicKeyValuePair>)
====================================================================================================
Executes a HTTP POST to the supplied uri with the supplied HttpContent object, with optional cookies. Used as the base for other PostAsync methods.

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
protected virtual Task<RestResponse> PostAsync(
	string uri,
	string basicAuthenticationEncoded,
	HttpContent content,
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

##### *content*
Type: [System.Net.Http.HttpContent][3]  
Content of the POST request

##### *sourceIp*
Type: [System.String][2]  
Source request IP (if identified)

##### *cookies* (Optional)
Type: [System.Collections.Generic.IEnumerable][4]&lt;[BasicKeyValuePair][5]>  
Cookies to be added to the request (if required)

#### Return Value
Type: [Task][6]&lt;[RestResponse][7]>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Utils.RestClient.PostAsync(System.String,System.String,System.Net.Http.HttpContent,System.String,System.Collections.Generic.IEnumerable{GSMA.MobileConnect.Utils.BasicKeyValuePair})"]


See Also
--------

#### Reference
[RestClient Class][8]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/hh193687
[4]: http://msdn.microsoft.com/en-us/library/9eekhta0
[5]: ../BasicKeyValuePair/README.md
[6]: http://msdn.microsoft.com/en-us/library/dd321424
[7]: ../RestResponse/README.md
[8]: README.md
[9]: ../../_icons/Help.png