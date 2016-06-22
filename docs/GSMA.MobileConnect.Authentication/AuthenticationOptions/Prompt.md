AuthenticationOptions.Prompt Property
=====================================
Space delimited, case-sensitive ASCII string values to specify to the Authorization Server whether to prompt or not for reauthentication and consent. See remarks for more information.

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public string Prompt { get; set; }
```

#### Property Value
Type: [String][2]

Remarks
-------
 The values can be: 

- "none": MUST NOT display any UI for reauthentication or consent to the user. If the user is not authenticated already, or authentication or consent is needed to process the Authorization Request, a login_required error is returned. This can be used as a mechanism to check existing authentication or consent.

- "login": SHOULD prompt the user for reauthentication or consent. In case it cannot be done, an error MUST be returned.

- "consent": SHOULD display a UI to get consent from the user.

- "select_account": In the situations, where the user has multiple accounts with the IDP/Authorization Server, this SHOULD prompt the user to select the account.If it cannot be done, an error MUST be returned.


See Also
--------

#### Reference
[AuthenticationOptions Class][3]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png