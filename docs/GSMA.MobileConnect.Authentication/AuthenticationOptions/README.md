AuthenticationOptions Class
===========================
Holds required and optional options for [StartAuthentication(String, String, String, String, String, String, Nullable&lt;Int32>, String, String, AuthenticationOptions)][1]


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
---------------- | -------------------------- | ---------------------------------------------------- 
![Public method] | [AuthenticationOptions][4] | Initializes a new instance of the [Object][2] class. 


Properties
----------

                   | Name               | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
------------------ | ------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [AcrValues][5]     | Authentication Context class Reference. Space separated string that specifies the Authentication Context Reference to be used during authentication processing. The LOA required by the RP/Client for the use case can be used here. The values appear as order of preference. The acr satisfied during authentication is returned as acr claim value. The recommended values are the LOAs as specified in ISO/IEC 29115 Clause 6 – 1, 2, 3, 4 – representing the LOAs of LOW, MEDIUM, HIGH and VERY HIGH. The acr_values are indication of what authentication methods to used by the IDP. The authentication methods to be used are linked to the LOA value passed in the acr_values. The IDP configures the authentication method selection logic based on the acr_values. 
![Public property] | [ClaimsLocales][6] | Space separated list of user preferred languages and scripts for the Claims being returned as per RFC5646.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
![Public property] | [ClientId][7]      | The registered client id                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
![Public property] | [Display][8]       | ASCII String value to specify the user interface display for the Authentication and Consent flow. See remarks form more information.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
![Public property] | [Dtbs][9]          | The Data to be signed by the private key owned by the end user. The signed data in the ID Claim as private JWT claims for this profile.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
![Public property] | [IdTokenHint][10]  | Generally used in conjunction with prompt=none to pass the previously issued ID Token as a hint for the current or past authentication session. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
![Public property] | [LoginHint][11]    | An indication to the IDP/Authorization Server on what ID to use for login. If known this will default to the encrypted MSISDN value. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
![Public property] | [MaxAge][12]       | Specifies the maximum elapsed time in seconds since last authentication of the user. If the elapsed time is greater than this value, a reauthentication MUST be done. When this parameter is used in the request, the ID Token MUST contain the auth_time claim value.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
![Public property] | [Nonce][13]        | String value used to associate a client session with the ID Token. It is passed unmodified from Authorisation Request to ID Token. The value SHOULD be unique per session to mitigate replay attacks.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
![Public property] | [Prompt][14]       | Space delimited, case-sensitive ASCII string values to specify to the Authorization Server whether to prompt or not for reauthentication and consent. See remarks for more information.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
![Public property] | [RedirectUrl][15]  | The registered application redirect url                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
![Public property] | [Scope][16]        | Space delimited and case-sensitive list of ASCII strings for OAuth 2.0 scope values. OIDC Authorisation request MUST contain the scope value “openid”. The other optional values for scope in OIDC are: "profile", "email", "address", "phone" and "offline_access".                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
![Public property] | [State][17]        | Value used by the client to maintain state between request and callback. A security mechanism as well, if a cryptographic binding is done with the browser cookie, to prevent Cross-Site Request Forgery.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
![Public property] | [UiLocales][18]    | Space separated list of user preferred languages and scripts for the UI being returned as per RFC5646.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][3]  
[GSMA.MobileConnect.Authentication.IAuthentication][19]  

[1]: ../IAuthentication/StartAuthentication.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: AcrValues.md
[6]: ClaimsLocales.md
[7]: ClientId.md
[8]: Display.md
[9]: Dtbs.md
[10]: IdTokenHint.md
[11]: LoginHint.md
[12]: MaxAge.md
[13]: Nonce.md
[14]: Prompt.md
[15]: RedirectUrl.md
[16]: Scope.md
[17]: State.md
[18]: UiLocales.md
[19]: ../IAuthentication/README.md
[20]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"