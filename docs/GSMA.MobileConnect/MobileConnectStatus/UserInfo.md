MobileConnectStatus.UserInfo Method
===================================
Creates a status with ResponseType UserInfo and the complete [IdentityResponse][1]. Indicates that a user info request has been successful.

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static MobileConnectStatus UserInfo(
	IdentityResponse response,
	string caller = null
)
```

#### Parameters

##### *response*
Type: [GSMA.MobileConnect.Identity.IdentityResponse][3]  
UserInfoResponse returned from [IIdentityService][4]

##### *caller* (Optional)
Type: [System.String][5]  
Name of calling method

#### Return Value
Type: [MobileConnectStatus][6]  
MobileConnectStatus with ResponseType UserInfo

See Also
--------

#### Reference
[MobileConnectStatus Class][6]  
[GSMA.MobileConnect Namespace][2]  

[1]: IdentityResponse.md
[2]: ../README.md
[3]: ../../GSMA.MobileConnect.Identity/IdentityResponse/README.md
[4]: ../../GSMA.MobileConnect.Identity/IIdentityService/README.md
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: README.md
[7]: ../../_icons/Help.png