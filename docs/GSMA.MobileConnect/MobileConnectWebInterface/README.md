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

                 | Name                                                                                                                               | Description                                                                                              
---------------- | ---------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- 
![Public method] | [MobileConnectWebInterface(MobileConnectConfig, ICache)][5]                                                                        | Initializes a new instance of the MobileConnectWebInterface class using default concrete implementations 
![Public method] | [MobileConnectWebInterface(IDiscoveryService, IAuthenticationService, MobileConnectConfig)][6]                                     | **Obsolete.**R1 supporting constructor, identity and jwks services will be defaulted                     
![Public method] | [MobileConnectWebInterface(MobileConnectConfig, ICache, RestClient)][7]                                                            | Initializes a new instance of the MobileConnectWebInterface class using default concrete implementations 
![Public method] | [MobileConnectWebInterface(IDiscoveryService, IAuthenticationService, IIdentityService, IJWKeysetService, MobileConnectConfig)][8] | Initializes a new instance of the MobileConnectWebInterface class                                        


Methods
-------

                 | Name                                                                                                                                                    | Description                                                                                                                                                                                                                                                                                                                                    
---------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [AttemptDiscoveryAfterOperatorSelectionAsync][9]                                                                                                        | Attempt discovery using the values returned from the operator selection redirect                                                                                                                                                                                                                                                               
![Public method] | [AttemptDiscoveryAsync][10]                                                                                                                             | Attempt discovery using the supplied parameters. If msisdn, mcc and mnc are null the result will be operator selection, otherwise valid parameters will result in a StartAuthorization status                                                                                                                                                  
![Public method] | [HandleUrlRedirectAsync(HttpRequestMessage, Uri, DiscoveryResponse, String, String, MobileConnectRequestOptions)][11]                                   | Handles continuation of the process following a completed redirect, the request token url must be provided if it has been returned by the discovery process. Only the request and redirectedUrl are required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required. 
![Public method] | [HandleUrlRedirectAsync(HttpRequestMessage, Uri, String, String, String, MobileConnectRequestOptions)][12]                                              | Handles continuation of the process following a completed redirect, the request token url must be provided if it has been returned by the discovery process. Only the request and redirectedUrl are required, however if the redirect being handled is the result of calling the Authorization URL then the remaining parameters are required. 
![Public method] | [RequestHeadlessAuthenticationAsync(HttpRequestMessage, DiscoveryResponse, String, String, String, MobileConnectRequestOptions, CancellationToken)][13] | Performs headless authentication followed by request token if successful. Tokens will be validated before being returned. This may be a long running method as it waits for the authenticating user to respond using their authenticating device.                                                                                              
![Public method] | [RequestHeadlessAuthenticationAsync(HttpRequestMessage, String, String, String, String, MobileConnectRequestOptions, CancellationToken)][14]            | Performs headless authentication followed by request token if successful. Tokens will be validated before being returned. This may be a long running method as it waits for the authenticating user to respond using their authenticating device.                                                                                              
![Public method] | [RequestIdentityAsync(HttpRequestMessage, DiscoveryResponse, String, MobileConnectRequestOptions)][15]                                                  | Request identity using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String, MobileConnectRequestOptions)][16]                                                                                                                                                                           
![Public method] | [RequestIdentityAsync(HttpRequestMessage, String, String, MobileConnectRequestOptions)][17]                                                             | Request identity using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String, MobileConnectRequestOptions)][16]                                                                                                                                                                           
![Public method] | [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String, MobileConnectRequestOptions)][16]                                        | Request token using the values returned from the authorization redirect                                                                                                                                                                                                                                                                        
![Public method] | [RequestTokenAsync(HttpRequestMessage, String, Uri, String, String, MobileConnectRequestOptions)][18]                                                   | Request token using the values returned from the authorization redirect                                                                                                                                                                                                                                                                        
![Public method] | [RequestUserInfoAsync(HttpRequestMessage, DiscoveryResponse, String, MobileConnectRequestOptions)][19]                                                  | Request user info using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String, MobileConnectRequestOptions)][16]                                                                                                                                                                          
![Public method] | [RequestUserInfoAsync(HttpRequestMessage, String, String, MobileConnectRequestOptions)][20]                                                             | Request user info using the access token returned by [RequestTokenAsync(HttpRequestMessage, DiscoveryResponse, Uri, String, String, MobileConnectRequestOptions)][16]                                                                                                                                                                          
![Public method] | [StartAuthentication(HttpRequestMessage, DiscoveryResponse, String, String, String, MobileConnectRequestOptions)][21]                                   | Creates an authorization url with parameters to begin the authetication process                                                                                                                                                                                                                                                                
![Public method] | [StartAuthentication(HttpRequestMessage, String, String, String, String, MobileConnectRequestOptions)][22]                                              | Creates an authorization url with parameters to begin the authetication process, the SDKSession id is used to fetch the discovery response                                                                                                                                                                                                     


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][4]  
[GSMA.MobileConnect.MobileConnectInterface][23]  
[GSMA.MobileConnect.MobileConnectStatus][24]  
[GSMA.MobileConnect.MobileConnectConfig][25]  
[GSMA.MobileConnect.Web.ResponseConverter][26]  

[1]: ../../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[2]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: _ctor_2.md
[6]: _ctor_1.md
[7]: _ctor_3.md
[8]: _ctor.md
[9]: AttemptDiscoveryAfterOperatorSelectionAsync.md
[10]: AttemptDiscoveryAsync.md
[11]: HandleUrlRedirectAsync.md
[12]: HandleUrlRedirectAsync_1.md
[13]: RequestHeadlessAuthenticationAsync.md
[14]: RequestHeadlessAuthenticationAsync_1.md
[15]: RequestIdentityAsync.md
[16]: RequestTokenAsync.md
[17]: RequestIdentityAsync_1.md
[18]: RequestTokenAsync_1.md
[19]: RequestUserInfoAsync.md
[20]: RequestUserInfoAsync_1.md
[21]: StartAuthentication.md
[22]: StartAuthentication_1.md
[23]: ../MobileConnectInterface/README.md
[24]: ../MobileConnectStatus/README.md
[25]: ../MobileConnectConfig/README.md
[26]: ../../GSMA.MobileConnect.Web/ResponseConverter/README.md
[27]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"