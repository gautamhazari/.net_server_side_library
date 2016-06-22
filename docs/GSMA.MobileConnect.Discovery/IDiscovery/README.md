IDiscovery Interface
====================
Interface for Mobile Connect Discovery requests

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public interface IDiscovery
```

The **IDiscovery** type exposes the following members.


Properties
----------

                   | Name       | Description              
------------------ | ---------- | ------------------------ 
![Public property] | [Cache][2] | Discovery response cache 


Methods
-------

                 | Name                                                                                                                            | Description                                                                                                                                                                                                                                                                                                                                                     
---------------- | ------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [ClearDiscoveryCacheAsync][3]                                                                                                   | Helper function which clears any result from the discovery cache which corresponds with the provided parameters                                                                                                                                                                                                                                                 
![Public method] | [CompleteSelectedOperatorDiscovery(IPreferences, String, String, String)][4]                                                    | Synchronous wrapper for [CompleteSelectedOperatorDiscoveryAsync(IPreferences, String, String, String)][5]                                                                                                                                                                                                                                                       
![Public method] | [CompleteSelectedOperatorDiscovery(String, String, String, String, String, String)][6]                                          | Synchronous wrapper for [CompleteSelectedOperatorDiscoveryAsync(String, String, String, String, String, String)][7]                                                                                                                                                                                                                                             
![Public method] | [CompleteSelectedOperatorDiscoveryAsync(IPreferences, String, String, String)][5]                                               | Convenience version of [CompleteSelectedOperatorDiscoveryAsync(String, String, String, String, String, String)][7] where the clientId, clientSecret and discoveryUrl are provided by the IPreferences implementation                                                                                                                                            
![Public method] | [CompleteSelectedOperatorDiscoveryAsync(String, String, String, String, String, String)][7]                                     | Allows an application to use the selected operator MCC and MNC to obtain the discovery response. In the case there is already a discovery result in the cache and the Selected-MCC/Selected-MNC in the new request are the same as relates to the discovery result for the cached result, the cached result will be returned.                                   
![Public method] | [ExtractOperatorSelectionURL][8]                                                                                                | Helper function to extract operator selection URL from the discovery reponse                                                                                                                                                                                                                                                                                    
![Public method] | [GetCachedDiscoveryResultAsync][9]                                                                                              | Helper function which retrieves a discovery response (if available) from the discovery cache which corresponds with the operator details                                                                                                                                                                                                                        
![Public method] | [GetOperatorSelectionURL(IPreferences, String)][10]                                                                             | Synchronous wrapper for [GetOperatorSelectionURLAsync(IPreferences, String)][11]                                                                                                                                                                                                                                                                                
![Public method] | [GetOperatorSelectionURL(String, String, String, String)][12]                                                                   | Synchronous wrapper for [GetOperatorSelectionURLAsync(String, String, String, String)][13]                                                                                                                                                                                                                                                                      
![Public method] | [GetOperatorSelectionURLAsync(IPreferences, String)][11]                                                                        | Convenience wrapper for [GetOperatorSelectionURLAsync(String, String, String, String)][13] where the clientId, clientSecret and discoveryUrl are provided by the IPreferences implementation                                                                                                                                                                    
![Public method] | [GetOperatorSelectionURLAsync(String, String, String, String)][13]                                                              | Allows an application to get the URL for the operator selection UI of the discovery service. This will not reference the discovery result cache. The returned URL will contain a session id created by the discovery server. The URL must be used as-is.                                                                                                        
![Public method] | [GetProviderMetadata][14]                                                                                                       | Retrieves an updated version of the ProviderMetadata if available, the discovery response property ProviderMetadata will also be updated with this version for future access                                                                                                                                                                                    
![Public method] | [ParseDiscoveryRedirect][15]                                                                                                    | Allows an application to obtain parameters which have been passed within a discovery redirect URL                                                                                                                                                                                                                                                               
![Public method] | [StartAutomatedOperatorDiscovery(IPreferences, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][16]                | Synchronous wrapper for [StartAutomatedOperatorDiscoveryAsync(IPreferences, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][17]                                                                                                                                                                                                                   
![Public method] | [StartAutomatedOperatorDiscovery(String, String, String, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][18]      | Synchronous wrapper for [StartAutomatedOperatorDiscoveryAsync(String, String, String, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][19]                                                                                                                                                                                                         
![Public method] | [StartAutomatedOperatorDiscoveryAsync(IPreferences, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][17]           | Convenience version of [StartAutomatedOperatorDiscoveryAsync(String, String, String, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][19] where the clientId, clientSecret and discoveryUrl are provided by the IPreferences implementation                                                                                                        
![Public method] | [StartAutomatedOperatorDiscoveryAsync(String, String, String, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][19] | Allows an application to conduct discovery based on the predetermined operator/network identified operator semantics. If the operator cannot be identified the function will return the 'operator selection' form of the response. The application can then determine how to proceed i.e. open the operator selection page separately or otherwise handle this. 


See Also
--------

#### Reference
[GSMA.MobileConnect.Discovery Namespace][1]  
[GSMA.MobileConnect.Discovery.Discovery][20]  
[GSMA.MobileConnect.Discovery.DiscoveryOptions][21]  
[GSMA.MobileConnect.Discovery.DiscoveryResponse][22]  

[1]: ../README.md
[2]: Cache.md
[3]: ClearDiscoveryCacheAsync.md
[4]: CompleteSelectedOperatorDiscovery.md
[5]: CompleteSelectedOperatorDiscoveryAsync.md
[6]: CompleteSelectedOperatorDiscovery_1.md
[7]: CompleteSelectedOperatorDiscoveryAsync_1.md
[8]: ExtractOperatorSelectionURL.md
[9]: GetCachedDiscoveryResultAsync.md
[10]: GetOperatorSelectionURL.md
[11]: GetOperatorSelectionURLAsync.md
[12]: GetOperatorSelectionURL_1.md
[13]: GetOperatorSelectionURLAsync_1.md
[14]: GetProviderMetadata.md
[15]: ParseDiscoveryRedirect.md
[16]: StartAutomatedOperatorDiscovery.md
[17]: StartAutomatedOperatorDiscoveryAsync.md
[18]: StartAutomatedOperatorDiscovery_1.md
[19]: StartAutomatedOperatorDiscoveryAsync_1.md
[20]: ../Discovery/README.md
[21]: ../DiscoveryOptions/README.md
[22]: ../DiscoveryResponse/README.md
[23]: ../../_icons/Help.png
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Public method]: ../../_icons/pubmethod.gif "Public method"