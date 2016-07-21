DiscoveryOptions Class
======================
Parameters for the [StartAutomatedOperatorDiscoveryAsync(String, String, String, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][1] method. Object can be serialized to JSON to be a POST body.


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Discovery.DiscoveryOptions**  

**Namespace:** [GSMA.MobileConnect.Discovery][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class DiscoveryOptions
```

The **DiscoveryOptions** type exposes the following members.


Constructors
------------

                 | Name                  | Description                                          
---------------- | --------------------- | ---------------------------------------------------- 
![Public method] | [DiscoveryOptions][4] | Initializes a new instance of the [Object][2] class. 


Properties
----------

                   | Name                   | Description                                                                                                                                                                           
------------------ | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [ClientIP][5]          | Allows a server application to indicate the 'public IP address' of the connection from a client application/mobile browser to the server.                                             
![Public property] | [IdentifiedMCC][6]     | The identified Mobile Country Code                                                                                                                                                    
![Public property] | [IdentifiedMNC][7]     | The identified Mobile Network Code                                                                                                                                                    
![Public property] | [IsManuallySelect][8]  | Set to true if manual select is requested                                                                                                                                             
![Public property] | [IsUsingMobileData][9] | Set to "true" if your application is able to determine that the user is accessing the service via mobile data. This tells the Discovery Service to discover using the mobile-network. 
![Public property] | [LocalClientIP][10]    | The current local IP address of the client application i.e. the actual IP address currently allocated to the device running the application.                                          
![Public property] | [MSISDN][11]           | The detected or user input mobile number in E.164 number formatting                                                                                                                   
![Public property] | [RedirectUrl][12]      | The URL to redirect to after succesful discovery                                                                                                                                      
![Public property] | [SelectedMCC][13]      | The selected Mobile Country Code                                                                                                                                                      
![Public property] | [SelectedMNC][14]      | The selected Mobile Network Code                                                                                                                                                      


See Also
--------

#### Reference
[GSMA.MobileConnect.Discovery Namespace][3]  
[GSMA.MobileConnect.Discovery.IDiscoveryService][15]  

[1]: ../IDiscoveryService/StartAutomatedOperatorDiscoveryAsync_1.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: ClientIP.md
[6]: IdentifiedMCC.md
[7]: IdentifiedMNC.md
[8]: IsManuallySelect.md
[9]: IsUsingMobileData.md
[10]: LocalClientIP.md
[11]: MSISDN.md
[12]: RedirectUrl.md
[13]: SelectedMCC.md
[14]: SelectedMNC.md
[15]: ../IDiscoveryService/README.md
[16]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"