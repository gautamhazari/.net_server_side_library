MobileConnectInvalidArgumentException Class
===========================================
Exception raised when invalid arguments are passed to [IAuthenticationService][1] or [IDiscoveryService][2] methods


Inheritance Hierarchy
---------------------
[System.Object][3]  
  [System.Exception][4]  
    **GSMA.MobileConnect.Exceptions.MobileConnectInvalidArgumentException**  

**Namespace:** [GSMA.MobileConnect.Exceptions][5]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class MobileConnectInvalidArgumentException : Exception
```

The **MobileConnectInvalidArgumentException** type exposes the following members.


Constructors
------------

                 | Name                                                          | Description                                                                                                                                                       
---------------- | ------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [MobileConnectInvalidArgumentException()][6]                  | Initializes a new instance of the [Exception][4] class.                                                                                                           
![Public method] | [MobileConnectInvalidArgumentException(String)][7]            | Initializes a new instance of the [Exception][4] class with a specified error message.                                                                            
![Public method] | [MobileConnectInvalidArgumentException(String, Exception)][8] | Initializes a new instance of the [Exception][4] class with a specified error message and a reference to the inner exception that is the cause of this exception. 
![Public method] | [MobileConnectInvalidArgumentException(String, String)][9]    | Creates a new exception with a composite message describing the invalid argument and calling method                                                               


Properties
----------

                   | Name           | Description          
------------------ | -------------- | -------------------- 
![Public property] | [Argument][10] | The invalid argument 


See Also
--------

#### Reference
[GSMA.MobileConnect.Exceptions Namespace][5]  

[1]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[2]: ../../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: http://msdn.microsoft.com/en-us/library/c18k6c59
[5]: ../README.md
[6]: _ctor.md
[7]: _ctor_1.md
[8]: _ctor_2.md
[9]: _ctor_3.md
[10]: Argument.md
[11]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"