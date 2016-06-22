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

                 | Name                  | Description                                                  
---------------- | --------------------- | ------------------------------------------------------------ 
![Public method] | [ProviderMetadata][3] | Initializes a new instance of the **ProviderMetadata** class 


Properties
----------

                   | Name                                             | Description                                                                 
------------------ | ------------------------------------------------ | --------------------------------------------------------------------------- 
![Public property] | [ACRValuesSupported][4]                          |                                                                             
![Public property] | [AuthorizationEndpoint][5]                       |                                                                             
![Public property] | [Cached][6]                                      | Returns true if object came from cache                                      
![Public property] | [CheckSessionIframe][7]                          |                                                                             
![Public property] | [ClaimsLocalesSupported][8]                      |                                                                             
![Public property] | [ClaimsParameterSupported][9]                    |                                                                             
![Public property] | [ClaimsSupported][10]                            |                                                                             
![Public property] | [ClaimTypesSupported][11]                        |                                                                             
![Public property] | [DisplayValuesSupported][12]                     |                                                                             
![Public property] | [EndSessionEndpoint][13]                         |                                                                             
![Public property] | [GrantTypesSupported][14]                        |                                                                             
![Public property] | [HasExpired][15]                                 | Returns true if the object has expired and should be removed from the cache 
![Public property] | [IdTokenEncryptionAlgValuesSupported][16]        |                                                                             
![Public property] | [IdTokenEncryptionEncValuesSupported][17]        |                                                                             
![Public property] | [IdTokenSigningAlgValuesSupported][18]           |                                                                             
![Public property] | [Issuer][19]                                     |                                                                             
![Public property] | [JwksUri][20]                                    |                                                                             
![Public property] | [LoginHintMethodsSupported][21]                  |                                                                             
![Public property] | [MobileConnectVersionSupported][22]              |                                                                             
![Public property] | [OperatorPolicyUri][23]                          |                                                                             
![Public property] | [OperatorTermsOfServiceUri][24]                  |                                                                             
![Public property] | [RequestObjectEncryptionAlgValuesSupported][25]  |                                                                             
![Public property] | [RequestObjectEncryptionEncValuesSupported][26]  |                                                                             
![Public property] | [RequestObjectSigningAlgValuesSupported][27]     |                                                                             
![Public property] | [RequestParameterSupported][28]                  |                                                                             
![Public property] | [RequestUriParameterSupported][29]               |                                                                             
![Public property] | [RequireRequestUriRegistration][30]              |                                                                             
![Public property] | [ResponseTypesSupported][31]                     |                                                                             
![Public property] | [ScopesSupported][32]                            |                                                                             
![Public property] | [ServiceDocumentation][33]                       |                                                                             
![Public property] | [SubjectTypesSupported][34]                      |                                                                             
![Public property] | [TimeCachedUtc][35]                              | Time when the object was initially cached                                   
![Public property] | [TokenEndpoint][36]                              |                                                                             
![Public property] | [TokenEndpointAuthMethodsSupported][37]          |                                                                             
![Public property] | [TokenEndpointAuthSigningAlgValuesSupported][38] |                                                                             
![Public property] | [UiLocalesSupported][39]                         |                                                                             
![Public property] | [UserInfoEncryptionAlgValuesSupported][40]       |                                                                             
![Public property] | [UserInfoEncryptionEncValuesSupported][41]       |                                                                             
![Public property] | [UserInfoEndpoint][42]                           |                                                                             
![Public property] | [UserInfoSigningAlgValuesSupported][43]          |                                                                             
![Public property] | [Version][44]                                    |                                                                             


Methods
-------

                 | Name              | Description                                                                                                        
---------------- | ----------------- | ------------------------------------------------------------------------------------------------------------------ 
![Public method] | [MarkExpired][45] | Mark the object as expired, this method should only cause HasExpired to move from false to true, not true to false 


See Also
--------

#### Reference
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: ACRValuesSupported.md
[5]: AuthorizationEndpoint.md
[6]: Cached.md
[7]: CheckSessionIframe.md
[8]: ClaimsLocalesSupported.md
[9]: ClaimsParameterSupported.md
[10]: ClaimsSupported.md
[11]: ClaimTypesSupported.md
[12]: DisplayValuesSupported.md
[13]: EndSessionEndpoint.md
[14]: GrantTypesSupported.md
[15]: HasExpired.md
[16]: IdTokenEncryptionAlgValuesSupported.md
[17]: IdTokenEncryptionEncValuesSupported.md
[18]: IdTokenSigningAlgValuesSupported.md
[19]: Issuer.md
[20]: JwksUri.md
[21]: LoginHintMethodsSupported.md
[22]: MobileConnectVersionSupported.md
[23]: OperatorPolicyUri.md
[24]: OperatorTermsOfServiceUri.md
[25]: RequestObjectEncryptionAlgValuesSupported.md
[26]: RequestObjectEncryptionEncValuesSupported.md
[27]: RequestObjectSigningAlgValuesSupported.md
[28]: RequestParameterSupported.md
[29]: RequestUriParameterSupported.md
[30]: RequireRequestUriRegistration.md
[31]: ResponseTypesSupported.md
[32]: ScopesSupported.md
[33]: ServiceDocumentation.md
[34]: SubjectTypesSupported.md
[35]: TimeCachedUtc.md
[36]: TokenEndpoint.md
[37]: TokenEndpointAuthMethodsSupported.md
[38]: TokenEndpointAuthSigningAlgValuesSupported.md
[39]: UiLocalesSupported.md
[40]: UserInfoEncryptionAlgValuesSupported.md
[41]: UserInfoEncryptionEncValuesSupported.md
[42]: UserInfoEndpoint.md
[43]: UserInfoSigningAlgValuesSupported.md
[44]: Version.md
[45]: MarkExpired.md
[46]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"