OperatorUrls Class
==================
Object to hold the operator specific urls returned from a successful discovery process call


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Discovery.OperatorUrls**  

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class OperatorUrls
```

The **OperatorUrls** type exposes the following members.


Constructors
------------

                 | Name              | Description                                              
---------------- | ----------------- | -------------------------------------------------------- 
![Public method] | [OperatorUrls][3] | Initializes a new instance of the **OperatorUrls** class 


Properties
----------

                   | Name                     | Description                    
------------------ | ------------------------ | ------------------------------ 
![Public property] | [AuthorizationUrl][4]    | Url for authorization call     
![Public property] | [JWKSUrl][5]             | Url for JWKS info              
![Public property] | [PremiumInfoUrl][6]      | Url for identity services call 
![Public property] | [ProviderMetadataUrl][7] | Url for Provider Metadata      
![Public property] | [RequestTokenUrl][8]     | Url for token request call     
![Public property] | [UserInfoUrl][9]         | Url for user info call         


Methods
-------

                                 | Name        | Description                                                    
-------------------------------- | ----------- | -------------------------------------------------------------- 
![Public method]![Static member] | [Parse][10] | Parses the operator urls from the parsed DiscoveryResponseData 


See Also
--------

#### Reference
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: AuthorizationUrl.md
[5]: JWKSUrl.md
[6]: PremiumInfoUrl.md
[7]: ProviderMetadataUrl.md
[8]: RequestTokenUrl.md
[9]: UserInfoUrl.md
[10]: Parse.md
[11]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Static member]: ../../_icons/static.gif "Static member"