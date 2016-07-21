MobileConnectResponseType Enumeration
=====================================
Enum of possible response types for [MobileConnectStatus][1]

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public enum MobileConnectResponseType
```


Members
-------

Member name             | Value | Description                                                          
----------------------- | ----- | -------------------------------------------------------------------- 
**Error**               | 0     | ResponseType indicating Error was encountered                        
**OperatorSelection**   | 1     | ResponseType indicating the next step should be OperatorSelection    
**StartDiscovery**      | 2     | ResponseType indicating the next step should be to restart Discovery 
**StartAuthentication** | 3     | ResponseType indicating the next step should be StartAuthentication  
**Authentication**      | 4     | ResponseType indicating the next step should be Authentication       
**Complete**            | 5     | ResponseType indicating completion of the MobileConnectProcess       
**UserInfo**            | 6     | ResponseType indicating userInfo has been received                   
**Identity**            | 7     | ResponseType indicating identity has been received                   


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][2]  
[GSMA.MobileConnect.MobileConnectStatus][1]  

[1]: ../MobileConnectStatus/README.md
[2]: ../README.md
[3]: ../../_icons/Help.png