MobileConnectRequestOptions Class
=================================
Options for a single request to [MobileConnectInterface][1]. Not all options are valid for all calls that accept an instance of this class, only options that are relevant to the method being called will be used.


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

                   | Name                              | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
------------------ | --------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [AcceptedValidationResults][5]    | Bit flag specifying which validation results should be accepted as "OK", if any results not specified are returned from validation an error status to be returned when requesting a token. By default only tokens that pass all validation steps will be accepted, allowing others to be accepted is at the SDK users own risk and is not advised.                                                                                                                                                                                                                   
![Public property] | [AcrValues][6]                    | Authentication Context class Reference. Space separated string that specifies the Authentication Context Reference to be used during authentication processing. Mobile Connect Authentication and Authorization support the values "2" and "3", 2 specifies authenticate/authorize and 3 specifies autthenticate/authorize plus. If required the server may override the ACR value passed to force a higher level of assurance or if the required level of assurance is temporarily unavailable, if this happens the ID Token will contain the actual acr value used 
![Public property] | [AuthenticationOptions][7]        | Filled authentication options instance                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
![Public property] | [AutoRetrieveIdentityHeadless][8] | Whether identity should be automatically retrieved when making a headless Authentication call                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
![Public property] | [BindingMessage][9]               | Binding message to be displayed to the user when authorizing using mc_authz this will be displayed to the user along with the [ClientName][10] and [Context][11] to allow the user to identify the authorization request. This is optional.                                                                                                                                                                                                                                                                                                                          
![Public property] | [Claims][12]                      | JSON claims to be requested during authentication/authorization as specified in openid-connect-core-1_0 section 5.5.                                                                                                                                                                                                                                                                                                                                                                                                                                                 
![Public property] | [ClaimsJson][13]                  | JSON claims to be requested during authentication/authorization as specified in openid-connect-core-1_0 section 5.5.                                                                                                                                                                                                                                                                                                                                                                                                                                                 
![Public property] | [ClaimsLocales][14]               | Space separated list of user preferred languages and scripts for the Claims being returned as per RFC5646.                                                                                                                                                                                                                                                                                                                                                                                                                                                           
![Public property] | [ClientIP][15]                    | Allows a server application to indicate the 'public IP address' of the connection from a client application/mobile browser to the server.                                                                                                                                                                                                                                                                                                                                                                                                                            
![Public property] | [Context][16]                     | Context of the action being authorized, when authorizing using mc_authz this will be displayed to the user along with the [ClientName][10] and [BindingMessage][17] to allow the user to identify the authorization request                                                                                                                                                                                                                                                                                                                                          
![Public property] | [DiscoveryOptions][18]            | Filled discovery options instance                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
![Public property] | [Display][19]                     | ASCII String value to specify the user interface display for the Authentication and Consent flow. See remarks form more information.                                                                                                                                                                                                                                                                                                                                                                                                                                 
![Public property] | [Dtbs][20]                        | The Data to be signed by the private key owned by the end user. The signed data in the ID Claim as private JWT claims for this profile.                                                                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [IdTokenHint][21]                 | Generally used in conjunction with prompt=none to pass the previously issued ID Token as a hint for the current or past authentication session. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                    
![Public property] | [IsUsingMobileData][22]           | Set to "true" if your application is able to determine that the user is accessing the service via mobile data. This tells the Discovery Service to discover using the mobile-network.                                                                                                                                                                                                                                                                                                                                                                                
![Public property] | [LocalClientIP][23]               | The current local IP address of the client application i.e. the actual IP address currently allocated to the device running the application.                                                                                                                                                                                                                                                                                                                                                                                                                         
![Public property] | [LoginHint][24]                   | An indication to the IDP/Authorization Server on what ID to use for login. If known this will default to the encrypted MSISDN value. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                               
![Public property] | [MaxAge][25]                      | Specifies the maximum elapsed time in seconds since last authentication of the user. If the elapsed time is greater than this value, a reauthentication MUST be done. When this parameter is used in the request, the ID Token MUST contain the auth_time claim value.                                                                                                                                                                                                                                                                                               
![Public property] | [Prompt][26]                      | Space delimited, case-sensitive ASCII string values to specify to the Authorization Server whether to prompt or not for reauthentication and consent. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [Scope][27]                       | Space delimited and case-sensitive list of ASCII strings for OAuth 2.0 scope values. OIDC Authorisation request MUST contain the scope value “openid”. The other optional values for scope in OIDC are: "profile", "email", "address", "phone" and "offline_access".                                                                                                                                                                                                                                                                                                 
![Public property] | [TokenValidationOptions][28]      | Filled token validation options instance                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
![Public property] | [UiLocales][29]                   | Space separated list of user preferred languages and scripts for the UI being returned as per RFC5646.                                                                                                                                                                                                                                                                                                                                                                                                                                                               


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][3]  

[1]: ../MobileConnectInterface/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: AcceptedValidationResults.md
[6]: AcrValues.md
[7]: AuthenticationOptions.md
[8]: AutoRetrieveIdentityHeadless.md
[9]: BindingMessage.md
[10]: ../../GSMA.MobileConnect.Authentication/AuthenticationOptions/ClientName.md
[11]: ../../GSMA.MobileConnect.Authentication/AuthenticationOptions/Context.md
[12]: Claims.md
[13]: ClaimsJson.md
[14]: ClaimsLocales.md
[15]: ClientIP.md
[16]: Context.md
[17]: ../../GSMA.MobileConnect.Authentication/AuthenticationOptions/BindingMessage.md
[18]: DiscoveryOptions.md
[19]: Display.md
[20]: Dtbs.md
[21]: IdTokenHint.md
[22]: IsUsingMobileData.md
[23]: LocalClientIP.md
[24]: LoginHint.md
[25]: MaxAge.md
[26]: Prompt.md
[27]: Scope.md
[28]: TokenValidationOptions.md
[29]: UiLocales.md
[30]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"