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

Member name            | Value | Description                                                          
---------------------- | ----- | -------------------------------------------------------------------- 
**Error**              | 0     | ResponseType indicating Error was encountered                        
**OperatorSelection**  | 1     | ResponseType indicating the next step should be OperatorSelection    
**StartDiscovery**     | 2     | ResponseType indicating the next step should be to restart Discovery 
**StartAuthorization** | 3     | ResponseType indicating the next step should be StartAuthorization   
**Authorization**      | 4     | ResponseType indicating the next step should be Authorization        
**Complete**           | 5     | ResponseType indicating completion of the MobileConnectProcess       


See Also
--------

#### Reference
[GSMA.MobileConnect Namespace][2]  
[GSMA.MobileConnect.MobileConnectStatus][1]  

[1]: ../MobileConnectStatus/README.md
[2]: ../README.md
[3]: ../../_icons/Help.png