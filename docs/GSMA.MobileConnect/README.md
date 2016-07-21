GSMA.MobileConnect Namespace
============================
This namespace contains the classes requried to attempt the MobileConnect process


Classes
-------

                | Class                            | Description                                                                                                                                                                        
--------------- | -------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public class] | [ErrorResponse][1]               | Class to hold a Rest error response                                                                                                                                                
![Public class] | [MobileConnectConfig][2]         | Configuration properties for the MobileConnectInterface, reused across all requests for a single [MobileConnectInterface][3] or [MobileConnectWebInterface][4]                     
![Public class] | [MobileConnectConstants][5]      | Constants relating to Mobile Connect such as available scope values                                                                                                                
![Public class] | [MobileConnectInterface][3]      | Convenience wrapper for [IDiscoveryService][6] and [IAuthenticationService][7] methods for use with non-web .Net targets                                                           
![Public class] | [MobileConnectRequestOptions][8] | Options for a single request to [MobileConnectInterface][3]                                                                                                                        
![Public class] | [MobileConnectStatus][9]         | Object to hold the details of a response returned from [MobileConnectInterface][3] and [MobileConnectWebInterface][4] all information required to continue the process is included 
![Public class] | [MobileConnectWebInterface][4]   | Convenience wrapper for [IDiscoveryService][6] and [IAuthenticationService][7] methods for use with ASP.NET                                                                        


Enumerations
------------

                      | Enumeration                     | Description                                                  
--------------------- | ------------------------------- | ------------------------------------------------------------ 
![Public enumeration] | [MobileConnectResponseType][10] | Enum of possible response types for [MobileConnectStatus][9] 

[1]: ErrorResponse/README.md
[2]: MobileConnectConfig/README.md
[3]: MobileConnectInterface/README.md
[4]: MobileConnectWebInterface/README.md
[5]: MobileConnectConstants/README.md
[6]: ../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[7]: ../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[8]: MobileConnectRequestOptions/README.md
[9]: MobileConnectStatus/README.md
[10]: MobileConnectResponseType/README.md
[11]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public enumeration]: ../_icons/pubenumeration.gif "Public enumeration"