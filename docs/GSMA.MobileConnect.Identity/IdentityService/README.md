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
---------------- | -------------------- | ----------------------------------------------------------- 
![Public method] | [IdentityService][4] | Initializes a new instance of the **IdentityService** class 


Methods
-------

                 | Name                                                  | Description                                                                                                                                                                                                                                            
---------------- | ----------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public method] | [RequestUserInfo(String, String, ClaimsParameter)][5] | Convenience method alternative to [RequestUserInfo(String, String, String)][6] so claims can be specified using a ClaimsParameter which will be serialized to JSON                                                                                     
![Public method] | [RequestUserInfo(String, String, String)][7]          | Request the user info for the provided access token. Some of the information returned by the user info service requires the authorization/authentication to be executed with additional scope values e.g. phone number [MOBILECONNECTIDENTITYPHONE][8] 


See Also
--------

#### Reference
[GSMA.MobileConnect.Identity Namespace][3]  

[1]: ../IIdentityService/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: RequestUserInfo.md
[6]: ../IIdentityService/RequestUserInfo_1.md
[7]: RequestUserInfo_1.md
[8]: ../../GSMA.MobileConnect/MobileConnectConstants/MOBILECONNECTIDENTITYPHONE.md
[9]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"