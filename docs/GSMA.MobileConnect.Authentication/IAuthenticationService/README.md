IAuthenticationService Interface
================================
Interface for the Mobile Connect Requests

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public interface IAuthenticationService
```

The **IAuthenticationService** type exposes the following members.


Methods
-------

                 | Name                     | Description                                                                                                                                                                     
---------------- | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [RequestToken][2]        | Synchronous wrapper for [RequestTokenAsync(String, String, String, String, String)][3]                                                                                          
![Public method] | [RequestTokenAsync][3]   | Allows an application to use the authorization code obtained from authentication/authorization to obtain an access token and related information from the authorization server. 
![Public method] | [StartAuthentication][4] | Generates an authorisation url based on the supplied options and previous discovery response                                                                                    


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][1]  
[GSMA.MobileConnect.Authentication.AuthenticationService][5]  

[1]: ../README.md
[2]: RequestToken.md
[3]: RequestTokenAsync.md
[4]: StartAuthentication.md
[5]: ../AuthenticationService/README.md
[6]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"