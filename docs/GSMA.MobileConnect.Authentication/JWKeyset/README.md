JWKeyset Class
==============
JWKS retrieved from the JWKS endpoint


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Authentication.JWKeyset**  

**Namespace:** [GSMA.MobileConnect.Authentication][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class JWKeyset : ICacheable
```

The **JWKeyset** type exposes the following members.


Constructors
------------

                 | Name          | Description                                          
---------------- | ------------- | ---------------------------------------------------- 
![Public method] | [JWKeyset][3] | Initializes a new instance of the **JWKeyset** class 


Properties
----------

                   | Name               | Description                                                                 
------------------ | ------------------ | --------------------------------------------------------------------------- 
![Public property] | [Cached][4]        | Returns true if object came from cache                                      
![Public property] | [HasExpired][5]    | Returns true if the object has expired and should be removed from the cache 
![Public property] | [Keys][6]          | All available keys                                                          
![Public property] | [TimeCachedUtc][7] | Time when the object was initially cached                                   


Methods
-------

                 | Name             | Description                                                                                                        
---------------- | ---------------- | ------------------------------------------------------------------------------------------------------------------ 
![Public method] | [GetMatching][8] | Return all keys matching the predicate                                                                             
![Public method] | [MarkExpired][9] | Mark the object as expired, this method should only cause HasExpired to move from false to true, not true to false 


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: Cached.md
[5]: HasExpired.md
[6]: Keys.md
[7]: TimeCachedUtc.md
[8]: GetMatching.md
[9]: MarkExpired.md
[10]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"