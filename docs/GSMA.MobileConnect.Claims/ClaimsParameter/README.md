ClaimsParameter Class
=====================
Class to construct required claims for the mobile connect process


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Claims.ClaimsParameter**  

**Namespace:** [GSMA.MobileConnect.Claims][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class ClaimsParameter
```

The **ClaimsParameter** type exposes the following members.


Constructors
------------

                 | Name                 | Description                                                 
---------------- | -------------------- | ----------------------------------------------------------- 
![Public method] | [ClaimsParameter][3] | Initializes a new instance of the **ClaimsParameter** class 


Properties
----------

                   | Name          | Description                                                                                            
------------------ | ------------- | ------------------------------------------------------------------------------------------------------ 
![Public property] | [IdToken][4]  | Claims that are requested to be included in the returned IdToken from Authentication and Authorization 
![Public property] | [IsEmpty][5]  | Returns true if no claims will be requested using this claims parameter                                
![Public property] | [UserInfo][6] | Claims that are requested to be included in the returned UserInfo/Premium info response                


See Also
--------

#### Reference
[GSMA.MobileConnect.Claims Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: IdToken.md
[5]: IsEmpty.md
[6]: UserInfo.md
[7]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"