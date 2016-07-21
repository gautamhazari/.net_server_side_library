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
------------------ | -------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [AcrValues][5]             | Authentication Context class Reference. Space separated string that specifies the Authentication Context Reference to be used during authentication processing. Mobile Connect Authentication and Authorization support the values "2" and "3", 2 specifies authenticate/authorize and 3 specifies autthenticate/authorize plus. If required the server may override the ACR value passed to force a higher level of assurance or if the required level of assurance is temporarily unavailable, if this happens the ID Token will contain the actual acr value used 
![Public property] | [AuthenticationOptions][6] | Filled authentication options instance                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
![Public property] | [BindingMessage][7]        | Binding message to be displayed to the user when authorizing using mc_authz this will be displayed to the user along with the [ClientName][8] and [Context][9] to allow the user to identify the authorization request. This is optional.                                                                                                                                                                                                                                                                                                                            
![Public property] | [Claims][10]               | JSON claims to be requested during authentication/authorization as specified in openid-connect-core-1_0 section 5.5.                                                                                                                                                                                                                                                                                                                                                                                                                                                 
![Public property] | [ClaimsJson][11]           | JSON claims to be requested during authentication/authorization as specified in openid-connect-core-1_0 section 5.5.                                                                                                                                                                                                                                                                                                                                                                                                                                                 
![Public property] | [ClaimsLocales][12]        | Space separated list of user preferred languages and scripts for the Claims being returned as per RFC5646.                                                                                                                                                                                                                                                                                                                                                                                                                                                           
![Public property] | [ClientIP][13]             | Allows a server application to indicate the 'public IP address' of the connection from a client application/mobile browser to the server.                                                                                                                                                                                                                                                                                                                                                                                                                            
![Public property] | [Context][14]              | Context of the action being authorized, when authorizing using mc_authz this will be displayed to the user along with the [ClientName][8] and [BindingMessage][15] to allow the user to identify the authorization request                                                                                                                                                                                                                                                                                                                                           
![Public property] | [DiscoveryOptions][16]     | Filled discovery options instance                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
![Public property] | [Display][17]              | ASCII String value to specify the user interface display for the Authentication and Consent flow. See remarks form more information.                                                                                                                                                                                                                                                                                                                                                                                                                                 
![Public property] | [Dtbs][18]                 | The Data to be signed by the private key owned by the end user. The signed data in the ID Claim as private JWT claims for this profile.                                                                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [IdTokenHint][19]          | Generally used in conjunction with prompt=none to pass the previously issued ID Token as a hint for the current or past authentication session. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                    
![Public property] | [IsUsingMobileData][20]    | Set to "true" if your application is able to determine that the user is accessing the service via mobile data. This tells the Discovery Service to discover using the mobile-network.                                                                                                                                                                                                                                                                                                                                                                                
![Public property] | [LocalClientIP][21]        | The current local IP address of the client application i.e. the actual IP address currently allocated to the device running the application.                                                                                                                                                                                                                                                                                                                                                                                                                         
![Public property] | [LoginHint][22]            | An indication to the IDP/Authorization Server on what ID to use for login. If known this will default to the encrypted MSISDN value. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                               
![Public property] | [MaxAge][23]               | Specifies the maximum elapsed time in seconds since last authentication of the user. If the elapsed time is greater than this value, a reauthentication MUST be done. When this parameter is used in the request, the ID Token MUST contain the auth_time claim value.                                                                                                                                                                                                                                                                                               
![Public property] | [Prompt][24]               | Space delimited, case-sensitive ASCII string values to specify to the Authorization Server whether to prompt or not for reauthentication and consent. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [Scope][25]                | Space delimited and case-sensitive list of ASCII strings for OAuth 2.0 scope values. OIDC Authorisation request MUST contain the scope value “openid”. The other optional values for scope in OIDC are: "profile", "email", "address", "phone" and "offline_access".                                                                                                                                                                                                                                                                                                 
![Public property] | [UiLocales][26]            | Space separated list of user preferred languages and scripts for the UI being returned as per RFC5646.                                                                                                                                                                                                                                                                                                                                                                                                                                                               


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][3]  

[1]: ../MobileConnectInterface/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: AcrValues.md
[6]: AuthenticationOptions.md
[7]: BindingMessage.md
[8]: ../../GSMA.MobileConnect.Authentication/AuthenticationOptions/ClientName.md
[9]: ../../GSMA.MobileConnect.Authentication/AuthenticationOptions/Context.md
[10]: Claims.md
[11]: ClaimsJson.md
[12]: ClaimsLocales.md
[13]: ClientIP.md
[14]: Context.md
[15]: ../../GSMA.MobileConnect.Authentication/AuthenticationOptions/BindingMessage.md
[16]: DiscoveryOptions.md
[17]: Display.md
[18]: Dtbs.md
[19]: IdTokenHint.md
[20]: IsUsingMobileData.md
[21]: LocalClientIP.md
[22]: LoginHint.md
[23]: MaxAge.md
[24]: Prompt.md
[25]: Scope.md
[26]: UiLocales.md
[27]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"