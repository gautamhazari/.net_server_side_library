IIdentityService Interface
==========================
Interface for Mobile Connect UserInfo and Identity related requests

**Namespace:** [GSMA.MobileConnect.Identity][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public interface IIdentityService
```

The **IIdentityService** type exposes the following members.


Methods
-------

                 | Name                 | Description                                                                                                                                                                                                                     
---------------- | -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [RequestIdentity][2] | Request the identity for the provided access token. Information returned by the identity service requires the authorization to be executed with additional scope values e.g. phone number [MOBILECONNECTIDENTITYPHONE][3]       
![Public method] | [RequestUserInfo][4] | Request the user info for the provided access token. Some of the information returned by the user info service requires the authorization/authentication to be executed with additional scope values e.g. email => openid email 


See Also
--------

#### Reference
[GSMA.MobileConnect.Identity Namespace][1]  
[GSMA.MobileConnect.Identity.IdentityService][5]  

[1]: ../README.md
[2]: RequestIdentity.md
[3]: ../../GSMA.MobileConnect/MobileConnectConstants/MOBILECONNECTIDENTITYPHONE.md
[4]: RequestUserInfo.md
[5]: ../IdentityService/README.md
[6]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"