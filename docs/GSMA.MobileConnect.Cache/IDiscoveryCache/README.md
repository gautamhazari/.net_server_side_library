IDiscoveryCache Interface
=========================
Interface for the discovery response cache

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
------------------ | ------------ | ------------------- 
![Public property] | [IsEmpty][2] | Is the cache empty? 


Methods
-------

                 | Name                                        | Description                                                 
---------------- | ------------------------------------------- | ----------------------------------------------------------- 
![Public method] | [Add(String, DiscoveryResponse)][3]         | Add a value with the specified key                          
![Public method] | [Add(String, String, DiscoveryResponse)][4] | Add a value to the cache with the specified mcc and mnc     
![Public method] | [Clear][5]                                  | Remove all key value pairs from the cache                   
![Public method] | [Get(String)][6]                            | Return a cached value based on the key                      
![Public method] | [Get(String, String)][7]                    | Return a cached value based on the mcc and mnc              
![Public method] | [Remove(String)][8]                         | Remove an entry from the cache that matches the key         
![Public method] | [Remove(String, String)][9]                 | Remove an entry from the cache that matches the mcc and mnc 


See Also
--------

#### Reference
[GSMA.MobileConnect.Cache Namespace][1]  

[1]: ../README.md
[2]: IsEmpty.md
[3]: Add.md
[4]: Add_1.md
[5]: Clear.md
[6]: Get.md
[7]: Get_1.md
[8]: Remove.md
[9]: Remove_1.md
[10]: ../../_icons/Help.png
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Public method]: ../../_icons/pubmethod.gif "Public method"