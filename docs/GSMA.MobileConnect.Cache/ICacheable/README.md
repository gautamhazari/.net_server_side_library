ICacheable Interface
====================
Interface for cacheable objects

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public interface ICacheable
```

The **ICacheable** type exposes the following members.


Properties
----------

                   | Name               | Description                                                                 
------------------ | ------------------ | --------------------------------------------------------------------------- 
![Public property] | [Cached][2]        | Returns true if object came from cache                                      
![Public property] | [HasExpired][3]    | Returns true if the object has expired and should be removed from the cache 
![Public property] | [TimeCachedUtc][4] | Time when the object was initially cached                                   


Methods
-------

                 | Name             | Description                                                                                                        
---------------- | ---------------- | ------------------------------------------------------------------------------------------------------------------ 
![Public method] | [MarkExpired][5] | Mark the object as expired, this method should only cause HasExpired to move from false to true, not true to false 


See Also
--------

#### Reference
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: Cached.md
[3]: HasExpired.md
[4]: TimeCachedUtc.md
[5]: MarkExpired.md
[6]: ../../_icons/Help.png
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Public method]: ../../_icons/pubmethod.gif "Public method"