IdentityResponse.ResponseDataAs&lt;T> Method
============================================
Converts response JSON to custom provided identity class

**Namespace:** [GSMA.MobileConnect.Identity][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public T ResponseDataAs<T>()
where T : class

```

#### Type Parameters

##### *T*
User info class with properties linking to keys in userinfo response json

#### Return Value
Type: **T**  
JSON Deserialized to instance of Type T

Remarks
-------
The last used object will be cached for subsequent method calls with the same type

See Also
--------

#### Reference
[IdentityResponse Class][2]  
[GSMA.MobileConnect.Identity Namespace][1]  
[GSMA.MobileConnect.Identity.UserInfoData][3]  
[GSMA.MobileConnect.Identity.IdentityData][4]  

[1]: ../README.md
[2]: README.md
[3]: ../UserInfoData/README.md
[4]: ../IdentityData/README.md
[5]: ../../_icons/Help.png