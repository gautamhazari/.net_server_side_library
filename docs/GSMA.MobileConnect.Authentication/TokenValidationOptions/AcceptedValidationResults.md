TokenValidationOptions.AcceptedValidationResults Property
=========================================================
Bit flag specifying which validation results should be accepted as "OK", if any results not specified are returned from validation an error status to be returned when requesting a token. By default only tokens that pass all validation steps will be accepted, allowing others to be accepted is at the SDK users own risk and is not advised.

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public TokenValidationResult AcceptedValidationResults { get; set; }
```

#### Property Value
Type: [TokenValidationResult][2]

See Also
--------

#### Reference
[TokenValidationOptions Class][3]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: ../TokenValidationResult/README.md
[3]: README.md
[4]: ../../_icons/Help.png