MobileConnectStatus.Identity Method
===================================
Creates a status with ResponseType Identity and the complete [IdentityResponse][1]. Indicates that an identity request has been successful.

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static MobileConnectStatus Identity(
	IdentityResponse response
)
```

#### Parameters

##### *response*
Type: [GSMA.MobileConnect.Identity.IdentityResponse][3]  
UserInfoResponse returned from [IIdentityService][4]

#### Return Value
Type: [MobileConnectStatus][5]  
MobileConnectStatus with ResponseType Identity

See Also
--------

#### Reference
[MobileConnectStatus Class][5]  
[GSMA.MobileConnect Namespace][2]  

[1]: IdentityResponse.md
[2]: ../README.md
[3]: ../../GSMA.MobileConnect.Identity/IdentityResponse/README.md
[4]: ../../GSMA.MobileConnect.Identity/IIdentityService/README.md
[5]: README.md
[6]: ../../_icons/Help.png