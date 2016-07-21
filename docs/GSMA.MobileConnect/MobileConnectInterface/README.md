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

                 | Name                        | Description                                                    
---------------- | --------------------------- | -------------------------------------------------------------- 
![Public method] | [MobileConnectInterface][5] | Initializes a new instance of the MobileConnectInterface class 


Methods
-------

                 | Name                                             | Description                                                                                                                                                                                                                              
---------------- | ------------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [AttemptDiscovery][6]                            | Synchronous wrapper for [AttemptDiscoveryAsync(String, String, String, MobileConnectRequestOptions)][7]                                                                                                                                  
![Public method] | [AttemptDiscoveryAfterOperatorSelection][8]      | Synchronous wrapper for [AttemptDiscoveryAfterOperatorSelectionAsync(Uri)][9]                                                                                                                                                            
![Public method] | [AttemptDiscoveryAfterOperatorSelectionAsync][9] | Attempt discovery using the values returned from the operator selection redirect                                                                                                                                                         
![Public method] | [AttemptDiscoveryAsync][7]                       | Attempt discovery using the supplied parameters. If msisdn, mcc and mnc are null the result will be operator selection, otherwise valid parameters will result in a StartAuthorization status                                            
![Public method] | [HandleUrlRedirect][10]                          | Synchronous wrapper for [HandleUrlRedirectAsync(Uri, DiscoveryResponse, String, String)][11]                                                                                                                                             
![Public method] | [HandleUrlRedirectAsync][11]                     | Handles continuation of the process following a completed redirect. Only the redirectedUrl is required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required. 
![Public method] | [RequestIdentity][12]                            | Syncronous wrapper for [RequestIdentityAsync(DiscoveryResponse, String, MobileConnectRequestOptions)][13]                                                                                                                                
![Public method] | [RequestIdentityAsync][13]                       | Request user info using the access token returned by [RequestTokenAsync(DiscoveryResponse, Uri, String, String)][14]                                                                                                                     
![Public method] | [RequestToken][15]                               | Synchronous wrapper for [RequestTokenAsync(DiscoveryResponse, Uri, String, String)][14]                                                                                                                                                  
![Public method] | [RequestTokenAsync][14]                          | Request token using the values returned from the authorization redirect                                                                                                                                                                  
![Public method] | [RequestUserInfo][16]                            | Syncronous wrapper for [RequestUserInfoAsync(DiscoveryResponse, String, MobileConnectRequestOptions)][17]                                                                                                                                
![Public method] | [RequestUserInfoAsync][17]                       | Request user info using the access token returned by [RequestTokenAsync(DiscoveryResponse, Uri, String, String)][14]                                                                                                                     
![Public method] | [StartAuthentication][18]                        | Creates an authorization url with parameters to begin the authorization process                                                                                                                                                          


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][4]  
[GSMA.MobileConnect.MobileConnectWebInterface][19]  
[GSMA.MobileConnect.MobileConnectStatus][20]  
[GSMA.MobileConnect.MobileConnectConfig][21]  

[1]: ../../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[2]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: _ctor.md
[6]: AttemptDiscovery.md
[7]: AttemptDiscoveryAsync.md
[8]: AttemptDiscoveryAfterOperatorSelection.md
[9]: AttemptDiscoveryAfterOperatorSelectionAsync.md
[10]: HandleUrlRedirect.md
[11]: HandleUrlRedirectAsync.md
[12]: RequestIdentity.md
[13]: RequestIdentityAsync.md
[14]: RequestTokenAsync.md
[15]: RequestToken.md
[16]: RequestUserInfo.md
[17]: RequestUserInfoAsync.md
[18]: StartAuthentication.md
[19]: ../MobileConnectWebInterface/README.md
[20]: ../MobileConnectStatus/README.md
[21]: ../MobileConnectConfig/README.md
[22]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"