RevokeTokenResponse Class
=========================
Class to hold the response of [RevokeToken(String, String, String, String, String)][1] Will contain either an error response or success indicator


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Authentication.RevokeTokenResponse**  

**Namespace:** [GSMA.MobileConnect.Authentication][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class RevokeTokenResponse
```

The **RevokeTokenResponse** type exposes the following members.


Constructors
------------

                 | Name                     | Description                                              
---------------- | ------------------------ | -------------------------------------------------------- 
![Public method] | [RevokeTokenResponse][4] | Creates a valid token response from the raw RestResponse 


Properties
----------

                   | Name               | Description                                           
------------------ | ------------------ | ----------------------------------------------------- 
![Public property] | [ErrorResponse][5] | The response if the network request returned an error 
![Public property] | [Success][6]       | True if token revoke succeeded                        


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][3]  

[1]: ../IAuthenticationService/RevokeToken.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: ErrorResponse.md
[6]: Success.md
[7]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"