RestAuthentication Class
========================
Helper class for holding authentication values for calling rest endpoints using [RestClient][1]


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Utils.RestAuthentication**  

**Namespace:** [GSMA.MobileConnect.Utils][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class RestAuthentication
```

The **RestAuthentication** type exposes the following members.


Constructors
------------

                 | Name                    | Description                                                                                   
---------------- | ----------------------- | --------------------------------------------------------------------------------------------- 
![Public method] | [RestAuthentication][4] | Create a new instance of the RestAuthentication class with the specified scheme and parameter 


Properties
----------

                   | Name           | Description                                                   
------------------ | -------------- | ------------------------------------------------------------- 
![Public property] | [Parameter][5] | The authentication parameter such as a token or encoded value 
![Public property] | [Scheme][6]    | The scheme of authentication e.g. Basic                       


Methods
-------

                                 | Name        | Description                                                                      
-------------------------------- | ----------- | -------------------------------------------------------------------------------- 
![Public method]![Static member] | [Basic][7]  | Creates a new instance of the RestAuthentication class for Basic authentication  
![Public method]![Static member] | [Bearer][8] | Creates a new instance of the RestAuthentication class for Bearer authentication 


See Also
--------

#### Reference
[GSMA.MobileConnect.Utils Namespace][3]  

[1]: ../RestClient/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: Parameter.md
[6]: Scheme.md
[7]: Basic.md
[8]: Bearer.md
[9]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Static member]: ../../_icons/static.gif "Static member"