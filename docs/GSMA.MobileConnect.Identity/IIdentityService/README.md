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


Methods
-------

                 | Name                                                  | Description                                                                                                                                                                                                                                            
---------------- | ----------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public method] | [RequestUserInfo(String, String, ClaimsParameter)][2] | Convenience method alternative to [RequestUserInfo(String, String, String)][3] so claims can be specified using a ClaimsParameter which will be serialized to JSON                                                                                     
![Public method] | [RequestUserInfo(String, String, String)][3]          | Request the user info for the provided access token. Some of the information returned by the user info service requires the authorization/authentication to be executed with additional scope values e.g. phone number [MOBILECONNECTIDENTITYPHONE][4] 


See Also
--------

#### Reference
[GSMA.MobileConnect.Identity Namespace][1]  
[GSMA.MobileConnect.Identity.IdentityService][5]  

[1]: ../README.md
[2]: RequestUserInfo.md
[3]: RequestUserInfo_1.md
[4]: ../../GSMA.MobileConnect/MobileConnectConstants/MOBILECONNECTIDENTITYPHONE.md
[5]: ../IdentityService/README.md
[6]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"