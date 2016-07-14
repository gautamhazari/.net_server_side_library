UserInfoData.PhoneNumberVerified Property
=========================================
True if the End-User's phone number has been verified; otherwise false. When this Claim Value is true, this means that the OP took affirmative steps to ensure that this phone number was controlled by the End-User at the time the verification was performed. The means by which a phone number is verified is context-specific, and dependent upon the trust framework or contractual agreements within which the parties are operating. When true, the phone_number Claim MUST be in E.164 format and any extensions MUST be represented in RFC 3966 format.

**Namespace:** [GSMA.MobileConnect.Identity][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public bool PhoneNumberVerified { get; set; }
```

#### Property Value
Type: [Boolean][2]

See Also
--------

#### Reference
[UserInfoData Class][3]  
[GSMA.MobileConnect.Identity Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/a28wyd50
[3]: README.md
[4]: ../../_icons/Help.png