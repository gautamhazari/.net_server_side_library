AuthenticationOptions Class
===========================
Holds required and optional options for [StartAuthentication(String, String, String, String, String, String, SupportedVersions, AuthenticationOptions)][1]


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Authentication.AuthenticationOptions**  

**Namespace:** [GSMA.MobileConnect.Authentication][3]  
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
![Public method] | [AuthenticationOptions][4] | Initializes a new instance of the **AuthenticationOptions** class 


Properties
----------

                   | Name                    | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
------------------ | ----------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [AcrValues][5]          | Authentication Context class Reference. Space separated string that specifies the Authentication Context Reference to be used during authentication processing. Mobile Connect Authentication and Authorization support the values "2" and "3", 2 specifies authenticate/authorize and 3 specifies autthenticate/authorize plus. If required the server may override the ACR value passed to force a higher level of assurance or if the required level of assurance is temporarily unavailable, if this happens the ID Token will contain the actual acr value used 
![Public property] | [BindingMessage][6]     | Binding message to be displayed to the user when authorizing using mc_authz this will be displayed to the user along with the [ClientName][7] and [Context][8] to allow the user to identify the authorization request. This is optional.                                                                                                                                                                                                                                                                                                                            
![Public property] | [Claims][9]             | Claims to be requested during authentication/authorization, this will be serialized as JSON that conforms to the required claims format. If [ClaimsJson][10] is specified then this property will be ignored                                                                                                                                                                                                                                                                                                                                                         
![Public property] | [ClaimsJson][10]        | JSON claims to be requested during authentication/authorization as specified in openid-connect-core-1_0 section 5.5.                                                                                                                                                                                                                                                                                                                                                                                                                                                 
![Public property] | [ClaimsLocales][11]     | Space separated list of user preferred languages and scripts for the Claims being returned as per RFC5646.                                                                                                                                                                                                                                                                                                                                                                                                                                                           
![Public property] | [ClientId][12]          | The registered client id                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
![Public property] | [ClientName][7]         | ApplicationShortName for the registered application, this must be correct for the application client id when authorizing with mc_authz or authentication will fail                                                                                                                                                                                                                                                                                                                                                                                                   
![Public property] | [Context][8]            | Context of the action being authorized, when authorizing using mc_authz this will be displayed to the user along with the [ClientName][7] and [BindingMessage][6] to allow the user to identify the authorization request                                                                                                                                                                                                                                                                                                                                            
![Public property] | [Display][13]           | ASCII String value to specify the user interface display for the Authentication and Consent flow. See remarks form more information.                                                                                                                                                                                                                                                                                                                                                                                                                                 
![Public property] | [Dtbs][14]              | The Data to be signed by the private key owned by the end user. The signed data in the ID Claim as private JWT claims for this profile.                                                                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [IdTokenHint][15]       | Generally used in conjunction with prompt=none to pass the previously issued ID Token as a hint for the current or past authentication session. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                    
![Public property] | [LoginHint][16]         | An indication to the IDP/Authorization Server on what ID to use for login. If known this will default to the encrypted MSISDN value. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                               
![Public property] | [MaxAge][17]            | Specifies the maximum elapsed time in seconds since last authentication of the user. If the elapsed time is greater than this value, a reauthentication MUST be done. When this parameter is used in the request, the ID Token MUST contain the auth_time claim value.                                                                                                                                                                                                                                                                                               
![Public property] | [MaxRedirects][18]      | The number of redirects to allow during headless mode before aborting.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
![Public property] | [Nonce][19]             | String value used to associate a client session with the ID Token. It is passed unmodified from Authorisation Request to ID Token. The value SHOULD be unique per session to mitigate replay attacks.                                                                                                                                                                                                                                                                                                                                                                
![Public property] | [PollFrequencyInMs][20] | Time in ms to wait between each poll for new redirect url when in headless mode.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
![Public property] | [Prompt][21]            | Space delimited, case-sensitive ASCII string values to specify to the Authorization Server whether to prompt or not for reauthentication and consent. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [RedirectUrl][22]       | The registered application redirect url                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [Scope][23]             | Space delimited and case-sensitive list of ASCII strings for OAuth 2.0 scope values. OIDC Authorisation request MUST contain the scope value “openid”. The other optional values for scope in OIDC are: "profile", "email", "address", "phone" and "offline_access".                                                                                                                                                                                                                                                                                                 
![Public property] | [State][24]             | Value used by the client to maintain state between request and callback. A security mechanism as well, if a cryptographic binding is done with the browser cookie, to prevent Cross-Site Request Forgery.                                                                                                                                                                                                                                                                                                                                                            
![Public property] | [UiLocales][25]         | Space separated list of user preferred languages and scripts for the UI being returned as per RFC5646.                                                                                                                                                                                                                                                                                                                                                                                                                                                               


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][3]  
[GSMA.MobileConnect.Authentication.IAuthenticationService][26]  

[1]: ../IAuthenticationService/StartAuthentication.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: AcrValues.md
[6]: BindingMessage.md
[7]: ClientName.md
[8]: Context.md
[9]: Claims.md
[10]: ClaimsJson.md
[11]: ClaimsLocales.md
[12]: ClientId.md
[13]: Display.md
[14]: Dtbs.md
[15]: IdTokenHint.md
[16]: LoginHint.md
[17]: MaxAge.md
[18]: MaxRedirects.md
[19]: Nonce.md
[20]: PollFrequencyInMs.md
[21]: Prompt.md
[22]: RedirectUrl.md
[23]: Scope.md
[24]: State.md
[25]: UiLocales.md
[26]: ../IAuthenticationService/README.md
[27]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"