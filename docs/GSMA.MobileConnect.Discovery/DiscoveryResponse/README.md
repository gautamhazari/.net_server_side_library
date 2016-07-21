DiscoveryResponse Class
=======================
Class to hold a discovery response. This potentially holds cached data as indicated by the cached property.


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Discovery.DiscoveryResponse**  

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class DiscoveryResponse : ICacheable
```

The **DiscoveryResponse** type exposes the following members.


Constructors
------------

                 | Name                                          | Description                                                                          
---------------- | --------------------------------------------- | ------------------------------------------------------------------------------------ 
![Public method] | [DiscoveryResponse(DiscoveryResponseData)][3] | Creates an instance of the DiscoveryResponse class                                   
![Public method] | [DiscoveryResponse(RestResponse)][4]          | Creates an instance of the DiscoveryResponse using data from a RestResponse instance 


Properties
----------

                   | Name                      | Description                                                                                                   
------------------ | ------------------------- | ------------------------------------------------------------------------------------------------------------- 
![Public property] | [ApplicationShortName][5] | The 16 byte name which is pre-registered by the developer and returned from the API Exchange during Discovery 
![Public property] | [Cached][6]               | True if the data came from the local cache                                                                    
![Public property] | [ErrorResponse][7]        | The response if the network request returned an error                                                         
![Public property] | [HasExpired][8]           | Has the reponse expired? If no Ttl is specified then it is assumed that the response has not expired          
![Public property] | [Headers][9]              | Returns the list of Http headers in the response                                                              
![Public property] | [OperatorUrls][10]        | The returned operator urls for authentication                                                                 
![Public property] | [ProviderMetadata][11]    | The provider metadata associated with this response                                                           
![Public property] | [ResponseCode][12]        | Returns the Http response code or 0 if the data is cached                                                     
![Public property] | [ResponseData][13]        | The parsed json response data                                                                                 
![Public property] | [TimeCachedUtc][14]       | Time when the object was initially cached                                                                     
![Public property] | [Ttl][15]                 | Time to live from the response                                                                                


Methods
-------

                 | Name                                  | Description                                                                                                        
---------------- | ------------------------------------- | ------------------------------------------------------------------------------------------------------------------ 
![Public method] | [IsMobileConnectServiceSupported][16] | Check to see if provided scopes are supported by the operator linked to the discovery response                     
![Public method] | [MarkExpired][17]                     | Mark the object as expired, this method should only cause HasExpired to move from false to true, not true to false 


See Also
--------

#### Reference
[GSMA.MobileConnect.Discovery Namespace][2]  
[GSMA.MobileConnect.Discovery.IDiscoveryService][18]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: _ctor_1.md
[5]: ApplicationShortName.md
[6]: Cached.md
[7]: ErrorResponse.md
[8]: HasExpired.md
[9]: Headers.md
[10]: OperatorUrls.md
[11]: ProviderMetadata.md
[12]: ResponseCode.md
[13]: ResponseData.md
[14]: TimeCachedUtc.md
[15]: Ttl.md
[16]: IsMobileConnectServiceSupported.md
[17]: MarkExpired.md
[18]: ../IDiscoveryService/README.md
[19]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"