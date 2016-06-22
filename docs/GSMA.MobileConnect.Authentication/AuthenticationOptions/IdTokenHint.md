AuthenticationOptions.IdTokenHint Property
==========================================
Generally used in conjunction with prompt=none to pass the previously issued ID Token as a hint for the current or past authentication session. See remarks for more information.

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public string IdTokenHint { get; set; }
```

#### Property Value
Type: [String][2]

Remarks
-------
 If the ID Token is still valid and the user is logged in then the server returns a positive response, otherwise SHOULD return a login_error response.For the ID Token, the server need not be listed as audience, when included in the id_token_hint. 

See Also
--------

#### Reference
[AuthenticationOptions Class][3]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png