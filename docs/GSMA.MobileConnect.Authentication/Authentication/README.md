Authentication Class
====================
Concrete implementation of [IAuthentication][1]


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Authentication.Authentication**  

**Namespace:** [GSMA.MobileConnect.Authentication][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class Authentication : IAuthentication
```

The **Authentication** type exposes the following members.


Constructors
------------

                 | Name                | Description                                                
---------------- | ------------------- | ---------------------------------------------------------- 
![Public method] | [Authentication][4] | Initializes a new instance of the **Authentication** class 


Methods
-------

                 | Name                     | Description                                                                                                                                                                     
---------------- | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [RequestToken][5]        | Synchronous wrapper for [RequestTokenAsync(String, String, String, String, String)][6]                                                                                          
![Public method] | [RequestTokenAsync][7]   | Allows an application to use the authorization code obtained from authentication/authorization to obtain an access token and related information from the authorization server. 
![Public method] | [StartAuthentication][8] | Generates an authorisation url based on the supplied options and previous discovery response                                                                                    


See Also
--------

#### Reference
[GSMA.MobileConnect.Authentication Namespace][3]  

[1]: ../IAuthentication/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: RequestToken.md
[6]: ../IAuthentication/RequestTokenAsync.md
[7]: RequestTokenAsync.md
[8]: StartAuthentication.md
[9]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"