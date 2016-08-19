GSMA.MobileConnect.Exceptions Namespace
=======================================
This namespace contains MobileConnect specific Exceptions


Classes
-------

                | Class                                                  | Description                                                                                                         
--------------- | ------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------- 
![Public class] | [MobileConnectCacheExpiryLimitException][1]            | Exception raised when a cache expiry time is set to a value outside of the min and max expiry time range            
![Public class] | [MobileConnectEndpointHttpException][2]                | Exception raised when calls to the discovery endpoint encounter a http exception such as unreachable host           
![Public class] | [MobileConnectInvalidArgumentException][3]             | Exception raised when invalid arguments are passed to [IAuthenticationService][4] or [IDiscoveryService][5] methods 
![Public class] | [MobileConnectInvalidJWKException][6]                  | Exception raised when a JWK contains incomplete or invalid information so is unable to complete JWT validation      
![Public class] | [MobileConnectProviderMetadataUnavailableException][7] | Exception raised when provider metadata or required properties of provider metadata are unavailable                 
![Public class] | [MobileConnectUnsupportedJWKException][8]              | Exception raised when a token contains an unsupported algorithm in the token header                                 

[1]: MobileConnectCacheExpiryLimitException/README.md
[2]: MobileConnectEndpointHttpException/README.md
[3]: MobileConnectInvalidArgumentException/README.md
[4]: ../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[5]: ../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[6]: MobileConnectInvalidJWKException/README.md
[7]: MobileConnectProviderMetadataUnavailableException/README.md
[8]: MobileConnectUnsupportedJWKException/README.md
[9]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"