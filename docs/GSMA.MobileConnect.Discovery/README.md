GSMA.MobileConnect.Discovery Namespace
======================================
This namespace contains classes pertaining to the Discovery steps of the MobileConnect process


Classes
-------

                | Class                        | Description                                                                                                                                                                                                   
--------------- | ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public class] | [DiscoveryOptions][1]        | Parameters for the [StartAutomatedOperatorDiscoveryAsync(String, String, String, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][2] method. Object can be serialized to JSON to be a POST body. 
![Public class] | [DiscoveryResponse][3]       | Class to hold a discovery response. This potentially holds cached data as indicated by the cached property.                                                                                                   
![Public class] | [DiscoveryService][4]        | Concrete implementation of [IDiscoveryService][5]                                                                                                                                                             
![Public class] | [OperatorUrls][6]            | Object to hold the operator specific urls returned from a successful discovery process call                                                                                                                   
![Public class] | [ParsedDiscoveryRedirect][7] | Class to hold details parsed from the discovery redirect                                                                                                                                                      
![Public class] | [ProviderMetadata][8]        | Parsed Provider Metadata returned from openid-configuration url                                                                                                                                               
![Public class] | [SupportedVersions][9]       | Storage for supported mobile connect versions in [MobileConnectVersionSupported][10]                                                                                                                          


Interfaces
----------

                    | Interface              | Description                                                        
------------------- | ---------------------- | ------------------------------------------------------------------ 
![Public interface] | [IDiscoveryService][5] | Interface for Mobile Connect Discovery requests                    
![Public interface] | [IPreferences][11]     | Interface for specifying required options in the discovery process 

[1]: DiscoveryOptions/README.md
[2]: IDiscoveryService/StartAutomatedOperatorDiscoveryAsync_1.md
[3]: DiscoveryResponse/README.md
[4]: DiscoveryService/README.md
[5]: IDiscoveryService/README.md
[6]: OperatorUrls/README.md
[7]: ParsedDiscoveryRedirect/README.md
[8]: ProviderMetadata/README.md
[9]: SupportedVersions/README.md
[10]: ProviderMetadata/MobileConnectVersionSupported.md
[11]: IPreferences/README.md
[12]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public interface]: ../_icons/pubinterface.gif "Public interface"