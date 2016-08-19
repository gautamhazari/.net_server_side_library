IJWKeysetService Interface
==========================
Service for retrieving, caching and managing JWKS keysets for JWT validation

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public interface IJWKeysetService
```

The **IJWKeysetService** type exposes the following members.


Methods
-------

                 | Name                   | Description                                                                         
---------------- | ---------------------- | ----------------------------------------------------------------------------------- 
![Public method] | [RetrieveJWKS][2]      | Synchronous wrapper for [RetrieveJWKSAsync(String)][3]                              
![Public method] | [RetrieveJWKSAsync][3] | Retrieve the JSON Web Keyset from the specified url utilising caching if configured 


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: RetrieveJWKS.md
[3]: RetrieveJWKSAsync.md
[4]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"