ConcurrentDiscoveryCache Class
==============================
Concrete implementation of [IDiscoveryCache][1] using a ConcurrentDictionary as the internal caching mechanism


Inheritance Hierarchy
---------------------
[System.Object][2]  
  [GSMA.MobileConnect.Cache.BaseDiscoveryCache][3]  
    **GSMA.MobileConnect.Cache.ConcurrentDiscoveryCache**  

**Namespace:** [GSMA.MobileConnect.Cache][4]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class ConcurrentDiscoveryCache : BaseDiscoveryCache
```

The **ConcurrentDiscoveryCache** type exposes the following members.


Constructors
------------

                 | Name                          | Description                                                          
---------------- | ----------------------------- | -------------------------------------------------------------------- 
![Public method] | [ConcurrentDiscoveryCache][5] | Initializes a new instance of the **ConcurrentDiscoveryCache** class 


Properties
----------

                   | Name         | Description                                                                 
------------------ | ------------ | --------------------------------------------------------------------------- 
![Public property] | [IsEmpty][6] | Returns true if cache is empty (Overrides [BaseDiscoveryCache.IsEmpty][7].) 


Methods
-------

                    | Name                                        | Description                                                                                                                                                       
------------------- | ------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]    | [Add(String, String, DiscoveryResponse)][8] | Add a value to the cache with the specified mcc and mnc (Inherited from [BaseDiscoveryCache][3].)                                                                 
![Public method]    | [Add&lt;T>(String, T)][9]                   | Add a value with the specified key (Inherited from [BaseDiscoveryCache][3].)                                                                                      
![Protected method] | [CheckIsExpired][10]                        | Checks if a object has been cached past the defined caching time or if internally the object has been marked as expired (Inherited from [BaseDiscoveryCache][3].) 
![Public method]    | [Clear][11]                                 | Remove all key value pairs from the cache (Overrides [BaseDiscoveryCache.Clear()][12].)                                                                           
![Protected method] | [ConcatKey][13]                             | Concatenates MCC and MNC into a single key (Inherited from [BaseDiscoveryCache][3].)                                                                              
![Public method]    | [Get(String, String)][14]                   | Return a cached value based on the mcc and mnc (Inherited from [BaseDiscoveryCache][3].)                                                                          
![Public method]    | [Get&lt;T>(String, Boolean)][15]            | Return a cached value based on the key (Inherited from [BaseDiscoveryCache][3].)                                                                                  
![Protected method] | [InternalAdd&lt;T>][16]                     | Add value to internal cache with given key (Overrides [BaseDiscoveryCache.InternalAdd&lt;T>(String, T)][17].)                                                     
![Protected method] | [InternalGet&lt;T>][18]                     | Get value from internal cache with given key (Overrides [BaseDiscoveryCache.InternalGet&lt;T>(String)][19].)                                                      
![Public method]    | [Remove(String)][20]                        | Remove an entry from the cache that matches the key (Overrides [BaseDiscoveryCache.Remove(String)][21].)                                                          
![Public method]    | [Remove(String, String)][22]                | Remove an entry from the cache that matches the mcc and mnc (Overrides [BaseDiscoveryCache.Remove(String, String)][23].)                                          
![Public method]    | [SetCacheExpiryTime&lt;T>][24]              | Set length of time before cached values of the specified type are marked as expired. (Inherited from [BaseDiscoveryCache][3].)                                    


Fields
------

                   | Name                     | Description                                                                                                             
------------------ | ------------------------ | ----------------------------------------------------------------------------------------------------------------------- 
![Protected field] | [_cacheExpiryLimits][25] | Values configured for the minimum and maximum configurable cache expiry times (Inherited from [BaseDiscoveryCache][3].) 
![Protected field] | [_cacheExpiryTimes][26]  | Values configured for cache expiry times of types (Inherited from [BaseDiscoveryCache][3].)                             


See Also
--------

#### Reference
[GSMA.MobileConnect.Cache Namespace][4]  

[1]: ../IDiscoveryCache/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../BaseDiscoveryCache/README.md
[4]: ../README.md
[5]: _ctor.md
[6]: IsEmpty.md
[7]: ../BaseDiscoveryCache/IsEmpty.md
[8]: ../BaseDiscoveryCache/Add.md
[9]: ../BaseDiscoveryCache/Add__1.md
[10]: ../BaseDiscoveryCache/CheckIsExpired.md
[11]: Clear.md
[12]: ../BaseDiscoveryCache/Clear.md
[13]: ../BaseDiscoveryCache/ConcatKey.md
[14]: ../BaseDiscoveryCache/Get.md
[15]: ../BaseDiscoveryCache/Get__1.md
[16]: InternalAdd__1.md
[17]: ../BaseDiscoveryCache/InternalAdd__1.md
[18]: InternalGet__1.md
[19]: ../BaseDiscoveryCache/InternalGet__1.md
[20]: Remove.md
[21]: ../BaseDiscoveryCache/Remove.md
[22]: Remove_1.md
[23]: ../BaseDiscoveryCache/Remove_1.md
[24]: ../BaseDiscoveryCache/SetCacheExpiryTime__1.md
[25]: ../BaseDiscoveryCache/_cacheExpiryLimits.md
[26]: ../BaseDiscoveryCache/_cacheExpiryTimes.md
[27]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Protected method]: ../../_icons/protmethod.gif "Protected method"
[Protected field]: ../../_icons/protfield.gif "Protected field"