ErrorResponse Class
===================
Class to hold a Rest error response


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.ErrorResponse**  

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class ErrorResponse
```

The **ErrorResponse** type exposes the following members.


Constructors
------------

                 | Name               | Description                                               
---------------- | ------------------ | --------------------------------------------------------- 
![Public method] | [ErrorResponse][3] | Initializes a new instance of the **ErrorResponse** class 


Properties
----------

                   | Name                  | Description           
------------------ | --------------------- | --------------------- 
![Public property] | [Error][4]            | The error code        
![Public property] | [ErrorDescription][5] | The error description 
![Public property] | [ErrorUri][6]         | The error URI         


Methods
-------

                                 | Name               | Description                                                                                               
-------------------------------- | ------------------ | --------------------------------------------------------------------------------------------------------- 
![Public method]![Static member] | [CreateFromUrl][7] | Creates an instance of the class ErrorResponse using a redirect url as the source for the error arguments 


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: Error.md
[5]: ErrorDescription.md
[6]: ErrorUri.md
[7]: CreateFromUrl.md
[8]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Static member]: ../../_icons/static.gif "Static member"