MobileConnectRequestOptions.MaxAge Property
===========================================
Specifies the maximum elapsed time in seconds since last authentication of the user. If the elapsed time is greater than this value, a reauthentication MUST be done. When this parameter is used in the request, the ID Token MUST contain the auth_time claim value.

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public int MaxAge { get; set; }
```

#### Property Value
Type: [Int32][2]

See Also
--------

#### Reference
[MobileConnectRequestOptions Class][3]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/td2s409d
[3]: README.md
[4]: ../../_icons/Help.png