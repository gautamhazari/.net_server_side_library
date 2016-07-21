MobileConnectStatus Class
=========================
Object to hold the details of a response returned from [MobileConnectInterface][1] and [MobileConnectWebInterface][2] all information required to continue the process is included


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **GSMA.MobileConnect.MobileConnectStatus**  

**Namespace:** [GSMA.MobileConnect][4]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class MobileConnectStatus
```

The **MobileConnectStatus** type exposes the following members.


Properties
----------

                   | Name                   | Description                                                                                                             
------------------ | ---------------------- | ----------------------------------------------------------------------------------------------------------------------- 
![Public property] | [DiscoveryResponse][5] | Complete discovery response if included                                                                                 
![Public property] | [ErrorCode][6]         | Error code if included                                                                                                  
![Public property] | [ErrorMessage][7]      | User friendly error description if included                                                                             
![Public property] | [Exception][8]         | Exception encountered during request if included                                                                        
![Public property] | [IdentityResponse][9]  | Complete identity response if included                                                                                  
![Public property] | [Nonce][10]            | Nonce value used for Authorization                                                                                      
![Public property] | [ResponseType][11]     | Type of response, indicates the step in the process that should be triggered next                                       
![Public property] | [SDKSession][12]       | SDK session id used to link sessions to discovery responses when [CacheResponsesWithSessionId][13] is set to true       
![Public property] | [SetCookie][14]        | Content of the Set-Cookie header returned in the response, should be used to proxy cookies back to the user if required 
![Public property] | [State][15]            | State value used for Authorization                                                                                      
![Public property] | [TokenResponse][16]    | Complete token response if included                                                                                     
![Public property] | [Url][17]              | Url to navigate to in the next step if required                                                                         


Methods
-------

                                 | Name                                                         | Description                                                                                                                                                                  
-------------------------------- | ------------------------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]![Static member] | [Authorization][18]                                          | Creates a Status with ResponseType Authorization and url for next process step. Indicates that the next step should be navigating to the Authorization URL.                  
![Public method]![Static member] | [Complete][19]                                               | Creates a Status with ResponseType Complete and the complete [RequestTokenResponse][20]. Indicates that the MobileConnect process is complete and the user is authenticated. 
![Public method]![Static member] | [Error(String, String, Exception)][21]                       | Creates a Status with ResponseType error and error related properties filled. Indicates that the MobileConnect process has been aborted due to an issue encountered.         
![Public method]![Static member] | [Error(String, String, Exception, RequestTokenResponse)][22] | Creates a Status with ResponseType error and error related properties filled. Indicates that the MobileConnect process has been aborted due to an issue encountered.         
![Public method]![Static member] | [Error(String, String, Exception, DiscoveryResponse)][23]    | Creates a Status with ResponseType error and error related properties filled. Indicates that the MobileConnect process has been aborted due to an issue encountered.         
![Public method]![Static member] | [Identity][24]                                               | Creates a status with ResponseType Identity and the complete [IdentityResponse][9]. Indicates that an identity request has been successful.                                  
![Public method]![Static member] | [OperatorSelection][25]                                      | Creates a Status with ResponseType OperatorSelection and url for next process step. Indicates that the next step should be navigating to the operator selection URL.         
![Public method]![Static member] | [StartAuthorization][26]                                     | Creates a Status with ResponseType StartAuthorization and the complete [DiscoveryResponse][5]. Indicates that the next step should be starting authorization.                
![Public method]![Static member] | [StartDiscovery][27]                                         | Creates a Status with ResponseType StartDiscovery. Indicates that some required data was missing and the discovery process needs to be restarted.                            
![Public method]![Static member] | [UserInfo][28]                                               | Creates a status with ResponseType UserInfo and the complete [IdentityResponse][9]. Indicates that a user info request has been successful.                                  


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][4]  

[1]: ../MobileConnectInterface/README.md
[2]: ../MobileConnectWebInterface/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: DiscoveryResponse.md
[6]: ErrorCode.md
[7]: ErrorMessage.md
[8]: Exception.md
[9]: IdentityResponse.md
[10]: Nonce.md
[11]: ResponseType.md
[12]: SDKSession.md
[13]: ../MobileConnectConfig/CacheResponsesWithSessionId.md
[14]: SetCookie.md
[15]: State.md
[16]: TokenResponse.md
[17]: Url.md
[18]: Authorization.md
[19]: Complete.md
[20]: ../../GSMA.MobileConnect.Authentication/RequestTokenResponse/README.md
[21]: Error.md
[22]: Error_1.md
[23]: Error_2.md
[24]: Identity.md
[25]: OperatorSelection.md
[26]: StartAuthorization.md
[27]: StartDiscovery.md
[28]: UserInfo.md
[29]: ../../_icons/Help.png
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"