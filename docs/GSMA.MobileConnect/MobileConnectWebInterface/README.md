MobileConnectWebInterface Class
===============================
Convenience wrapper for [IDiscovery][1] and [IAuthentication][2] methods for use with ASP.NET


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

                 | Name                                                                                                                    | Description                                                                                                                                                                                                                                                                                                                                    
---------------- | ----------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [AttemptDiscoveryAfterOperatorSelectionAsync][6]                                                                        | Attempt discovery using the values returned from the operator selection redirect                                                                                                                                                                                                                                                               
![Public method] | [AttemptDiscoveryAsync][7]                                                                                              | Attempt discovery using the supplied parameters. If msisdn, mcc and mnc are null the result will be operator selection, otherwise valid parameters will result in a StartAuthorization status                                                                                                                                                  
![Public method] | [HandleUrlRedirectAsync(HttpRequestMessage, Uri, DiscoveryResponse, String, String)][8]                                 | Handles continuation of the process following a completed redirect, the request token url must be provided if it has been returned by the discovery process. Only the request and redirectedUrl are required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required. 
![Public method] | [HandleUrlRedirectAsync(HttpRequestMessage, Uri, String, String, String)][9]                                            | Handles continuation of the process following a completed redirect, the request token url must be provided if it has been returned by the discovery process. Only the request and redirectedUrl are required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required. 
![Public method] | [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][10]                                     | Request token using the values returned from the authorization redirect                                                                                                                                                                                                                                                                        
![Public method] | [RequestTokenAsync(HttpRequestMessage, String, Uri, String, String)][11]                                                | Request token using the values returned from the authorization redirect                                                                                                                                                                                                                                                                        
![Public method] | [RequestUserInfoAsync(HttpRequestMessage, DiscoveryResponse, String, ClaimsParameter, MobileConnectRequestOptions)][12] | Request user info using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][10]                                                                                                                                                                                                       
![Public method] | [RequestUserInfoAsync(HttpRequestMessage, String, String, ClaimsParameter, MobileConnectRequestOptions)][13]            | Request user info using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String)][10]                                                                                                                                                                                                       
![Public method] | [StartAuthentication(HttpRequestMessage, DiscoveryResponse, String, String, String, MobileConnectRequestOptions)][14]   | Creates an authorization url with parameters to begin the authetication process                                                                                                                                                                                                                                                                
![Public method] | [StartAuthentication(HttpRequestMessage, String, String, String, String, MobileConnectRequestOptions)][15]              | Creates an authorization url with parameters to begin the authetication process, the SDKSession id is used to fetch the discovery response                                                                                                                                                                                                     


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][4]  
[GSMA.MobileConnect.MobileConnectInterface][16]  
[GSMA.MobileConnect.MobileConnectStatus][17]  
[GSMA.MobileConnect.MobileConnectConfig][18]  
[GSMA.MobileConnect.Web.ResponseConverter][19]  

[1]: ../../GSMA.MobileConnect.Discovery/IDiscovery/README.md
[2]: ../../GSMA.MobileConnect.Authentication/IAuthentication/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: _ctor.md
[6]: AttemptDiscoveryAfterOperatorSelectionAsync.md
[7]: AttemptDiscoveryAsync.md
[8]: HandleUrlRedirectAsync.md
[9]: HandleUrlRedirectAsync_1.md
[10]: RequestTokenAsync.md
[11]: RequestTokenAsync_1.md
[12]: RequestUserInfoAsync.md
[13]: RequestUserInfoAsync_1.md
[14]: StartAuthentication.md
[15]: StartAuthentication_1.md
[16]: ../MobileConnectInterface/README.md
[17]: ../MobileConnectStatus/README.md
[18]: ../MobileConnectConfig/README.md
[19]: ../../GSMA.MobileConnect.Web/ResponseConverter/README.md
[20]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"