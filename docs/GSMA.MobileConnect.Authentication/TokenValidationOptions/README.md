TokenValidationOptions Class
============================
Options for handling token validation


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Authentication.TokenValidationOptions**  

**Namespace:** [GSMA.MobileConnect.Authentication][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class TokenValidationOptions
```

The **TokenValidationOptions** type exposes the following members.


Constructors
------------

                 | Name                        | Description                                                        
---------------- | --------------------------- | ------------------------------------------------------------------ 
![Public method] | [TokenValidationOptions][3] | Initializes a new instance of the **TokenValidationOptions** class 


Properties
----------

                   | Name                           | Description                                                                                                                                                                                                                                                                                                                                        
------------------ | ------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [AcceptedValidationResults][4] | Bit flag specifying which validation results should be accepted as "OK", if any results not specified are returned from validation an error status to be returned when requesting a token. By default only tokens that pass all validation steps will be accepted, allowing others to be accepted is at the SDK users own risk and is not advised. 


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: AcceptedValidationResults.md
[5]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"