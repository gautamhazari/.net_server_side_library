LoginHint.IsSupportedForPCR Method
==================================
Is login hint with PCR (Pseudonymous Customer Reference) supported by the target provider

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static bool IsSupportedForPCR(
	ProviderMetadata metadata
)
```

#### Parameters

##### *metadata*
Type: [GSMA.MobileConnect.Discovery.ProviderMetadata][2]  
Provider Metadata received during the discovery phase

#### Return Value
Type: [Boolean][3]  
True if format PCR:xxxxxxxxxx is supported

See Also
--------

#### Reference
[LoginHint Class][4]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: ../../GSMA.MobileConnect.Discovery/ProviderMetadata/README.md
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: README.md
[5]: ../../_icons/Help.png