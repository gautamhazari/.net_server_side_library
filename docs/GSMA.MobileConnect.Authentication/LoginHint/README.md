LoginHint Class
===============
Utility methods for working with login hints for the auth login hint parameter


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Authentication.LoginHint**  

**Namespace:** [GSMA.MobileConnect.Authentication][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static class LoginHint
```

The **LoginHint** type exposes the following members.


Methods
-------

                                 | Name                               | Description                                                                                                                                                                          
-------------------------------- | ---------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public method]![Static member] | [GenerateFor][3]                   | Generates a login hint for the specified prefix with the specified value. This method will not check that the prefix is recognised or supported, it is assumed that it is supported. 
![Public method]![Static member] | [GenerateForEncryptedMSISDN][4]    | Generates login hint for Encrypted MSISDN (SubscriberId) value                                                                                                                       
![Public method]![Static member] | [GenerateForMSISDN][5]             | Generates login hint for MSISDN value                                                                                                                                                
![Public method]![Static member] | [GenerateForPCR][6]                | Generates login hint for PCR (Pseudonymous Customer Reference) value                                                                                                                 
![Public method]![Static member] | [IsSupportedFor][7]                | Is login hint with specified prefix supported by the target provider                                                                                                                 
![Public method]![Static member] | [IsSupportedForEncryptedMSISDN][8] | Is login hint with Encrypted MSISDN (SubscriberId) supported by the target provider                                                                                                  
![Public method]![Static member] | [IsSupportedForMSISDN][9]          | Is login hint with MSISDN supported by the target provider                                                                                                                           
![Public method]![Static member] | [IsSupportedForPCR][10]            | Is login hint with PCR (Pseudonymous Customer Reference) supported by the target provider                                                                                            


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: GenerateFor.md
[4]: GenerateForEncryptedMSISDN.md
[5]: GenerateForMSISDN.md
[6]: GenerateForPCR.md
[7]: IsSupportedFor.md
[8]: IsSupportedForEncryptedMSISDN.md
[9]: IsSupportedForMSISDN.md
[10]: IsSupportedForPCR.md
[11]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"