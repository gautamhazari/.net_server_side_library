MobileConnectWebInterface.AttemptDiscoveryAfterOperatorSelectionAsync Method
============================================================================
Attempt discovery using the values returned from the operator selection redirect

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> AttemptDiscoveryAfterOperatorSelectionAsync(
	HttpRequestMessage request,
	Uri redirectedUrl
)
```

#### Parameters

##### *request*
Type: [System.Net.Http.HttpRequestMessage][2]  
Originating web request

##### *redirectedUrl*
Type: [System.Uri][3]  
Uri redirected to by the completion of the operator selection UI

#### Return Value
Type: [Task][4]&lt;[MobileConnectStatus][5]>  
MobileConnectStatus object with required information for continuing the mobileconnect process

See Also
--------

#### Reference
[MobileConnectWebInterface Class][6]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/hh159020
[3]: http://msdn.microsoft.com/en-us/library/txt7706a
[4]: http://msdn.microsoft.com/en-us/library/dd321424
[5]: ../MobileConnectStatus/README.md
[6]: README.md
[7]: ../../_icons/Help.png