IdentityResponse Class
======================
Class to hold response from UserInfo service


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Identity.IdentityResponse**  

**Namespace:** [GSMA.MobileConnect.Identity][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class IdentityResponse
```

The **IdentityResponse** type exposes the following members.


Constructors
------------

                 | Name                                                          | Description                                                                                                      
---------------- | ------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------- 
![Public method] | [IdentityResponse(String)][3]                                 | Creates a new instance of the UserInfoResponse class                                                             
![Public method] | [IdentityResponse(RestResponse, IdentityService.InfoType)][4] | Creates a new instance of the UserInfoResponse class using a the json content of a RestResponse for construction 


Properties
----------

                   | Name               | Description                                               
------------------ | ------------------ | --------------------------------------------------------- 
![Public property] | [ErrorResponse][5] | The response if the network request returned an error     
![Public property] | [ResponseCode][6]  | Returns the Http response code or 0 if the data is cached 
![Public property] | [ResponseJson][7]  | The parsed json response data                             
![Public property] | [Type][8]          | UserInfo or PremiumInfo                                   


Methods
-------

                 | Name                      | Description                                              
---------------- | ------------------------- | -------------------------------------------------------- 
![Public method] | [ResponseDataAs&lt;T>][9] | Converts response JSON to custom provided identity class 


See Also
--------

#### Reference
[GSMA.MobileConnect.Identity Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor_1.md
[4]: _ctor.md
[5]: ErrorResponse.md
[6]: ResponseCode.md
[7]: ResponseJson.md
[8]: Type.md
[9]: ResponseDataAs__1.md
[10]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"