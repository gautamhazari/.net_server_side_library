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

                 | Name                                     | Description                                              
---------------- | ---------------------------------------- | -------------------------------------------------------- 
![Public method] | [RequestTokenResponse(ErrorResponse)][4] | Creates a token response with an embedded error response 
![Public method] | [RequestTokenResponse(RestResponse)][5]  | Creates a valid token response from the raw RestResponse 


Properties
----------

                   | Name                       | Description                                                     
------------------ | -------------------------- | --------------------------------------------------------------- 
![Public property] | [DecodedIdTokenPayload][6] | Decoded JWT payload from IdToken in standard JSON string format 
![Public property] | [ErrorResponse][7]         | The response if the network request returned an error           
![Public property] | [Headers][8]               | A list of http headers                                          
![Public property] | [ResponseCode][9]          | The http response code returned by the network request          
![Public property] | [ResponseData][10]         | The response if the network request did not return an error     
![Public property] | [ValidationResult][11]     | Result of token response validation                             


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][3]  
[GSMA.MobileConnect.Authentication.IAuthenticationService][12]  

[1]: ../IAuthenticationService/RequestTokenAsync.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: _ctor_1.md
[6]: DecodedIdTokenPayload.md
[7]: ErrorResponse.md
[8]: Headers.md
[9]: ResponseCode.md
[10]: ResponseData.md
[11]: ValidationResult.md
[12]: ../IAuthenticationService/README.md
[13]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"