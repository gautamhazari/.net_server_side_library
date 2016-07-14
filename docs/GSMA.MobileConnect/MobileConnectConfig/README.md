MobileConnectConfig Class
=========================
Configuration properties for the MobileConnectInterface, reused across all requests for a single [MobileConnectInterface][1] or [MobileConnectWebInterface][2]


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **GSMA.MobileConnect.MobileConnectConfig**  

**Namespace:** [GSMA.MobileConnect][4]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class MobileConnectConfig : IPreferences
```

The **MobileConnectConfig** type exposes the following members.


Constructors
------------

                 | Name                     | Description                                                     
---------------- | ------------------------ | --------------------------------------------------------------- 
![Public method] | [MobileConnectConfig][5] | Initializes a new instance of the **MobileConnectConfig** class 


Properties
----------

                   | Name                             | Description                                                                                                                                                                                                                                                                                                      
------------------ | -------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [CacheResponsesWithSessionId][6] | When set to true [MobileConnectWebInterface][2] will use the configured discovery cache to cache discovery responses against a session id. This allows the session id to be passed to following calls in the mobile connect process instead of requiring the discovery response to be passed. (DEFAULTS to true) 
![Public property] | [ClientId][7]                    | The application client Id                                                                                                                                                                                                                                                                                        
![Public property] | [ClientSecret][8]                | The application client secret                                                                                                                                                                                                                                                                                    
![Public property] | [DiscoveryUrl][9]                | The URL of the discovery service endpoint                                                                                                                                                                                                                                                                        
![Public property] | [RedirectUrl][10]                | The redirect url specified for the mobileconnect application                                                                                                                                                                                                                                                     


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][4]  
[GSMA.MobileConnect.Discovery.IPreferences][11]  

[1]: ../MobileConnectInterface/README.md
[2]: ../MobileConnectWebInterface/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: _ctor.md
[6]: CacheResponsesWithSessionId.md
[7]: ClientId.md
[8]: ClientSecret.md
[9]: DiscoveryUrl.md
[10]: RedirectUrl.md
[11]: ../../GSMA.MobileConnect.Discovery/IPreferences/README.md
[12]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"