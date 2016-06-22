ConcurrentDiscoveryCache Class
==============================
Concrete implementation of [IDiscoveryCache][1] using a ConcurrentDictionary as the internal caching mechanism


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Cache.ConcurrentDiscoveryCache**  

**Namespace:** [GSMA.MobileConnect.Cache][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class ConcurrentDiscoveryCache : IDiscoveryCache
```

The **ConcurrentDiscoveryCache** type exposes the following members.


Constructors
------------

                 | Name                          | Description                                                          
---------------- | ----------------------------- | -------------------------------------------------------------------- 
![Public method] | [ConcurrentDiscoveryCache][4] | Initializes a new instance of the **ConcurrentDiscoveryCache** class 


Properties
----------

                   | Name         | Description                    
------------------ | ------------ | ------------------------------ 
![Public property] | [IsEmpty][5] | Returns true if cache is empty 


Methods
-------

                 | Name                                        | Description                                                                  
---------------- | ------------------------------------------- | ---------------------------------------------------------------------------- 
![Public method] | [Add(String, DiscoveryResponse)][6]         | Adds the DiscoveryResponse to the cache with the supplied key value          
![Public method] | [Add(String, String, DiscoveryResponse)][7] | Adds the DiscoveryResponse to the cache with the supplied MCC and MNC values 
![Public method] | [Clear][8]                                  | Clears the cache                                                             
![Public method] | [Get(String)][9]                            | Retrieves a copy of the cached response if found and has not expired         
![Public method] | [Get(String, String)][10]                   | Retrieves a copy of the cached response if found and has not expired         
![Public method] | [Remove(String)][11]                        | Removes a value from the cache if it exists                                  
![Public method] | [Remove(String, String)][12]                | Removes a value from the cache if it exists                                  


See Also
--------

#### Reference
[GSMA.MobileConnect.Cache Namespace][3]  

[1]: ../IDiscoveryCache/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: IsEmpty.md
[6]: Add.md
[7]: Add_1.md
[8]: Clear.md
[9]: Get.md
[10]: Get_1.md
[11]: Remove.md
[12]: Remove_1.md
[13]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"