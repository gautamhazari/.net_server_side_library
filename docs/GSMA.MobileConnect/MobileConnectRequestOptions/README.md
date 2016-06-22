MobileConnectRequestOptions Class
=================================
Options for a single request to [MobileConnectInterface][1]


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.MobileConnectRequestOptions**  

**Namespace:** [GSMA.MobileConnect][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class MobileConnectRequestOptions
```

The **MobileConnectRequestOptions** type exposes the following members.


Constructors
------------

                 | Name                             | Description                                                             
---------------- | -------------------------------- | ----------------------------------------------------------------------- 
![Public method] | [MobileConnectRequestOptions][4] | Initializes a new instance of the **MobileConnectRequestOptions** class 


Properties
----------

                   | Name                       | Description                                                                                                                                                                             
------------------ | -------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [AuthenticationOptions][5] | Filled authentication options instance                                                                                                                                                  
![Public property] | [ClaimsLocales][6]         | Space separated list of user preferred languages and scripts for the Claims being returned as per RFC5646.                                                                              
![Public property] | [ClientIP][7]              | Allows a server application to indicate the 'public IP address' of the connection from a client application/mobile browser to the server.                                               
![Public property] | [DiscoveryOptions][8]      | Filled discovery options instance                                                                                                                                                       
![Public property] | [Display][9]               | ASCII String value to specify the user interface display for the Authentication and Consent flow. See remarks form more information.                                                    
![Public property] | [Dtbs][10]                 | The Data to be signed by the private key owned by the end user. The signed data in the ID Claim as private JWT claims for this profile.                                                 
![Public property] | [IdTokenHint][11]          | Generally used in conjunction with prompt=none to pass the previously issued ID Token as a hint for the current or past authentication session. See remarks for more information.       
![Public property] | [IsUsingMobileData][12]    | Set to "true" if your application is able to determine that the user is accessing the service via mobile data. This tells the Discovery Service to discover using the mobile-network.   
![Public property] | [LocalClientIP][13]        | The current local IP address of the client application i.e. the actual IP address currently allocated to the device running the application.                                            
![Public property] | [LoginHint][14]            | An indication to the IDP/Authorization Server on what ID to use for login. If known this will default to the encrypted MSISDN value. See remarks for more information.                  
![Public property] | [Prompt][15]               | Space delimited, case-sensitive ASCII string values to specify to the Authorization Server whether to prompt or not for reauthentication and consent. See remarks for more information. 
![Public property] | [UiLocales][16]            | Space separated list of user preferred languages and scripts for the UI being returned as per RFC5646.                                                                                  


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][3]  

[1]: ../MobileConnectInterface/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: AuthenticationOptions.md
[6]: ClaimsLocales.md
[7]: ClientIP.md
[8]: DiscoveryOptions.md
[9]: Display.md
[10]: Dtbs.md
[11]: IdTokenHint.md
[12]: IsUsingMobileData.md
[13]: LocalClientIP.md
[14]: LoginHint.md
[15]: Prompt.md
[16]: UiLocales.md
[17]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"