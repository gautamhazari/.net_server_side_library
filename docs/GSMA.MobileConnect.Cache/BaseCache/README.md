BaseCache Class
===============
Base class for Discovery Caches that implements basic cache control mechanisms and type casting reducing the amount of implementation needed in each derived cache class


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Cache.BaseCache**  
    [GSMA.MobileConnect.Cache.ConcurrentCache][2]  

**Namespace:** [GSMA.MobileConnect.Cache][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public abstract class BaseCache : ICache
```

The **BaseCache** type exposes the following members.


Constructors
------------

                    | Name           | Description                                           
------------------- | -------------- | ----------------------------------------------------- 
![Protected method] | [BaseCache][4] | Initializes a new instance of the **BaseCache** class 


Properties
----------

                   | Name         | Description                    
------------------ | ------------ | ------------------------------ 
![Public property] | [IsEmpty][5] | Returns true if cache is empty 


Methods
-------

                    | Name                                        | Description                                                                                                             
------------------- | ------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------- 
![Public method]    | [Add(String, String, DiscoveryResponse)][6] | Add a value to the cache with the specified mcc and mnc                                                                 
![Public method]    | [Add&lt;T>(String, T)][7]                   | Add a value with the specified key                                                                                      
![Protected method] | [CheckIsExpired][8]                         | Checks if a object has been cached past the defined caching time or if internally the object has been marked as expired 
![Public method]    | [Clear][9]                                  | Remove all key value pairs from the cache                                                                               
![Protected method] | [ConcatKey][10]                             | Concatenates MCC and MNC into a single key                                                                              
![Public method]    | [Get(String, String)][11]                   | Return a cached value based on the mcc and mnc                                                                          
![Public method]    | [Get&lt;T>(String, Boolean)][12]            | Return a cached value based on the key                                                                                  
![Protected method] | [InternalAdd&lt;T>][13]                     | Add value to internal cache with given key                                                                              
![Protected method] | [InternalGet&lt;T>][14]                     | Get value from internal cache with given key                                                                            
![Public method]    | [Remove(String)][15]                        | Remove an entry from the cache that matches the key                                                                     
![Public method]    | [Remove(String, String)][16]                | Remove an entry from the cache that matches the mcc and mnc                                                             
![Public method]    | [SetCacheExpiryTime&lt;T>][17]              | Set length of time before cached values of the specified type are marked as expired.                                    


Fields
------

                                   | Name                     | Description                                                                              
---------------------------------- | ------------------------ | ---------------------------------------------------------------------------------------- 
![Protected field]                 | [_cacheExpiryLimits][18] | Values configured for the minimum and maximum configurable cache expiry times            
![Protected field]                 | [_cacheExpiryTimes][19]  | Values configured for cache expiry times of types                                        
![Protected field]![Static member] | [_completedTask][20]     | Convenience field to return when a non-async Task returning method needs to return early 


See Also
--------

#### Reference
[GSMA.MobileConnect.Cache Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../ConcurrentCache/README.md
[3]: ../README.md
[4]: _ctor.md
[5]: IsEmpty.md
[6]: Add.md
[7]: Add__1.md
[8]: CheckIsExpired.md
[9]: Clear.md
[10]: ConcatKey.md
[11]: Get.md
[12]: Get__1.md
[13]: InternalAdd__1.md
[14]: InternalGet__1.md
[15]: Remove.md
[16]: Remove_1.md
[17]: SetCacheExpiryTime__1.md
[18]: _cacheExpiryLimits.md
[19]: _cacheExpiryTimes.md
[20]: _completedTask.md
[21]: ../../_icons/Help.png
[Protected method]: ../../_icons/protmethod.gif "Protected method"
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Protected field]: ../../_icons/protfield.gif "Protected field"
[Static member]: ../../_icons/static.gif "Static member"