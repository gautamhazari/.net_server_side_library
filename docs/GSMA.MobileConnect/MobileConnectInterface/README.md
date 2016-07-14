MobileConnectInterface Class
============================
Convenience wrapper for [IDiscovery][1] and [IAuthentication][2] methods for use with non-web .Net targets


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
![Public method] | [RequestToken][12]                               | Synchronous wrapper for [RequestTokenAsync(DiscoveryResponse, Uri, String, String)][13]                                                                                                                                                  
![Public method] | [RequestTokenAsync][13]                          | Request token using the values returned from the authorization redirect                                                                                                                                                                  
![Public method] | [RequestUserInfo][14]                            | Syncronous wrapper for [RequestTokenAsync(DiscoveryResponse, Uri, String, String)][13]                                                                                                                                                   
![Public method] | [RequestUserInfoAsync][15]                       | Request user info using the access token returned by [RequestTokenAsync(DiscoveryResponse, Uri, String, String)][13]                                                                                                                     
![Public method] | [StartAuthentication][16]                        | Creates an authorization url with parameters to begin the authorization process                                                                                                                                                          


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][4]  
[GSMA.MobileConnect.MobileConnectWebInterface][17]  
[GSMA.MobileConnect.MobileConnectStatus][18]  
[GSMA.MobileConnect.MobileConnectConfig][19]  

[1]: ../../GSMA.MobileConnect.Discovery/IDiscovery/README.md
[2]: ../../GSMA.MobileConnect.Authentication/IAuthentication/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: _ctor.md
[6]: AttemptDiscovery.md
[7]: AttemptDiscoveryAsync.md
[8]: AttemptDiscoveryAfterOperatorSelection.md
[9]: AttemptDiscoveryAfterOperatorSelectionAsync.md
[10]: HandleUrlRedirect.md
[11]: HandleUrlRedirectAsync.md
[12]: RequestToken.md
[13]: RequestTokenAsync.md
[14]: RequestUserInfo.md
[15]: RequestUserInfoAsync.md
[16]: StartAuthentication.md
[17]: ../MobileConnectWebInterface/README.md
[18]: ../MobileConnectStatus/README.md
[19]: ../MobileConnectConfig/README.md
[20]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"