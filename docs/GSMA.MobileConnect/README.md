GSMA.MobileConnect Namespace
============================
This namespace contains the classes requried to attempt the MobileConnect process


Classes
-------

                | Class                             | Description                                                                                                                                                                                                         
--------------- | --------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public class] | [ErrorResponse][1]                | Class to hold a Rest error response                                                                                                                                                                                 
![Public class] | [Log][2]                          | Static log class for handling all logging. Implementing applications should register an ILogger instance using [RegisterLogger(ILogger, LogLevel)][3]                                                               
![Public class] | [MobileConnectConfig][4]          | Configuration properties for the MobileConnectInterface, reused across all requests for a single [MobileConnectInterface][5] or [MobileConnectWebInterface][6]                                                      
![Public class] | [MobileConnectConstants][7]       | Constants relating to Mobile Connect such as available scope values                                                                                                                                                 
![Public class] | [MobileConnectInterface][5]       | Convenience wrapper for [IDiscoveryService][8] and [IAuthenticationService][9] methods for use with non-web .Net targets                                                                                            
![Public class] | [MobileConnectRequestOptions][10] | Options for a single request to [MobileConnectInterface][5]. Not all options are valid for all calls that accept an instance of this class, only options that are relevant to the method being called will be used. 
![Public class] | [MobileConnectStatus][11]         | Object to hold the details of a response returned from [MobileConnectInterface][5] and [MobileConnectWebInterface][6] all information required to continue the process is included                                  
![Public class] | [MobileConnectWebInterface][6]    | Convenience wrapper for [IDiscoveryService][8] and [IAuthenticationService][9] methods for use with ASP.NET                                                                                                         


Interfaces
----------

                    | Interface     | Description                                 
------------------- | ------------- | ------------------------------------------- 
![Public interface] | [ILogger][12] | Interface defining required logging methods 


Enumerations
------------

                      | Enumeration                     | Description                                                   
--------------------- | ------------------------------- | ------------------------------------------------------------- 
![Public enumeration] | [LogLevel][13]                  | Level of logging to execute                                   
![Public enumeration] | [MobileConnectResponseType][14] | Enum of possible response types for [MobileConnectStatus][11] 

[1]: ErrorResponse/README.md
[2]: Log/README.md
[3]: Log/RegisterLogger.md
[4]: MobileConnectConfig/README.md
[5]: MobileConnectInterface/README.md
[6]: MobileConnectWebInterface/README.md
[7]: MobileConnectConstants/README.md
[8]: ../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[9]: ../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[10]: MobileConnectRequestOptions/README.md
[11]: MobileConnectStatus/README.md
[12]: ILogger/README.md
[13]: LogLevel/README.md
[14]: MobileConnectResponseType/README.md
[15]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public interface]: ../_icons/pubinterface.gif "Public interface"
[Public enumeration]: ../_icons/pubenumeration.gif "Public enumeration"