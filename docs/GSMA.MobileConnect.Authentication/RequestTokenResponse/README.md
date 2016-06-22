RequestTokenResponse Class
==========================
Class to hold the response of [RequestTokenAsync(String, String, String, String, String)][1] Will contain either an error response or request data


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Authentication.RequestTokenResponse**  

**Namespace:** [GSMA.MobileConnect.Authentication][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class RequestTokenResponse
```

The **RequestTokenResponse** type exposes the following members.


Constructors
------------

                 | Name                      | Description                                              
---------------- | ------------------------- | -------------------------------------------------------- 
![Public method] | [RequestTokenResponse][4] | Creates a valid token response from the raw RestResponse 


Properties
----------

                   | Name                       | Description                                                     
------------------ | -------------------------- | --------------------------------------------------------------- 
![Public property] | [DecodedIdTokenPayload][5] | Decoded JWT payload from IdToken in standard JSON string format 
![Public property] | [ErrorResponse][6]         | The response if the network request returned an error           
![Public property] | [Headers][7]               | A list of http headers                                          
![Public property] | [ResponseCode][8]          | The http response code returned by the network request          
![Public property] | [ResponseData][9]          | The response if the network request did not return an error     


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][3]  
[GSMA.MobileConnect.Authentication.IAuthentication][10]  

[1]: ../IAuthentication/RequestTokenAsync.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: DecodedIdTokenPayload.md
[6]: ErrorResponse.md
[7]: Headers.md
[8]: ResponseCode.md
[9]: ResponseData.md
[10]: ../IAuthentication/README.md
[11]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"