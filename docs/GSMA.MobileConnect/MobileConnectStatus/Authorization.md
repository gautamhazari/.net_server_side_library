MobileConnectStatus.Authorization Method
========================================
Creates a Status with ResponseType Authorization and url for next process step. Indicates that the next step should be navigating to the Authorization URL.

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static MobileConnectStatus Authorization(
	string url,
	string state,
	string nonce
)
```

#### Parameters

##### *url*
Type: [System.String][2]  
Url returned from [IAuthenticationService][3]

##### *state*
Type: [System.String][2]  
The unique state string generated or passed in for the authorization url

##### *nonce*
Type: [System.String][2]  
The unique nonce string generated or passed in for the authorization url

#### Return Value
Type: [MobileConnectStatus][4]  
MobileConnectStatus with ResponseType Authorization

See Also
--------

#### Reference
[MobileConnectStatus Class][4]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[4]: README.md
[5]: ../../_icons/Help.png