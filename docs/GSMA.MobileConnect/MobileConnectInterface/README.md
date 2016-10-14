MobileConnectInterface Class
============================
Convenience wrapper for [IDiscoveryService][1] and [IAuthenticationService][2] methods for use with non-web .Net targets


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **GSMA.MobileConnect.MobileConnectInterface**  

**Namespace:** [GSMA.MobileConnect][4]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class MobileConnectInterface
```

The **MobileConnectInterface** type exposes the following members.


Constructors
------------

                 | Name                                                                                                                            | Description                                                                                           
---------------- | ------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- 
![Public method] | [MobileConnectInterface(MobileConnectConfig, ICache)][5]                                                                        | Initializes a new instance of the MobileConnectInterface class using default concrete implementations 
![Public method] | [MobileConnectInterface(IDiscoveryService, IAuthenticationService, MobileConnectConfig)][6]                                     | **Obsolete.**R1 supporting constructor, identity and jwks services will be defaulted                  
![Public method] | [MobileConnectInterface(MobileConnectConfig, ICache, RestClient)][7]                                                            | Initializes a new instance of the MobileConnectInterface class using default concrete implementations 
![Public method] | [MobileConnectInterface(MobileConnectConfig, IDiscoveryService, IAuthenticationService, IIdentityService, IJWKeysetService)][8] | Initializes a new instance of the MobileConnectInterface class                                        


Methods
-------

                 | Name                                              | Description                                                                                                                                                                                                                              
---------------- | ------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [AttemptDiscovery][9]                             | Synchronous wrapper for [AttemptDiscoveryAsync(String, String, String, MobileConnectRequestOptions)][10]                                                                                                                                 
![Public method] | [AttemptDiscoveryAfterOperatorSelection][11]      | Synchronous wrapper for [AttemptDiscoveryAfterOperatorSelectionAsync(Uri)][12]                                                                                                                                                           
![Public method] | [AttemptDiscoveryAfterOperatorSelectionAsync][12] | Attempt discovery using the values returned from the operator selection redirect                                                                                                                                                         
![Public method] | [AttemptDiscoveryAsync][10]                       | Attempt discovery using the supplied parameters. If msisdn, mcc and mnc are null the result will be operator selection, otherwise valid parameters will result in a StartAuthorization status                                            
![Public method] | [HandleUrlRedirect][13]                           | Synchronous wrapper for [HandleUrlRedirectAsync(Uri, DiscoveryResponse, String, String, MobileConnectRequestOptions)][14]                                                                                                                
![Public method] | [HandleUrlRedirectAsync][14]                      | Handles continuation of the process following a completed redirect. Only the redirectedUrl is required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required. 
![Public method] | [RefreshToken][15]                                | Synchronous wrapper for [RefreshTokenAsync(String, DiscoveryResponse)][16]                                                                                                                                                               
![Public method] | [RefreshTokenAsync][16]                           | Refresh token using using the refresh token provided in the RequestToken response                                                                                                                                                        
![Public method] | [RequestIdentity][17]                             | Syncronous wrapper for [RequestIdentityAsync(DiscoveryResponse, String, MobileConnectRequestOptions)][18]                                                                                                                                
![Public method] | [RequestIdentityAsync][18]                        | Request user info using the access token returned by [RequestTokenAsync(DiscoveryResponse, Uri, String, String, MobileConnectRequestOptions)][19]                                                                                        
![Public method] | [RequestToken][20]                                | Synchronous wrapper for [RequestTokenAsync(DiscoveryResponse, Uri, String, String, MobileConnectRequestOptions)][19]                                                                                                                     
![Public method] | [RequestTokenAsync][19]                           | Request token using the values returned from the authorization redirect                                                                                                                                                                  
![Public method] | [RequestUserInfo][21]                             | Syncronous wrapper for [RequestUserInfoAsync(DiscoveryResponse, String, MobileConnectRequestOptions)][22]                                                                                                                                
![Public method] | [RequestUserInfoAsync][22]                        | Request user info using the access token returned by [RequestTokenAsync(DiscoveryResponse, Uri, String, String, MobileConnectRequestOptions)][19]                                                                                        
![Public method] | [RevokeToken][23]                                 | Synchronous wrapper for [RevokeTokenAsync(String, String, DiscoveryResponse)][24]                                                                                                                                                        
![Public method] | [RevokeTokenAsync][24]                            | Revoke token using using the access / refresh token provided in the RequestToken response                                                                                                                                                
![Public method] | [StartAuthentication][25]                         | Creates an authorization url with parameters to begin the authorization process                                                                                                                                                          


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][4]  
[GSMA.MobileConnect.MobileConnectWebInterface][26]  
[GSMA.MobileConnect.MobileConnectStatus][27]  
[GSMA.MobileConnect.MobileConnectConfig][28]  

[1]: ../../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[2]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: _ctor_1.md
[6]: _ctor.md
[7]: _ctor_2.md
[8]: _ctor_3.md
[9]: AttemptDiscovery.md
[10]: AttemptDiscoveryAsync.md
[11]: AttemptDiscoveryAfterOperatorSelection.md
[12]: AttemptDiscoveryAfterOperatorSelectionAsync.md
[13]: HandleUrlRedirect.md
[14]: HandleUrlRedirectAsync.md
[15]: RefreshToken.md
[16]: RefreshTokenAsync.md
[17]: RequestIdentity.md
[18]: RequestIdentityAsync.md
[19]: RequestTokenAsync.md
[20]: RequestToken.md
[21]: RequestUserInfo.md
[22]: RequestUserInfoAsync.md
[23]: RevokeToken.md
[24]: RevokeTokenAsync.md
[25]: StartAuthentication.md
[26]: ../MobileConnectWebInterface/README.md
[27]: ../MobileConnectStatus/README.md
[28]: ../MobileConnectConfig/README.md
[29]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"