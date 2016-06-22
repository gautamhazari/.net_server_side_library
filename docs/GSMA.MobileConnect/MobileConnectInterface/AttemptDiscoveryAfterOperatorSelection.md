MobileConnectInterface.AttemptDiscoveryAfterOperatorSelection Method
====================================================================
Synchronous wrapper for [AttemptDiscoveryAfterOperatorSelectionAsync(Uri)][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public MobileConnectStatus AttemptDiscoveryAfterOperatorSelection(
	Uri redirectedUrl
)
```

#### Parameters

##### *redirectedUrl*
Type: [System.Uri][3]  
Uri redirected to by the completion of the operator selection UI

#### Return Value
Type: [MobileConnectStatus][4]  
MobileConnectStatus object with required information for continuing the mobileconnect process

See Also
--------

#### Reference
[MobileConnectInterface Class][5]  
[GSMA.MobileConnect Namespace][2]  

[1]: AttemptDiscoveryAfterOperatorSelectionAsync.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/txt7706a
[4]: ../MobileConnectStatus/README.md
[5]: README.md
[6]: ../../_icons/Help.png