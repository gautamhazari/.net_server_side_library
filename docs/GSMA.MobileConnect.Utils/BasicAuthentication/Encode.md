BasicAuthentication.Encode Method
=================================
Encodes the provided id and secret ready for use with basic authentication

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static string Encode(
	string clientId,
	string secret
)
```

#### Parameters

##### *clientId*
Type: [System.String][2]  
Registered application client id

##### *secret*
Type: [System.String][2]  
Registered application client secret

#### Return Value
Type: [String][2]  
Base64 encoded string

See Also
--------

#### Reference
[BasicAuthentication Class][3]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png