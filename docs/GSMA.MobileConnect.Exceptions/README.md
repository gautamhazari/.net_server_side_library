GSMA.MobileConnect.Exceptions Namespace
=======================================
This namespace contains MobileConnect specific Exceptions


Classes
-------

                | Class                                                  | Description                                                                                               
--------------- | ------------------------------------------------------ | --------------------------------------------------------------------------------------------------------- 
![Public class] | [MobileConnectCacheExpiryLimitException][1]            | Exception raised when a cache expiry time is set to a value outside of the min and max expiry time range  
![Public class] | [MobileConnectEndpointHttpException][2]                | Exception raised when calls to the discovery endpoint encounter a http exception such as unreachable host 
![Public class] | [MobileConnectInvalidArgumentException][3]             | Exception raised when invalid arguments are passed to [IAuthentication][4] or [IDiscovery][5] methods     
![Public class] | [MobileConnectProviderMetadataUnavailableException][6] | Exception raised when provider metadata or required properties of provider metadata are unavailable       

[1]: MobileConnectCacheExpiryLimitException/README.md
[2]: MobileConnectEndpointHttpException/README.md
[3]: MobileConnectInvalidArgumentException/README.md
[4]: ../GSMA.MobileConnect.Authentication/IAuthentication/README.md
[5]: ../GSMA.MobileConnect.Discovery/IDiscovery/README.md
[6]: MobileConnectProviderMetadataUnavailableException/README.md
[7]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"