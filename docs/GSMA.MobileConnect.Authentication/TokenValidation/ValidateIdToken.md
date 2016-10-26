TokenValidation.ValidateIdToken Method
======================================
Validates an id token against the mobile connect validation requirements, this includes validation of some claims and validation of the signature

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static TokenValidationResult ValidateIdToken(
	string idToken,
	string clientId,
	string issuer,
	string nonce,
	Nullable<int> maxAge,
	JWKeyset keyset,
	string version
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

##### *keyset*
Type: [GSMA.MobileConnect.Authentication.JWKeyset][5]  
Keyset retrieved from the jwks url, used to validate the token signature

##### *version*
Type: [System.String][2]  
Version of MobileConnect services supported by current provider

#### Return Value
Type: [TokenValidationResult][6]  
TokenValidationResult that sepcfies if the token is valid, or if not why it is not valid

See Also
--------

#### Reference
[TokenValidation Class][7]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/b3h38hb0
[4]: http://msdn.microsoft.com/en-us/library/td2s409d
[5]: ../JWKeyset/README.md
[6]: ../TokenValidationResult/README.md
[7]: README.md
[8]: ../../_icons/Help.png