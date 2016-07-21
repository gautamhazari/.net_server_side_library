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

                   | Name                      | Description                                                                                                    
------------------ | ------------------------- | -------------------------------------------------------------------------------------------------------------- 
![Public property] | [Action][4]               | Action to take for next step                                                                                   
![Public property] | [ApplicationShortName][5] | Application short name returned by discovery service, this identifies the application requesting authorization 
![Public property] | [Description][6]          | Error user friendly description if available                                                                   
![Public property] | [Error][7]                | Error code if available                                                                                        
![Public property] | [Identity][8]             | Identity data returned from successful RequestUserInfo or RequestIdentityInfo call                             
![Public property] | [Nonce][9]                | Nonce value used during Authorization, should be passed when handling the next redirect                        
![Public property] | [SdkSession][10]          | If caching is enabled this will be required in the steps following discovery                                   
![Public property] | [State][11]               | State value used during Authorization, should be passed when handling the next redirect                        
![Public property] | [Status][12]              | "success" or "failure", if "success" the next step should be attempted                                         
![Public property] | [SubscriberId][13]        | Encrypted MSISDN value returned from a successful Discovery call                                               
![Public property] | [Token][14]               | Token data returned from a successful RequestToken call                                                        
![Public property] | [Url][15]                 | If next step requires visiting a url it will be returned with this property                                    


See Also
--------

#### Reference
[GSMA.MobileConnect.Web Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: Action.md
[5]: ApplicationShortName.md
[6]: Description.md
[7]: Error.md
[8]: Identity.md
[9]: Nonce.md
[10]: SdkSession.md
[11]: State.md
[12]: Status.md
[13]: SubscriberId.md
[14]: Token.md
[15]: Url.md
[16]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"