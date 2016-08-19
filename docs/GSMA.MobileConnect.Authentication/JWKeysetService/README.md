JWKeysetService Class
=====================
Concrete implementation [IJWKeysetService][1]


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Authentication.JWKeysetService**  

**Namespace:** [GSMA.MobileConnect.Authentication][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class JWKeysetService : IJWKeysetService
```

The **JWKeysetService** type exposes the following members.


Constructors
------------

                 | Name                 | Description                                                        
---------------- | -------------------- | ------------------------------------------------------------------ 
![Public method] | [JWKeysetService][4] | Creates an instance of the JWKeysetService with a configured cache 


Methods
-------

                 | Name                   | Description                                                                         
---------------- | ---------------------- | ----------------------------------------------------------------------------------- 
![Public method] | [RetrieveJWKS][5]      | Synchronous wrapper for [RetrieveJWKSAsync(String)][6]                              
![Public method] | [RetrieveJWKSAsync][7] | Retrieve the JSON Web Keyset from the specified url utilising caching if configured 


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][3]  

[1]: ../IJWKeysetService/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: RetrieveJWKS.md
[6]: ../IJWKeysetService/RetrieveJWKSAsync.md
[7]: RetrieveJWKSAsync.md
[8]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"