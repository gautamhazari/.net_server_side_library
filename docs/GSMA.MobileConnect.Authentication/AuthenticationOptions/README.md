AuthenticationOptions Class
===========================
Holds required and optional options for [!:IAuthentication.StartAuthentication(string, string, string, string, string, string, string, AuthenticationOptions)]


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Authentication.AuthenticationOptions**  

**Namespace:** [GSMA.MobileConnect.Authentication][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class AuthenticationOptions
```

The **AuthenticationOptions** type exposes the following members.


Constructors
------------

                 | Name                       | Description                                                       
---------------- | -------------------------- | ----------------------------------------------------------------- 
![Public method] | [AuthenticationOptions][3] | Initializes a new instance of the **AuthenticationOptions** class 


Properties
----------

                   | Name                | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
------------------ | ------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [AcrValues][4]      | Authentication Context class Reference. Space separated string that specifies the Authentication Context Reference to be used during authentication processing. Mobile Connect Authentication and Authorization support the values "2" and "3", 2 specifies authenticate/authorize and 3 specifies autthenticate/authorize plus. If required the server may override the ACR value passed to force a higher level of assurance or if the required level of assurance is temporarily unavailable, if this happens the ID Token will contain the actual acr value used 
![Public property] | [BindingMessage][5] | Binding message to be displayed to the user when authorizing using mc_authz this will be displayed to the user along with the [ClientName][6] and [Context][7] to allow the user to identify the authorization request. This is optional.                                                                                                                                                                                                                                                                                                                            
![Public property] | [ClaimsLocales][8]  | Space separated list of user preferred languages and scripts for the Claims being returned as per RFC5646.                                                                                                                                                                                                                                                                                                                                                                                                                                                           
![Public property] | [ClientId][9]       | The registered client id                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
![Public property] | [ClientName][6]     | ApplicationShortName for the registered application, this must be correct for the application client id when authorizing with mc_authz or authentication will fail                                                                                                                                                                                                                                                                                                                                                                                                   
![Public property] | [Context][7]        | Context of the action being authorized, when authorizing using mc_authz this will be displayed to the user along with the [ClientName][6] and [BindingMessage][5] to allow the user to identify the authorization request                                                                                                                                                                                                                                                                                                                                            
![Public property] | [Display][10]       | ASCII String value to specify the user interface display for the Authentication and Consent flow. See remarks form more information.                                                                                                                                                                                                                                                                                                                                                                                                                                 
![Public property] | [Dtbs][11]          | The Data to be signed by the private key owned by the end user. The signed data in the ID Claim as private JWT claims for this profile.                                                                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [IdTokenHint][12]   | Generally used in conjunction with prompt=none to pass the previously issued ID Token as a hint for the current or past authentication session. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                    
![Public property] | [LoginHint][13]     | An indication to the IDP/Authorization Server on what ID to use for login. If known this will default to the encrypted MSISDN value. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                               
![Public property] | [MaxAge][14]        | Specifies the maximum elapsed time in seconds since last authentication of the user. If the elapsed time is greater than this value, a reauthentication MUST be done. When this parameter is used in the request, the ID Token MUST contain the auth_time claim value.                                                                                                                                                                                                                                                                                               
![Public property] | [Nonce][15]         | String value used to associate a client session with the ID Token. It is passed unmodified from Authorisation Request to ID Token. The value SHOULD be unique per session to mitigate replay attacks.                                                                                                                                                                                                                                                                                                                                                                
![Public property] | [Prompt][16]        | Space delimited, case-sensitive ASCII string values to specify to the Authorization Server whether to prompt or not for reauthentication and consent. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [RedirectUrl][17]   | The registered application redirect url                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [Scope][18]         | Space delimited and case-sensitive list of ASCII strings for OAuth 2.0 scope values. OIDC Authorisation request MUST contain the scope value “openid”. The other optional values for scope in OIDC are: "profile", "email", "address", "phone" and "offline_access".                                                                                                                                                                                                                                                                                                 
![Public property] | [State][19]         | Value used by the client to maintain state between request and callback. A security mechanism as well, if a cryptographic binding is done with the browser cookie, to prevent Cross-Site Request Forgery.                                                                                                                                                                                                                                                                                                                                                            
![Public property] | [UiLocales][20]     | Space separated list of user preferred languages and scripts for the UI being returned as per RFC5646.                                                                                                                                                                                                                                                                                                                                                                                                                                                               


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][2]  
[GSMA.MobileConnect.Authentication.IAuthentication][21]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: AcrValues.md
[5]: BindingMessage.md
[6]: ClientName.md
[7]: Context.md
[8]: ClaimsLocales.md
[9]: ClientId.md
[10]: Display.md
[11]: Dtbs.md
[12]: IdTokenHint.md
[13]: LoginHint.md
[14]: MaxAge.md
[15]: Nonce.md
[16]: Prompt.md
[17]: RedirectUrl.md
[18]: Scope.md
[19]: State.md
[20]: UiLocales.md
[21]: ../IAuthentication/README.md
[22]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"