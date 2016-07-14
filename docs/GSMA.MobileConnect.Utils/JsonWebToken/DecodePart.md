JsonWebToken.DecodePart Method
==============================
Decodes the specified token part

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static string DecodePart(
	string token,
	JWTPart part
)
```

#### Parameters

##### *token*
Type: [System.String][2]  
JSON Web Token to decode the part content

##### *part*
Type: [GSMA.MobileConnect.Utils.JWTPart][3]  
Part to decode, if signature then the part will be returned directly and no decode will be completed

#### Return Value
Type: [String][2]  
JSON string decoded from part

See Also
--------

#### Reference
[JsonWebToken Class][4]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../JWTPart/README.md
[4]: README.md
[5]: ../../_icons/Help.png