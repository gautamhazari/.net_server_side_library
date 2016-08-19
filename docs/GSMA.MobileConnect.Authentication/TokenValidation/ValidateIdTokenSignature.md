TokenValidation.ValidateIdTokenSignature Method
===============================================
Validates an id token signature by signing the id token payload and comparing the result with the signature

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static TokenValidationResult ValidateIdTokenSignature(
	string idToken,
	JWKeyset keyset
)
```

#### Parameters

##### *idToken*
Type: [System.String][2]  
IDToken to validate

##### *keyset*
Type: [GSMA.MobileConnect.Authentication.JWKeyset][3]  
 Keyset retrieved from the jwks url, used to validate the token signature. If null the token will not be validated and [JWKSError][4] will be returned

#### Return Value
Type: [TokenValidationResult][4]  
TokenValidationResult that specifies if the token signature is valid, or if not why it is not valid

See Also
--------

#### Reference
[TokenValidation Class][5]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../JWKeyset/README.md
[4]: ../TokenValidationResult/README.md
[5]: README.md
[6]: ../../_icons/Help.png