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
---------------- | ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [RefreshToken][2]                  | Synchronous wrapper for [RefreshTokenAsync(String, String, String, String)][3]                                                                                                                                                  
![Public method] | [RefreshTokenAsync][3]             | Allows an application to use the refresh token obtained from request token response and request for a token refresh. This function requires a valid refresh token to be provided                                                
![Public method] | [RequestHeadlessAuthentication][4] | Initiates headless authentication, if authentication is successful a token will be returned. This may be a long running operation as response from the user on their authentication device is required.                         
![Public method] | [RequestToken][5]                  | Synchronous wrapper for [RequestTokenAsync(String, String, String, String, String)][6]                                                                                                                                          
![Public method] | [RequestTokenAsync][6]             | Allows an application to use the authorization code obtained from authentication/authorization to obtain an access token and related information from the authorization server.                                                 
![Public method] | [RevokeToken][7]                   | Synchronous wrapper for [RevokeToken(String, String, String, String, String)][7]                                                                                                                                                
![Public method] | [RevokeTokenAsync][8]              | Allows an application to use the access token or the refresh token obtained from request token response and request for a token revocation This function requires either a valid access token or a refresh token to be provided 
![Public method] | [StartAuthentication][9]           | Generates an authorisation url based on the supplied options and previous discovery response                                                                                                                                    
![Public method] | [ValidateTokenResponse][10]        | Executes a series of validation methods on the token response, if the access token or id token are invalid the result will indicate what validation criteria was not met                                                        


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][1]  
[GSMA.MobileConnect.Authentication.AuthenticationService][11]  

[1]: ../README.md
[2]: RefreshToken.md
[3]: RefreshTokenAsync.md
[4]: RequestHeadlessAuthentication.md
[5]: RequestToken.md
[6]: RequestTokenAsync.md
[7]: RevokeToken.md
[8]: RevokeTokenAsync.md
[9]: StartAuthentication.md
[10]: ValidateTokenResponse.md
[11]: ../AuthenticationService/README.md
[12]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"