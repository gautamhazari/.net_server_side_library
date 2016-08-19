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

                 | Name                               | Description                                                                                                                                                                                             
---------------- | ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [RequestHeadlessAuthentication][2] | Initiates headless authentication, if authentication is successful a token will be returned. This may be a long running operation as response from the user on their authentication device is required. 
![Public method] | [RequestToken][3]                  | Synchronous wrapper for [RequestTokenAsync(String, String, String, String, String)][4]                                                                                                                  
![Public method] | [RequestTokenAsync][4]             | Allows an application to use the authorization code obtained from authentication/authorization to obtain an access token and related information from the authorization server.                         
![Public method] | [StartAuthentication][5]           | Generates an authorisation url based on the supplied options and previous discovery response                                                                                                            
![Public method] | [ValidateTokenResponse][6]         | Executes a series of validation methods on the token response, if the access token or id token are invalid the result will indicate what validation criteria was not met                                


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][1]  
[GSMA.MobileConnect.Authentication.AuthenticationService][7]  

[1]: ../README.md
[2]: RequestHeadlessAuthentication.md
[3]: RequestToken.md
[4]: RequestTokenAsync.md
[5]: StartAuthentication.md
[6]: ValidateTokenResponse.md
[7]: ../AuthenticationService/README.md
[8]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"