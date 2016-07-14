Scope Class
===========
Helper methods for dealing with scope and scope values


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Utils.Scope**  

**Namespace:** [GSMA.MobileConnect.Utils][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static class Scope
```


Methods
-------

                                 | Name                                             | Description                                                                                                                                                                                                   
-------------------------------- | ------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]![Static member] | [CoerceOpenIdScope(IList&lt;String>, String)][3] | Returns a list of scope values that is ensured to contain the defaultScope values and has any duplication of values removed. This can be used when multiple modifications of scope are required to be chained 
![Public method]![Static member] | [CoerceOpenIdScope(String, String)][4]           | Returns a scope that is ensured to contain the defaultScope and has any duplication of values removed                                                                                                         


See Also
--------

#### Reference
[GSMA.MobileConnect.Utils Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: CoerceOpenIdScope.md
[4]: CoerceOpenIdScope_1.md
[5]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"