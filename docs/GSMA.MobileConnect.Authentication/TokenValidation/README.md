TokenValidation Class
=====================
Utility methods for token validation


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Authentication.TokenValidation**  

**Namespace:** [GSMA.MobileConnect.Authentication][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static class TokenValidation
```

The **TokenValidation** type exposes the following members.


Methods
-------

                                 | Name                          | Description                                                                                                                                       
-------------------------------- | ----------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]![Static member] | [ValidateAccessToken][3]      | Validates the access token contained in the token response data                                                                                   
![Public method]![Static member] | [ValidateIdToken][4]          | Validates an id token against the mobile connect validation requirements, this includes validation of some claims and validation of the signature 
![Public method]![Static member] | [ValidateIdTokenClaims][5]    | Validates an id tokens claims using validation requirements from the mobile connect and open id connect specification                             
![Public method]![Static member] | [ValidateIdTokenSignature][6] | Validates an id token signature by signing the id token payload and comparing the result with the signature                                       


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: ValidateAccessToken.md
[4]: ValidateIdToken.md
[5]: ValidateIdTokenClaims.md
[6]: ValidateIdTokenSignature.md
[7]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"