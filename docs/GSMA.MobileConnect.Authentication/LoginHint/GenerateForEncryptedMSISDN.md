LoginHint.GenerateForEncryptedMSISDN Method
===========================================
Generates login hint for Encrypted MSISDN (SubscriberId) value

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static string GenerateForEncryptedMSISDN(
	string encryptedMSISDN
)
```

#### Parameters

##### *encryptedMSISDN*
Type: [System.String][2]  
Encrypted MSISDN (SubscriberId) value

#### Return Value
Type: [String][2]  
Correctly formatted login hint parameter for Encrypted MSISDN (SubscriberId)

Exceptions
----------

Exception                                  | Condition                        
------------------------------------------ | -------------------------------- 
[MobileConnectInvalidArgumentException][3] | encryptedMSISDN is null or empty 


See Also
--------

#### Reference
[LoginHint Class][4]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../../GSMA.MobileConnect.Exceptions/MobileConnectInvalidArgumentException/README.md
[4]: README.md
[5]: ../../_icons/Help.png