RestClient.PostAsync Method (String, RestAuthentication, HttpContent, String, IEnumerable&lt;BasicKeyValuePair>)
================================================================================================================
Executes a HTTP POST to the supplied uri with the supplied HttpContent object, with optional cookies. Used as the base for other PostAsync methods.

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
protected virtual Task<RestResponse> PostAsync(
	string uri,
	RestAuthentication authentication,
	HttpContent content,
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
Type: [System.Net.Http.HttpContent][4]  
Content of the POST request

##### *sourceIp*
Type: [System.String][2]  
Source request IP (if identified)

##### *cookies* (Optional)
Type: [System.Collections.Generic.IEnumerable][5]&lt;[BasicKeyValuePair][6]>  
Cookies to be added to the request (if required)

#### Return Value
Type: [Task][7]&lt;[RestResponse][8]>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Utils.RestClient.PostAsync(System.String,GSMA.MobileConnect.Utils.RestAuthentication,System.Net.Http.HttpContent,System.String,System.Collections.Generic.IEnumerable{GSMA.MobileConnect.Utils.BasicKeyValuePair})"]


See Also
--------

#### Reference
[RestClient Class][9]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../RestAuthentication/README.md
[4]: http://msdn.microsoft.com/en-us/library/hh193687
[5]: http://msdn.microsoft.com/en-us/library/9eekhta0
[6]: ../BasicKeyValuePair/README.md
[7]: http://msdn.microsoft.com/en-us/library/dd321424
[8]: ../RestResponse/README.md
[9]: README.md
[10]: ../../_icons/Help.png