AuthenticationOptions.AcrValues Property
========================================
Authentication Context class Reference. Space separated string that specifies the Authentication Context Reference to be used during authentication processing. The LOA required by the RP/Client for the use case can be used here. The values appear as order of preference. The acr satisfied during authentication is returned as acr claim value. The recommended values are the LOAs as specified in ISO/IEC 29115 Clause 6 – 1, 2, 3, 4 – representing the LOAs of LOW, MEDIUM, HIGH and VERY HIGH. The acr_values are indication of what authentication methods to used by the IDP. The authentication methods to be used are linked to the LOA value passed in the acr_values. The IDP configures the authentication method selection logic based on the acr_values.

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public string AcrValues { get; set; }
```

#### Property Value
Type: [String][2]

See Also
--------

#### Reference
[AuthenticationOptions Class][3]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png