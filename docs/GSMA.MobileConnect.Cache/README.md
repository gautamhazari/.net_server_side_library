GSMA.MobileConnect.Cache Namespace
==================================
This namespace contains classes for caching of responses from the MobileConnect process


Classes
-------

                | Class                | Description                                                                                                                                                              
--------------- | -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public class] | [BaseCache][1]       | Base class for Discovery Caches that implements basic cache control mechanisms and type casting reducing the amount of implementation needed in each derived cache class 
![Public class] | [ConcurrentCache][2] | Concrete implementation of [ICache][3] using a ConcurrentDictionary as the internal caching mechanism                                                                    


Interfaces
----------

                    | Interface       | Description                                                                                                                                                                                 
------------------- | --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public interface] | [ICache][3]     | Interface for the cache used during the discovery process, cache is mainly used to cache DiscoveryResponse objects but can also be used to cache any data used during the Discovery process 
![Public interface] | [ICacheable][4] | Interface for cacheable objects                                                                                                                                                             

[1]: BaseCache/README.md
[2]: ConcurrentCache/README.md
[3]: ICache/README.md
[4]: ICacheable/README.md
[5]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public interface]: ../_icons/pubinterface.gif "Public interface"