MobileConnectStatus.UserInfo Method
===================================
Creates a status with ResponseType UserInfo and the complete [UserInfoResponse][1]. Indicates that a user info request has been successful.

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static MobileConnectStatus UserInfo(
	UserInfoResponse response
)
```

#### Parameters

##### *response*
Type: [GSMA.MobileConnect.Identity.UserInfoResponse][3]  
UserInfoResponse returned from [IIdentityService][4]

#### Return Value
Type: [MobileConnectStatus][5]  
MobileConnectStatus with ResponseType UserInfo

See Also
--------

#### Reference
[MobileConnectStatus Class][5]  
[GSMA.MobileConnect Namespace][2]  

[1]: UserInfoResponse.md
[2]: ../README.md
[3]: ../../GSMA.MobileConnect.Identity/UserInfoResponse/README.md
[4]: ../../GSMA.MobileConnect.Identity/IIdentityService/README.md
[5]: README.md
[6]: ../../_icons/Help.png