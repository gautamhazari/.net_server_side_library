MobileConnectStatus.TokenRevoked Method
=======================================
Creates a Status with ResponseType TokenRevoked.

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static MobileConnectStatus TokenRevoked(
	RevokeTokenResponse response,
	string caller = null
)
```

#### Parameters

##### *response*
Type: [GSMA.MobileConnect.Authentication.RevokeTokenResponse][2]  
RevokeTokenResponse returned from [IAuthenticationService][3]

##### *caller* (Optional)
Type: [System.String][4]  
Name of calling method

#### Return Value
Type: [MobileConnectStatus][5]  
MobileConnectStatus with ResponseType TokenRevoked

See Also
--------

#### Reference
[MobileConnectStatus Class][5]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: ../../GSMA.MobileConnect.Authentication/RevokeTokenResponse/README.md
[3]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: README.md
[6]: ../../_icons/Help.png