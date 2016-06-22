MobileConnectInterface.AttemptDiscoveryAfterOperatorSelectionAsync Method
=========================================================================
Attempt discovery using the values returned from the operator selection redirect

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<MobileConnectStatus> AttemptDiscoveryAfterOperatorSelectionAsync(
	Uri redirectedUrl
)
```

#### Parameters

##### *redirectedUrl*
Type: [System.Uri][2]  
Uri redirected to by the completion of the operator selection UI

#### Return Value
Type: [Task][3]&lt;[MobileConnectStatus][4]>  
MobileConnectStatus object with required information for continuing the mobileconnect process

See Also
--------

#### Reference
[MobileConnectInterface Class][5]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/txt7706a
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: ../MobileConnectStatus/README.md
[5]: README.md
[6]: ../../_icons/Help.png