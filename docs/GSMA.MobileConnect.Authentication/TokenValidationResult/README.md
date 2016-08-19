TokenValidationResult Enumeration
=================================
Enum for available token validation results

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
[FlagsAttribute]
public enum TokenValidationResult
```


Members
-------

Member name                   | Value | Description                                                                                         
----------------------------- | ----- | --------------------------------------------------------------------------------------------------- 
**None**                      | 0     | No validation has occured                                                                           
**InvalidSignature**          | 1     | Token when signed does not match signature                                                          
**Valid**                     | 2     | Token passed all validation steps                                                                   
**JWKSError**                 | 4     | Key was not retrieved from the jwks url or a jwks url was not present                               
**IncorrectAlgorithm**        | 8     | The alg claim in the id token header does not match the alg requested or the default alg of RS256   
**InvalidAudAndAzp**          | 16    | Neither the azp nor the aud claim in the id token match the client id used to make the auth request 
**InvalidIssuer**             | 32    | The iss claim in the id token does not match the expected issuer                                    
**IdTokenExpired**            | 64    | The IdToken has expired                                                                             
**NoMatchingKey**             | 128   | No key matching the requested key id was found                                                      
**KeyMisformed**              | 256   | Key does not contain the required information to validate against the requested algorithm           
**UnsupportedAlgorithm**      | 512   | Algorithm is unsupported for validation                                                             
**AccessTokenExpired**        | 1024  | The access token has expired                                                                        
**AccessTokenMissing**        | 2048  | The access token is null or empty in the token response                                             
**IdTokenMissing**            | 4096  | The id token is null or empty in the token response                                                 
**MaxAgePassed**              | 8192  | The id token is older than the max age specified in the auth stage                                  
**TokenIssueTimeLimitPassed** | 16384 | A longer time than the configured limit has passed since the token was issued                       
**InvalidNonce**              | 32768 | The nonce in the id token claims does not match the nonce specified in the auth stage               
**IncompleteTokenResponse**   | 65536 | The token response is null or missing required data                                                 


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: ../../_icons/Help.png