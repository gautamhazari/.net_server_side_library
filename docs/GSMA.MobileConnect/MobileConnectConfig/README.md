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
------------------ | -------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [AuthorizationAcrValues][6]      | Authentication Context class Reference. Space separated string that specifies the Authentication Context Reference to be used during authentication processing. The LOA required by the RP/Client for the use case can be used here. The values appear as order of preference. The acr satisfied during authentication is returned as acr claim value. The recommended values are the LOAs as specified in ISO/IEC 29115 Clause 6 – 1, 2, 3, 4 – representing the LOAs of LOW, MEDIUM, HIGH and VERY HIGH. The acr_values are indication of what authentication methods to used by the IDP. The authentication methods to be used are linked to the LOA value passed in the acr_values. The IDP configures the authentication method selection logic based on the acr_values. 
![Public property] | [AuthorizationMaxAge][7]         | Specifies the maximum elapsed time in seconds since last authentication of the user. If the elapsed time is greater than this value, a reauthentication MUST be done. When this parameter is used in the request, the ID Token MUST contain the auth_time claim value.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
![Public property] | [AuthorizationScope][8]          | Space delimited and case-sensitive list of ASCII strings for OAuth 2.0 scope values. OIDC Authorisation request MUST contain the scope value “openid”. The other optional values for scope in OIDC are: "profile", "email", "address", "phone" and "offline_access".                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
![Public property] | [CacheResponsesWithSessionId][9] | When set to true [MobileConnectWebInterface][2] will use the configured discovery cache to cache discovery responses against a session id. This allows the session id to be passed to following calls in the mobile connect process instead of requiring the discovery response to be passed. (DEFAULTS to true)                                                                                                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [ClientId][10]                   | The application client Id                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
![Public property] | [ClientSecret][11]               | The application client secret                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
![Public property] | [DiscoveryUrl][12]               | The URL of the discovery service endpoint                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
![Public property] | [RedirectUrl][13]                | The redirect url specified for the mobileconnect application                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][4]  
[GSMA.MobileConnect.Discovery.IPreferences][14]  

[1]: ../MobileConnectInterface/README.md
[2]: ../MobileConnectWebInterface/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: _ctor.md
[6]: AuthorizationAcrValues.md
[7]: AuthorizationMaxAge.md
[8]: AuthorizationScope.md
[9]: CacheResponsesWithSessionId.md
[10]: ClientId.md
[11]: ClientSecret.md
[12]: DiscoveryUrl.md
[13]: RedirectUrl.md
[14]: ../../GSMA.MobileConnect.Discovery/IPreferences/README.md
[15]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"