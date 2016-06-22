GSMA.MobileConnect.Discovery Namespace
======================================
This namespace contains classes pertaining to the Discovery steps of the MobileConnect process


Classes
-------

                | Class                        | Description                                                                                                                                                                                                   
--------------- | ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public class] | [Discovery][1]               | Concrete implementation of [IDiscovery][2]                                                                                                                                                                    
![Public class] | [DiscoveryOptions][3]        | Parameters for the [StartAutomatedOperatorDiscoveryAsync(String, String, String, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][4] method. Object can be serialized to JSON to be a POST body. 
![Public class] | [DiscoveryResponse][5]       | Class to hold a discovery response. This potentially holds cached data as indicated by the cached property.                                                                                                   
![Public class] | [OperatorUrls][6]            | Object to hold the operator specific urls returned from a successful discovery process call                                                                                                                   
![Public class] | [ParsedDiscoveryRedirect][7] | Class to hold details parsed from the discovery redirect                                                                                                                                                      


Interfaces
----------

                    | Interface         | Description                                                        
------------------- | ----------------- | ------------------------------------------------------------------ 
![Public interface] | [IDiscovery][2]   | Interface for Mobile Connect Discovery requests                    
![Public interface] | [IPreferences][8] | Interface for specifying required options in the discovery process 

[1]: Discovery/README.md
[2]: IDiscovery/README.md
[3]: DiscoveryOptions/README.md
[4]: IDiscovery/StartAutomatedOperatorDiscoveryAsync_1.md
[5]: DiscoveryResponse/README.md
[6]: OperatorUrls/README.md
[7]: ParsedDiscoveryRedirect/README.md
[8]: IPreferences/README.md
[9]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public interface]: ../_icons/pubinterface.gif "Public interface"