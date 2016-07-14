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
![Public property] | [Nonce][8]                | Nonce value used during Authorization, should be passed when handling the next redirect                        
![Public property] | [SdkSession][9]           | If caching is enabled this will be required in the steps following discovery                                   
![Public property] | [State][10]               | State value used during Authorization, should be passed when handling the next redirect                        
![Public property] | [Status][11]              | "success" or "failure", if "success" the next step should be attempted                                         
![Public property] | [SubscriberId][12]        | Encrypted MSISDN value returned from a successful Discovery call                                               
![Public property] | [Token][13]               | Token data returned from a successful RequestToken call                                                        
![Public property] | [Url][14]                 | If next step requires visiting a url it will be returned with this property                                    
![Public property] | [UserInfo][15]            | UserInfo data returned from successful RequestUserInfo call                                                    


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
[8]: Nonce.md
[9]: SdkSession.md
[10]: State.md
[11]: Status.md
[12]: SubscriberId.md
[13]: Token.md
[14]: Url.md
[15]: UserInfo.md
[16]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"