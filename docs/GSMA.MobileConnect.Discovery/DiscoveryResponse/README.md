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

                   | Name                   | Description                                                                                          
------------------ | ---------------------- | ---------------------------------------------------------------------------------------------------- 
![Public property] | [Cached][5]            | True if the data came from the local cache                                                           
![Public property] | [ErrorResponse][6]     | The response if the network request returned an error                                                
![Public property] | [HasExpired][7]        | Has the reponse expired? If no Ttl is specified then it is assumed that the response has not expired 
![Public property] | [Headers][8]           | Returns the list of Http headers in the response                                                     
![Public property] | [OperatorUrls][9]      | The returned operator urls for authentication                                                        
![Public property] | [ProviderMetadata][10] | The provider metadata associated with this response                                                  
![Public property] | [ResponseCode][11]     | Returns the Http response code or 0 if the data is cached                                            
![Public property] | [ResponseData][12]     | The parsed json response data                                                                        
![Public property] | [TimeCachedUtc][13]    | Time when the object was initially cached                                                            
![Public property] | [Ttl][14]              | Time to live from the response                                                                       


Methods
-------

                 | Name              | Description                                                                                                        
---------------- | ----------------- | ------------------------------------------------------------------------------------------------------------------ 
![Public method] | [MarkExpired][15] | Mark the object as expired, this method should only cause HasExpired to move from false to true, not true to false 


See Also
--------

#### Reference
[GSMA.MobileConnect.Discovery Namespace][2]  
[GSMA.MobileConnect.Discovery.IDiscovery][16]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: _ctor_1.md
[5]: Cached.md
[6]: ErrorResponse.md
[7]: HasExpired.md
[8]: Headers.md
[9]: OperatorUrls.md
[10]: ProviderMetadata.md
[11]: ResponseCode.md
[12]: ResponseData.md
[13]: TimeCachedUtc.md
[14]: Ttl.md
[15]: MarkExpired.md
[16]: ../IDiscovery/README.md
[17]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"