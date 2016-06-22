MobileConnectWebResponse Class
==============================
Lightweight object to be serialized and returned through a web api


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Web.MobileConnectWebResponse**  

**Namespace:** [GSMA.MobileConnect.Web][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class MobileConnectWebResponse
```

The **MobileConnectWebResponse** type exposes the following members.


Constructors
------------

                 | Name                          | Description                                                          
---------------- | ----------------------------- | -------------------------------------------------------------------- 
![Public method] | [MobileConnectWebResponse][3] | Initializes a new instance of the **MobileConnectWebResponse** class 


Properties
----------

                   | Name               | Description                                                                             
------------------ | ------------------ | --------------------------------------------------------------------------------------- 
![Public property] | [Action][4]        | Action to take for next step                                                            
![Public property] | [Description][5]   | Error user friendly description if available                                            
![Public property] | [Error][6]         | Error code if available                                                                 
![Public property] | [Nonce][7]         | Nonce value used during Authorization, should be passed when handling the next redirect 
![Public property] | [SdkSession][8]    | If caching is enabled this will be required in the steps following discovery            
![Public property] | [State][9]         | State value used during Authorization, should be passed when handling the next redirect 
![Public property] | [Status][10]       | "success" or "failure", if "success" the next step should be attempted                  
![Public property] | [SubscriberId][11] | Encrypted MSISDN value returned from a successful Discovery call                        
![Public property] | [Token][12]        | Token data returned from a successful RequestToken call                                 
![Public property] | [Url][13]          | If next step requires visiting a url it will be returned with this property             


See Also
--------

#### Reference
[GSMA.MobileConnect.Web Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: Action.md
[5]: Description.md
[6]: Error.md
[7]: Nonce.md
[8]: SdkSession.md
[9]: State.md
[10]: Status.md
[11]: SubscriberId.md
[12]: Token.md
[13]: Url.md
[14]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"