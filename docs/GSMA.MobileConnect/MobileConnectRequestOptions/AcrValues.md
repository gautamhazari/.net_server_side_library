MobileConnectRequestOptions.AcrValues Property
==============================================
Authentication Context class Reference. Space separated string that specifies the Authentication Context Reference to be used during authentication processing. Mobile Connect Authentication and Authorization support the values "2" and "3", 2 specifies authenticate/authorize and 3 specifies autthenticate/authorize plus. If required the server may override the ACR value passed to force a higher level of assurance or if the required level of assurance is temporarily unavailable, if this happens the ID Token will contain the actual acr value used

**Namespace:** [GSMA.MobileConnect][1]  
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
[MobileConnectRequestOptions Class][3]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png