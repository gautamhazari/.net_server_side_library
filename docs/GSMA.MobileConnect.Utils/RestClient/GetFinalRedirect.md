RestClient.GetFinalRedirect Method
==================================
Attempts to follow a redirect path until a concrete url is loaded or the expectedRedirectUrl is reached

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<Uri> GetFinalRedirect(
	string uri,
	string expectedRedirectUrl,
	CancellationToken cancellationToken = null
)
```

#### Parameters

##### *uri*
Type: [System.String][2]  
Target uri to attempt a HTTP GET

##### *expectedRedirectUrl*
Type: [System.String][2]  
Redirect url expected, if a redirect with this location is hit the absolute uri of the location will be returned

##### *cancellationToken* (Optional)
Type: [System.Threading.CancellationToken][3]  
Cancellation token to allow cancellation of long running request if required

#### Return Value
Type: [Task][4]&lt;[Uri][5]>  
Final redirected url

See Also
--------

#### Reference
[RestClient Class][6]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd384802
[4]: http://msdn.microsoft.com/en-us/library/dd321424
[5]: http://msdn.microsoft.com/en-us/library/txt7706a
[6]: README.md
[7]: ../../_icons/Help.png