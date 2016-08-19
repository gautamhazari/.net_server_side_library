JWKey Class
===========
Represents a cryptographic key that belongs to a JWKeyset


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Authentication.JWKey**  

**Namespace:** [GSMA.MobileConnect.Authentication][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class JWKey
```

The **JWKey** type exposes the following members.


Constructors
------------

                 | Name       | Description                                       
---------------- | ---------- | ------------------------------------------------- 
![Public method] | [JWKey][3] | Initializes a new instance of the **JWKey** class 


Properties
----------

                   | Name           | Description                                                                                                                                                                                                                 
------------------ | -------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [Algorithm][4] | The "alg" (algorithm) parameter identifies the algorithm intended for use with the key.                                                                                                                                     
![Public property] | [ECCCurve][5]  | The "crv" (curve) parameter identifies the cryptographic curve used with the key                                                                                                                                            
![Public property] | [ECCX][6]      | The "x" (x coordinate) parameter contains the x coordinate for the Elliptic Curve point                                                                                                                                     
![Public property] | [ECCY][7]      | The "y" (y coordinate) parameter contains the y coordinate for the Elliptic Curve point.                                                                                                                                    
![Public property] | [Key][8]       | The "k" (key value) parameter contains the value of the symmetric (or other single-valued) key.It is represented as the base64url encoding of the octet sequence containing the key value.                                  
![Public property] | [KeyID][9]     | The "kid" (key ID) parameter is used to match a specific key. This is used, for instance, to choose among a set of keys within a JWK Set during key rollover.                                                               
![Public property] | [KeyOps][10]   | The "key_ops" (key operations) parameter identifies the operation(s) for which the key is intended to be used.The "key_ops" parameter is intended for use cases in which public, private, or symmetric keys may be present. 
![Public property] | [KeyType][11]  | The "kty" (key type) parameter identifies the cryptographic algorithm family used with the key, such as "RSA" or "EC"                                                                                                       
![Public property] | [RSAE][12]     | The "e" (exponent) parameter contains the exponent value for the RSA public key.It is represented as a Base64urlUInt-encoded value.                                                                                         
![Public property] | [RSAN][13]     | The "n" (modulus) parameter contains the modulus value for the RSA public key.It is represented as a Base64urlUInt-encoded value.                                                                                           
![Public property] | [Use][14]      | The "use" (public key use) parameter identifies the intended use of the public key.The "use" parameter is employed to indicate whether a public key is used for encrypting data or verifying the signature on data.         


Methods
-------

                 | Name         | Description                                                                                                
---------------- | ------------ | ---------------------------------------------------------------------------------------------------------- 
![Public method] | [Verify][15] | Verify that the input when signed with this key and the requested algorithm matches the expected signature 


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: Algorithm.md
[5]: ECCCurve.md
[6]: ECCX.md
[7]: ECCY.md
[8]: Key.md
[9]: KeyID.md
[10]: KeyOps.md
[11]: KeyType.md
[12]: RSAE.md
[13]: RSAN.md
[14]: Use.md
[15]: Verify.md
[16]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"