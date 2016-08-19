ConcurrentCache Class
=====================
Concrete implementation of [ICache][1] using a ConcurrentDictionary as the internal caching mechanism


Inheritance Hierarchy
---------------------
[System.Object][2]  
  [GSMA.MobileConnect.Cache.BaseCache][3]  
    **GSMA.MobileConnect.Cache.ConcurrentCache**  

**Namespace:** [GSMA.MobileConnect.Cache][4]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class ConcurrentCache : BaseCache
```

The **ConcurrentCache** type exposes the following members.


Constructors
------------

                 | Name                 | Description                                                 
---------------- | -------------------- | ----------------------------------------------------------- 
![Public method] | [ConcurrentCache][5] | Initializes a new instance of the **ConcurrentCache** class 


Properties
----------

                   | Name         | Description                                                        
------------------ | ------------ | ------------------------------------------------------------------ 
![Public property] | [IsEmpty][6] | Returns true if cache is empty (Overrides [BaseCache.IsEmpty][7].) 


Methods
-------

                    | Name                                        | Description                                                                                                                                              
------------------- | ------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]    | [Add(String, String, DiscoveryResponse)][8] | Add a value to the cache with the specified mcc and mnc (Inherited from [BaseCache][3].)                                                                 
![Public method]    | [Add&lt;T>(String, T)][9]                   | Add a value with the specified key (Inherited from [BaseCache][3].)                                                                                      
![Protected method] | [CheckIsExpired][10]                        | Checks if a object has been cached past the defined caching time or if internally the object has been marked as expired (Inherited from [BaseCache][3].) 
![Public method]    | [Clear][11]                                 | Remove all key value pairs from the cache (Overrides [BaseCache.Clear()][12].)                                                                           
![Protected method] | [ConcatKey][13]                             | Concatenates MCC and MNC into a single key (Inherited from [BaseCache][3].)                                                                              
![Public method]    | [Get(String, String)][14]                   | Return a cached value based on the mcc and mnc (Inherited from [BaseCache][3].)                                                                          
![Public method]    | [Get&lt;T>(String, Boolean)][15]            | Return a cached value based on the key (Inherited from [BaseCache][3].)                                                                                  
![Protected method] | [InternalAdd&lt;T>][16]                     | Add value to internal cache with given key (Overrides [BaseCache.InternalAdd&lt;T>(String, T)][17].)                                                     
![Protected method] | [InternalGet&lt;T>][18]                     | Get value from internal cache with given key (Overrides [BaseCache.InternalGet&lt;T>(String)][19].)                                                      
![Public method]    | [Remove(String)][20]                        | Remove an entry from the cache that matches the key (Overrides [BaseCache.Remove(String)][21].)                                                          
![Public method]    | [Remove(String, String)][22]                | Remove an entry from the cache that matches the mcc and mnc (Overrides [BaseCache.Remove(String, String)][23].)                                          
![Public method]    | [SetCacheExpiryTime&lt;T>][24]              | Set length of time before cached values of the specified type are marked as expired. (Inherited from [BaseCache][3].)                                    


Fields
------

                   | Name                     | Description                                                                                                    
------------------ | ------------------------ | -------------------------------------------------------------------------------------------------------------- 
![Protected field] | [_cacheExpiryLimits][25] | Values configured for the minimum and maximum configurable cache expiry times (Inherited from [BaseCache][3].) 
![Protected field] | [_cacheExpiryTimes][26]  | Values configured for cache expiry times of types (Inherited from [BaseCache][3].)                             


See Also
--------

#### Reference
[GSMA.MobileConnect.Cache Namespace][4]  

[1]: ../ICache/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../BaseCache/README.md
[4]: ../README.md
[5]: _ctor.md
[6]: IsEmpty.md
[7]: ../BaseCache/IsEmpty.md
[8]: ../BaseCache/Add.md
[9]: ../BaseCache/Add__1.md
[10]: ../BaseCache/CheckIsExpired.md
[11]: Clear.md
[12]: ../BaseCache/Clear.md
[13]: ../BaseCache/ConcatKey.md
[14]: ../BaseCache/Get.md
[15]: ../BaseCache/Get__1.md
[16]: InternalAdd__1.md
[17]: ../BaseCache/InternalAdd__1.md
[18]: InternalGet__1.md
[19]: ../BaseCache/InternalGet__1.md
[20]: Remove.md
[21]: ../BaseCache/Remove.md
[22]: Remove_1.md
[23]: ../BaseCache/Remove_1.md
[24]: ../BaseCache/SetCacheExpiryTime__1.md
[25]: ../BaseCache/_cacheExpiryLimits.md
[26]: ../BaseCache/_cacheExpiryTimes.md
[27]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Protected method]: ../../_icons/protmethod.gif "Protected method"
[Protected field]: ../../_icons/protfield.gif "Protected field"