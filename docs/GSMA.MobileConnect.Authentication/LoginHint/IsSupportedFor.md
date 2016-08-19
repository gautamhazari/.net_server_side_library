LoginHint.IsSupportedFor Method
===============================
Is login hint with specified prefix supported by the target provider

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static bool IsSupportedFor(
	ProviderMetadata metadata,
	string prefix
)
```

#### Parameters

##### *metadata*
Type: [GSMA.MobileConnect.Discovery.ProviderMetadata][2]  
Provider Metadata received during the discovery phase

##### *prefix*
Type: [System.String][3]  
Prefix to check for login hint support

#### Return Value
Type: [Boolean][4]  
True if format ${prefix}:xxxxxxxxxx is supported

See Also
--------

#### Reference
[LoginHint Class][5]  
[GSMA.MobileConnect.Authentication Namespace][1]  
[GSMA.MobileConnect.Constants.LoginHintPrefixes][6]  

[1]: ../README.md
[2]: ../../GSMA.MobileConnect.Discovery/ProviderMetadata/README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/a28wyd50
[5]: README.md
[6]: ../../GSMA.MobileConnect.Constants/LoginHintPrefixes/README.md
[7]: ../../_icons/Help.png