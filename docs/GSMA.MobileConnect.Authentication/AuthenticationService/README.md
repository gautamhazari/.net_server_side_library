AuthenticationService Class
===========================
Concrete implementation of [IAuthenticationService][1]


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Authentication.AuthenticationService**  

**Namespace:** [GSMA.MobileConnect.Authentication][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class AuthenticationService : IAuthenticationService
```

The **AuthenticationService** type exposes the following members.


Constructors
------------

                 | Name                       | Description                                                                                                    
---------------- | -------------------------- | -------------------------------------------------------------------------------------------------------------- 
![Public method] | [AuthenticationService][4] | Creates a new instance of the class AuthenticationService using the specified RestClient for all HTTP requests 


Methods
-------

                 | Name                               | Description                                                                                                                                                                                                                     
---------------- | ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [RefreshToken][5]                  | Synchronous wrapper for [RefreshTokenAsync(String, String, String, String)][6]                                                                                                                                                  
![Public method] | [RefreshTokenAsync][7]             | Allows an application to use the refresh token obtained from request token response and request for a token refresh. This function requires a valid refresh token to be provided                                                
![Public method] | [RequestHeadlessAuthentication][8] | Initiates headless authentication, if authentication is successful a token will be returned. This may be a long running operation as response from the user on their authentication device is required.                         
![Public method] | [RequestToken][9]                  | Synchronous wrapper for [RequestTokenAsync(String, String, String, String, String)][10]                                                                                                                                         
![Public method] | [RequestTokenAsync][11]            | Allows an application to use the authorization code obtained from authentication/authorization to obtain an access token and related information from the authorization server.                                                 
![Public method] | [RevokeToken][12]                  | Synchronous wrapper for [RevokeToken(String, String, String, String, String)][13]                                                                                                                                               
![Public method] | [RevokeTokenAsync][14]             | Allows an application to use the access token or the refresh token obtained from request token response and request for a token revocation This function requires either a valid access token or a refresh token to be provided 
![Public method] | [StartAuthentication][15]          | Generates an authorisation url based on the supplied options and previous discovery response                                                                                                                                    
![Public method] | [ValidateTokenResponse][16]        | Executes a series of validation methods on the token response, if the access token or id token are invalid the result will indicate what validation criteria was not met                                                        


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][3]  

[1]: ../IAuthenticationService/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: RefreshToken.md
[6]: ../IAuthenticationService/RefreshTokenAsync.md
[7]: RefreshTokenAsync.md
[8]: RequestHeadlessAuthentication.md
[9]: RequestToken.md
[10]: ../IAuthenticationService/RequestTokenAsync.md
[11]: RequestTokenAsync.md
[12]: RevokeToken.md
[13]: ../IAuthenticationService/RevokeToken.md
[14]: RevokeTokenAsync.md
[15]: StartAuthentication.md
[16]: ValidateTokenResponse.md
[17]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"