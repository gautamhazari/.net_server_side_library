IDiscoveryCache Interface
=========================
Interface for the cache used during the discovery process, cache is mainly used to cache DiscoveryResponse objects but can also be used to cache any data used during the Discovery process

**Namespace:** [GSMA.MobileConnect.Cache][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public interface IDiscoveryCache
```

The **IDiscoveryCache** type exposes the following members.


Properties
----------

                   | Name         | Description                    
------------------ | ------------ | ------------------------------ 
![Public property] | [IsEmpty][2] | Returns true if cache is empty 


Methods
-------

                 | Name                                        | Description                                                                          
---------------- | ------------------------------------------- | ------------------------------------------------------------------------------------ 
![Public method] | [Add(String, String, DiscoveryResponse)][3] | Add a value to the cache with the specified mcc and mnc                              
![Public method] | [Add&lt;T>(String, T)][4]                   | Add a value with the specified key                                                   
![Public method] | [Clear][5]                                  | Remove all key value pairs from the cache                                            
![Public method] | [Get(String, String)][6]                    | Return a cached value based on the mcc and mnc                                       
![Public method] | [Get&lt;T>(String, Boolean)][7]             | Return a cached value based on the key                                               
![Public method] | [Remove(String)][8]                         | Remove an entry from the cache that matches the key                                  
![Public method] | [Remove(String, String)][9]                 | Remove an entry from the cache that matches the mcc and mnc                          
![Public method] | [SetCacheExpiryTime&lt;T>][10]              | Set length of time before cached values of the specified type are marked as expired. 


See Also
--------

#### Reference
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: IsEmpty.md
[3]: Add.md
[4]: Add__1.md
[5]: Clear.md
[6]: Get.md
[7]: Get__1.md
[8]: Remove.md
[9]: Remove_1.md
[10]: SetCacheExpiryTime__1.md
[11]: ../../_icons/Help.png
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Public method]: ../../_icons/pubmethod.gif "Public method"