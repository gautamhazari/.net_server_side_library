TokenValidation.ValidateAccessToken Method
==========================================
Validates the access token contained in the token response data

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static TokenValidationResult ValidateAccessToken(
	RequestTokenResponseData tokenResponse
)
```

#### Parameters

##### *tokenResponse*
Type: [GSMA.MobileConnect.Authentication.RequestTokenResponseData][2]  
Response data containing the access token and accompanying parameters

#### Return Value
Type: [TokenValidationResult][3]  
TokenValidationResult that specifies if the access token is valid, or if not why it is not valid

See Also
--------

#### Reference
[TokenValidation Class][4]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: ../RequestTokenResponseData/README.md
[3]: ../TokenValidationResult/README.md
[4]: README.md
[5]: ../../_icons/Help.png