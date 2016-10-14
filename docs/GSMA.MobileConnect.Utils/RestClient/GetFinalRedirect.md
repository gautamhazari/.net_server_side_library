RestClient.GetFinalRedirect Method
==================================
Attempts to follow a redirect path until a concrete url is loaded or the expectedRedirectUrl is reached

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<Uri> GetFinalRedirect(
	string targetUrl,
	string expectedRedirectUrl,
	int pollFrequencyInMs,
	int maxRedirects,
	CancellationToken cancellationToken = null
)
```

#### Parameters

##### *targetUrl*
Type: [System.String][2]  
Target uri to attempt a HTTP GET

##### *expectedRedirectUrl*
Type: [System.String][2]  
Redirect url expected, if a redirect with this location is hit the absolute uri of the location will be returned

##### *pollFrequencyInMs*
Type: [System.Int32][3]  

[Missing &lt;param name="pollFrequencyInMs"/> documentation for "M:GSMA.MobileConnect.Utils.RestClient.GetFinalRedirect(System.String,System.String,System.Int32,System.Int32,System.Threading.CancellationToken)"]


##### *maxRedirects*
Type: [System.Int32][3]  

[Missing &lt;param name="maxRedirects"/> documentation for "M:GSMA.MobileConnect.Utils.RestClient.GetFinalRedirect(System.String,System.String,System.Int32,System.Int32,System.Threading.CancellationToken)"]


##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][4]  
Cancellation token to allow cancellation of long running request if required

#### Return Value
Type: [Task][5]&lt;[Uri][6]>  
Final redirected url

See Also
--------

#### Reference
[RestClient Class][7]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/td2s409d
[4]: http://msdn.microsoft.com/en-us/library/dd384802
[5]: http://msdn.microsoft.com/en-us/library/dd321424
[6]: http://msdn.microsoft.com/en-us/library/txt7706a
[7]: README.md
[8]: ../../_icons/Help.png