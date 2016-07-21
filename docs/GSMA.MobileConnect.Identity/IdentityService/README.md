IdentityService Class
=====================
Implementation of [IIdentityService][1] interface


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Identity.IdentityService**  

**Namespace:** [GSMA.MobileConnect.Identity][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class IdentityService : IIdentityService
```

The **IdentityService** type exposes the following members.


Constructors
------------

                 | Name                 | Description                                                                                              
---------------- | -------------------- | -------------------------------------------------------------------------------------------------------- 
![Public method] | [IdentityService][4] | Creates a new instance of the class IdentityService using the specified RestClient for all HTTP requests 


Methods
-------

                 | Name                 | Description                                                                                                                                                                                                                     
---------------- | -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [RequestIdentity][5] | Request the identity for the provided access token. Information returned by the identity service requires the authorization to be executed with additional scope values e.g. phone number [MOBILECONNECTIDENTITYPHONE][6]       
![Public method] | [RequestUserInfo][7] | Request the user info for the provided access token. Some of the information returned by the user info service requires the authorization/authentication to be executed with additional scope values e.g. email => openid email 


See Also
--------

#### Reference
[GSMA.MobileConnect.Identity Namespace][3]  

[1]: ../IIdentityService/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: RequestIdentity.md
[6]: ../../GSMA.MobileConnect/MobileConnectConstants/MOBILECONNECTIDENTITYPHONE.md
[7]: RequestUserInfo.md
[8]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"