ClaimsValue Class
=================
Class representing a single claim to be requested


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Claims.ClaimsValue**  

**Namespace:** [GSMA.MobileConnect.Claims][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class ClaimsValue
```

The **ClaimsValue** type exposes the following members.


Properties
----------

                   | Name           | Description                                    
------------------ | -------------- | ---------------------------------------------- 
![Public property] | [Essential][3] | If the claim is essential                      
![Public property] | [Value][4]     | The expected value of the claim, if set        
![Public property] | [Values][5]    | The expected values array of the claim, if set 


Methods
-------

                                 | Name            | Description                                            
-------------------------------- | --------------- | ------------------------------------------------------ 
![Public method]![Static member] | [Required][6]   | Creates a new ClaimsValue with Essential set to true   
![Public method]![Static member] | [WithValue][7]  | Creates a new ClaimsValue with Value set as specified  
![Public method]![Static member] | [WithValues][8] | Creates a new ClaimsValue with Values set as specified 


See Also
--------

#### Reference
[GSMA.MobileConnect.Claims Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: Essential.md
[4]: Value.md
[5]: Values.md
[6]: Required.md
[7]: WithValue.md
[8]: WithValues.md
[9]: ../../_icons/Help.png
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Static member]: ../../_icons/static.gif "Static member"