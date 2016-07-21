MobileConnectWebInterface Class
===============================
Convenience wrapper for [IDiscoveryService][1] and [IAuthenticationService][2] methods for use with ASP.NET


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **GSMA.MobileConnect.MobileConnectWebInterface**  

**Namespace:** [GSMA.MobileConnect][4]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class MobileConnectWebInterface
```

The **MobileConnectWebInterface** type exposes the following members.


Constructors
------------

                 | Name                           | Description                                                       
---------------- | ------------------------------ | ----------------------------------------------------------------- 
![Public method] | [MobileConnectWebInterface][5] | Initializes a new instance of the MobileConnectWebInterface class 


Methods
-------

                 | Name                                                                                                                  | Description                                                                                                                                                                                                                                                                                                                                    
---------------- | --------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [AttemptDiscoveryAfterOperatorSelectionAsync][6]                                                                      | Attempt discovery using the values returned from the operator selection redirect                                                                                                                                                                                                                                                               
![Public method] | [AttemptDiscoveryAsync][7]                                                                                            | Attempt discovery using the supplied parameters. If msisdn, mcc and mnc are null the result will be operator selection, otherwise valid parameters will result in a StartAuthorization status                                                                                                                                                  
![Public method] | [HandleUrlRedirectAsync(HttpRequestMessage, Uri, DiscoveryResponse, String, String)][8]                               | Handles continuation of the process following a completed redirect, the request token url must be provided if it has been returned by the discovery process. Only the request and redirectedUrl are required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required. 
![Public method] | [HandleUrlRedirectAsync(HttpRequestMessage, Uri, String, String, String)][9]                                          | Handles continuation of the process following a completed redirect, the request token url must be provided if it has been returned by the discovery process. Only the request and redirectedUrl are required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required. 
![Public method] | [RequestIdentityAsync(HttpRequestMessage, DiscoveryResponse, String, MobileConnectRequestOptions)][10]                | Request identity using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][11]                                                                                                                                                                                                        
![Public method] | [RequestIdentityAsync(HttpRequestMessage, String, String, MobileConnectRequestOptions)][12]                           | Request identity using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][11]                                                                                                                                                                                                        
![Public method] | [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][11]                                   | Request token using the values returned from the authorization redirect                                                                                                                                                                                                                                                                        
![Public method] | [RequestTokenAsync(HttpRequestMessage, String, Uri, String, String)][13]                                              | Request token using the values returned from the authorization redirect                                                                                                                                                                                                                                                                        
![Public method] | [RequestUserInfoAsync(HttpRequestMessage, DiscoveryResponse, String, MobileConnectRequestOptions)][14]                | Request user info using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][11]                                                                                                                                                                                                       
![Public method] | [RequestUserInfoAsync(HttpRequestMessage, String, String, MobileConnectRequestOptions)][15]                           | Request user info using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][11]                                                                                                                                                                                                       
![Public method] | [StartAuthentication(HttpRequestMessage, DiscoveryResponse, String, String, String, MobileConnectRequestOptions)][16] | Creates an authorization url with parameters to begin the authetication process                                                                                                                                                                                                                                                                
![Public method] | [StartAuthentication(HttpRequestMessage, String, String, String, String, MobileConnectRequestOptions)][17]            | Creates an authorization url with parameters to begin the authetication process, the SDKSession id is used to fetch the discovery response                                                                                                                                                                                                     


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][4]  
[GSMA.MobileConnect.MobileConnectInterface][18]  
[GSMA.MobileConnect.MobileConnectStatus][19]  
[GSMA.MobileConnect.MobileConnectConfig][20]  
[GSMA.MobileConnect.Web.ResponseConverter][21]  

[1]: ../../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[2]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: _ctor.md
[6]: AttemptDiscoveryAfterOperatorSelectionAsync.md
[7]: AttemptDiscoveryAsync.md
[8]: HandleUrlRedirectAsync.md
[9]: HandleUrlRedirectAsync_1.md
[10]: RequestIdentityAsync.md
[11]: RequestTokenAsync.md
[12]: RequestIdentityAsync_1.md
[13]: RequestTokenAsync_1.md
[14]: RequestUserInfoAsync.md
[15]: RequestUserInfoAsync_1.md
[16]: StartAuthentication.md
[17]: StartAuthentication_1.md
[18]: ../MobileConnectInterface/README.md
[19]: ../MobileConnectStatus/README.md
[20]: ../MobileConnectConfig/README.md
[21]: ../../GSMA.MobileConnect.Web/ResponseConverter/README.md
[22]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"