LoginHint.GenerateFor Method
============================
Generates a login hint for the specified prefix with the specified value. This method will not check that the prefix is recognised or supported, it is assumed that it is supported.

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static string GenerateFor(
	string prefix,
	string value
)
```

#### Parameters

##### *prefix*
Type: [System.String][2]  
Prefix to use

##### *value*
Type: [System.String][2]  
Value to use

#### Return Value
Type: [String][2]  
Correctly formatted login hint for prefix and value

Exceptions
----------

Exception                                  | Condition              
------------------------------------------ | ---------------------- 
[MobileConnectInvalidArgumentException][3] | value is null or empty 


See Also
--------

#### Reference
[LoginHint Class][4]  
[GSMA.MobileConnect.Authentication Namespace][1]  
[GSMA.MobileConnect.Constants.LoginHintPrefixes][5]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../../GSMA.MobileConnect.Exceptions/MobileConnectInvalidArgumentException/README.md
[4]: README.md
[5]: ../../GSMA.MobileConnect.Constants/LoginHintPrefixes/README.md
[6]: ../../_icons/Help.png