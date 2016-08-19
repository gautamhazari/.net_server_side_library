TokenValidation.ValidateIdTokenClaims Method
============================================
Validates an id tokens claims using validation requirements from the mobile connect and open id connect specification

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static TokenValidationResult ValidateIdTokenClaims(
	string idToken,
	string clientId,
	string issuer,
	string nonce,
	Nullable<int> maxAge
)
```

#### Parameters

##### *idToken*
Type: [System.String][2]  
IDToken to validate

##### *clientId*
Type: [System.String][2]  
ClientId that is validated against the aud and azp claims

##### *issuer*
Type: [System.String][2]  
Issuer that is validated against the iss claim

##### *nonce*
Type: [System.String][2]  
Nonce that is validated against the nonce claim

##### *maxAge*
Type: [System.Nullable][3]&lt;[Int32][4]>  
MaxAge that is used to validate the auth_time claim (if supplied)

#### Return Value
Type: [TokenValidationResult][5]  
TokenValidationResult that specifies if the token claims are valid, or if not why they are not valid

See Also
--------

#### Reference
[TokenValidation Class][6]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/b3h38hb0
[4]: http://msdn.microsoft.com/en-us/library/td2s409d
[5]: ../TokenValidationResult/README.md
[6]: README.md
[7]: ../../_icons/Help.png