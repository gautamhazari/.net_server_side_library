ProviderMetadata Class
======================
Parsed Provider Metadata returned from openid-configuration url


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Discovery.ProviderMetadata**  

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class ProviderMetadata : ICacheable
```

The **ProviderMetadata** type exposes the following members.


Constructors
------------

                 | Name                                     | Description                                                                                                                                                               
---------------- | ---------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [ProviderMetadata()][3]                  | Creates a new instance of the Provider Metadata class                                                                                                                     
![Public method] | [ProviderMetadata(SupportedVersions)][4] | Creates a new intance of ProviderMetadata using the input dictionary for MobileConnectVersionSupported. This is used to construct the object when deserializing from JSON 


Properties
----------

                                   | Name                                             | Description                                                                                                                                                                                                                                                                             
---------------------------------- | ------------------------------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property]                 | [ACRValuesSupported][5]                          | Array containing Authentication Context Class References that the issuer supports                                                                                                                                                                                                       
![Public property]                 | [AuthorizationEndpoint][6]                       | Authorization endpoint to use if different from url returned by discovery                                                                                                                                                                                                               
![Public property]                 | [Cached][7]                                      | Returns true if object came from cache                                                                                                                                                                                                                                                  
![Public property]                 | [CheckSessionIframe][8]                          |                                                                                                                                                                                                                                                                                         
![Public property]                 | [ClaimsLocalesSupported][9]                      | Array containing languages and scripts supported for values in Claims being returned as an array of BCP47 [RFC5646] language tag values. Not all languages and scripts are necessarily supported for all Claim values                                                                   
![Public property]                 | [ClaimsParameterSupported][10]                   | Boolean value specifying whether the issuer supports use of the claims parameter, with true indicating support                                                                                                                                                                          
![Public property]                 | [ClaimsSupported][11]                            | Array containing the Claim Names of the Claims that the issuer MAY be able to supply values for. Note that for privacy or other reasons this may not be an exhaustive list                                                                                                              
![Public property]                 | [ClaimTypesSupported][12]                        | Array containing the Claim Types that the issuer supports. These Claim Types are described inn Section 5.6 of OpenID Connect Core 1.0                                                                                                                                                   
![Public property]![Static member] | [Default][13]                                    | Default ProviderMetadata instance used if an instance is not available                                                                                                                                                                                                                  
![Public property]                 | [DisplayValuesSupported][14]                     | Array containing the display parameter values that the issuer supports                                                                                                                                                                                                                  
![Public property]                 | [EndSessionEndpoint][15]                         |                                                                                                                                                                                                                                                                                         
![Public property]                 | [GrantTypesSupported][16]                        | Array containing OAuth 2.0 grant_type values that the issuer supports                                                                                                                                                                                                                   
![Public property]                 | [HasExpired][17]                                 | Returns true if the object has expired and should be removed from the cache                                                                                                                                                                                                             
![Public property]                 | [IdTokenEncryptionAlgValuesSupported][18]        | Array containing a list of the JWE encryption algorithms (alg values) [JWA] supported by the issuer for the ID Token to encode the claims in a JWT                                                                                                                                      
![Public property]                 | [IdTokenEncryptionEncValuesSupported][19]        | Array containing a list of the JWE encryption algorithms (enc values) [JWE] supported by the issuer for the ID Token to encode the claims in a JWT                                                                                                                                      
![Public property]                 | [IdTokenSigningAlgValuesSupported][20]           | Array containing the JWS signing algorithms [JWA] supported by the issuer for the ID Token to encode the claims in a JWT                                                                                                                                                                
![Public property]                 | [Issuer][21]                                     | The name of the issuer the provider metadata is related to. This value is used when validating the returned ID Token                                                                                                                                                                    
![Public property]                 | [JwksUri][22]                                    | JWKS endpoint to use if different from url returned by discovery                                                                                                                                                                                                                        
![Public property]                 | [LoginHintMethodsSupported][23]                  | Array containing a list of the login hint methods supported by the issuer ID Gateway                                                                                                                                                                                                    
![Public property]                 | [MobileConnectVersionSupported][24]              | Dictionary of values that represent the supported versions for different mobile connect services from this provider. These versions are used when constructing calls to the services.                                                                                                   
![Public property]                 | [OperatorPolicyUri][25]                          | URL that the OpenID Provider provides to the person registering the Client to read about the issuer requirements on how the Relying Party can use the data provided by the issuer. The registration process SHOULD display this URL to the person registering the Client if it is given 
![Public property]                 | [OperatorTermsOfServiceUri][26]                  | URL that the issuer provides to the person registering the Client to read about the issuers terms of service. The registration process SHOULD display this URL to the person registering the client if it is given                                                                      
![Public property]                 | [PremiumInfoEndpoint][27]                        | PremiumInfo endpoint to use if different from url returned by discovery                                                                                                                                                                                                                 
![Public property]                 | [RefreshEndpoint][28]                            | Refresh Token endpoint to use if different from url returned by discovery                                                                                                                                                                                                               
![Public property]                 | [RegistrationEndpoint][29]                       | Registration endpoint to use if different from url returned by discovery                                                                                                                                                                                                                
![Public property]                 | [RequestObjectEncryptionAlgValuesSupported][30]  | Array containing the JWE encryption algorithms (alg values) [JWA] supported by the issuer for Request Objects which are described in Section 6.1 of OpenID Connect Core 1.0                                                                                                             
![Public property]                 | [RequestObjectEncryptionEncValuesSupported][31]  | Array containing the JWE encryption algorithms (enc values) [JWE] supported by the issuer for Request Objects which are described in Section 6.1 of OpenID Connect Core 1.0                                                                                                             
![Public property]                 | [RequestObjectSigningAlgValuesSupported][32]     | Array containing the JWS signing algorithms [JWA] supported by the issuer for Request Objects which are described in Section 6.1 of OpenID Connect Core 1.0                                                                                                                             
![Public property]                 | [RequestParameterSupported][33]                  | Boolean value specifying whether the issuer supports use of the request parameter, with true indicating support                                                                                                                                                                         
![Public property]                 | [RequestUriParameterSupported][34]               | Boolean value specifying whether the issuer supports use of the request uri parameter, with true indicating support                                                                                                                                                                     
![Public property]                 | [RequireRequestUriRegistration][35]              | Boolean value specifying whether the issuer requires any request_uri values used to be pre-registered using the request_uris registration parameter. Pre-registration is required when the value is true                                                                                
![Public property]                 | [ResponseModesSupported][36]                     | Array containing OAuth 2.0 response_mode values that the issuer supports, as specified in OAuth 2.0 Multiple Response Type Encoding Practices                                                                                                                                           
![Public property]                 | [ResponseTypesSupported][37]                     | Array containing OAuth 2.0 response_type values that the issuer supports                                                                                                                                                                                                                
![Public property]                 | [RevokeEndpoint][38]                             | Revoke Token endpoint to use if different from url returned by discovery                                                                                                                                                                                                                
![Public property]                 | [ScopesSupported][39]                            | A list of OAuth 2.0 scope values that the issuer supports, these can be easily queried using [IsMobileConnectServiceSupported(String)][40]                                                                                                                                              
![Public property]                 | [ServiceDocumentation][41]                       | URL of a page containing human readable information that developers might want or need to know when using the issuing service                                                                                                                                                           
![Public property]                 | [SubjectTypesSupported][42]                      | Array containing a list of the Subject Identifier Types that the issuer supports                                                                                                                                                                                                        
![Public property]                 | [TimeCachedUtc][43]                              | Time when the object was initially cached                                                                                                                                                                                                                                               
![Public property]                 | [TokenEndpoint][44]                              | Token endpoint to use if different from url returned by discovery                                                                                                                                                                                                                       
![Public property]                 | [TokenEndpointAuthMethodsSupported][45]          | Array containing the Client Authentication methods suppoorted by the Token Endpoint                                                                                                                                                                                                     
![Public property]                 | [TokenEndpointAuthSigningAlgValuesSupported][46] | Array containing the JWS signing algorithms (alg values) supported by the Token Endpoint for the signature on the JWT used to authenticate the client at the Token Endpoint for the private_key_jwt and client_secret_jwt authentication methods                                        
![Public property]                 | [UiLocalesSupported][47]                         | Array containing the languages and scripts supported for the user interface, represented as an array of BCP47 [RFC5646] language tag values                                                                                                                                             
![Public property]                 | [UserInfoEncryptionAlgValuesSupported][48]       | Array containing a list of the JWE encryption algorithms (alg values) [JWA] supported by the issuer for the UserInfo Endpoint to encode the claims in a JWT                                                                                                                             
![Public property]                 | [UserInfoEncryptionEncValuesSupported][49]       | Array containing a list of the JWE encryption algorithms (enc values) [JWE] supported by the issuer for the UserInfo Endpoint to encode the claims in a JWT                                                                                                                             
![Public property]                 | [UserInfoEndpoint][50]                           | UserInfo endpoint to use if different from url returned by discovery                                                                                                                                                                                                                    
![Public property]                 | [UserInfoSigningAlgValuesSupported][51]          | Array containing the JWS signing algorithms [JWA] supported by the issuer for the UserInfo Endpoint to encode the claims in a JWT                                                                                                                                                       
![Public property]                 | [Version][52]                                    | The version of provider metadata                                                                                                                                                                                                                                                        


Methods
-------

                 | Name              | Description                                                                                                        
---------------- | ----------------- | ------------------------------------------------------------------------------------------------------------------ 
![Public method] | [MarkExpired][53] | Mark the object as expired, this method should only cause HasExpired to move from false to true, not true to false 


See Also
--------

#### Reference
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: _ctor_1.md
[5]: ACRValuesSupported.md
[6]: AuthorizationEndpoint.md
[7]: Cached.md
[8]: CheckSessionIframe.md
[9]: ClaimsLocalesSupported.md
[10]: ClaimsParameterSupported.md
[11]: ClaimsSupported.md
[12]: ClaimTypesSupported.md
[13]: Default.md
[14]: DisplayValuesSupported.md
[15]: EndSessionEndpoint.md
[16]: GrantTypesSupported.md
[17]: HasExpired.md
[18]: IdTokenEncryptionAlgValuesSupported.md
[19]: IdTokenEncryptionEncValuesSupported.md
[20]: IdTokenSigningAlgValuesSupported.md
[21]: Issuer.md
[22]: JwksUri.md
[23]: LoginHintMethodsSupported.md
[24]: MobileConnectVersionSupported.md
[25]: OperatorPolicyUri.md
[26]: OperatorTermsOfServiceUri.md
[27]: PremiumInfoEndpoint.md
[28]: RefreshEndpoint.md
[29]: RegistrationEndpoint.md
[30]: RequestObjectEncryptionAlgValuesSupported.md
[31]: RequestObjectEncryptionEncValuesSupported.md
[32]: RequestObjectSigningAlgValuesSupported.md
[33]: RequestParameterSupported.md
[34]: RequestUriParameterSupported.md
[35]: RequireRequestUriRegistration.md
[36]: ResponseModesSupported.md
[37]: ResponseTypesSupported.md
[38]: RevokeEndpoint.md
[39]: ScopesSupported.md
[40]: ../DiscoveryResponse/IsMobileConnectServiceSupported.md
[41]: ServiceDocumentation.md
[42]: SubjectTypesSupported.md
[43]: TimeCachedUtc.md
[44]: TokenEndpoint.md
[45]: TokenEndpointAuthMethodsSupported.md
[46]: TokenEndpointAuthSigningAlgValuesSupported.md
[47]: UiLocalesSupported.md
[48]: UserInfoEncryptionAlgValuesSupported.md
[49]: UserInfoEncryptionEncValuesSupported.md
[50]: UserInfoEndpoint.md
[51]: UserInfoSigningAlgValuesSupported.md
[52]: Version.md
[53]: MarkExpired.md
[54]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Static member]: ../../_icons/static.gif "Static member"