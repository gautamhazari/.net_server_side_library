JWKey.Verify Method
===================
Verify that the input when signed with this key and the requested algorithm matches the expected signature

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public bool Verify(
	string input,
	string expected,
	string alg
)
```

#### Parameters

##### *input*
Type: [System.String][2]  
JWT Header+Payload to sign and verify

##### *expected*
Type: [System.String][2]  
Expected signature

##### *alg*
Type: [System.String][2]  
Algorithm requested in the JWT header, if the algorithm is not a valid algorithm for the key type then an exception will be thrown

#### Return Value
Type: [Boolean][3]  
True if token is verified

Exceptions
----------

Exception                                 | Condition                                                                       
----------------------------------------- | ------------------------------------------------------------------------------- 
[MobileConnectInvalidJWKException][4]     | Thrown if the available properties do not match the key type                    
[MobileConnectUnsupportedJWKException][5] | Thrown if the requested algorithm is unsupported or does not match the key type 


See Also
--------

#### Reference
[JWKey Class][6]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: ../../GSMA.MobileConnect.Exceptions/MobileConnectInvalidJWKException/README.md
[5]: ../../GSMA.MobileConnect.Exceptions/MobileConnectUnsupportedJWKException/README.md
[6]: README.md
[7]: ../../_icons/Help.png