JsonWebToken.IsValidFormat Method
=================================
Check if token is in valid JWT format

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static bool IsValidFormat(
	string token
)
```

#### Parameters

##### *token*
Type: [System.String][2]  
Token to check

#### Return Value
Type: [Boolean][3]  
True if token contains 3 parts split by '.' the last part may be empty

See Also
--------

#### Reference
[JsonWebToken Class][4]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: README.md
[5]: ../../_icons/Help.png