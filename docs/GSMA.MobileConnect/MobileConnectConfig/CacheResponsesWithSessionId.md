MobileConnectConfig.CacheResponsesWithSessionId Property
========================================================
When set to true [MobileConnectWebInterface][1] will use the configured discovery cache to cache discovery responses against a session id. This allows the session id to be passed to following calls in the mobile connect process instead of requiring the discovery response to be passed. (DEFAULTS to true)

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public bool CacheResponsesWithSessionId { get; set; }
```

#### Property Value
Type: [Boolean][3]

Remarks
-------
 For this method to be reliable in multi server deployments a cross server cache implementation must be configured 

See Also
--------

#### Reference
[MobileConnectConfig Class][4]  
[GSMA.MobileConnect Namespace][2]  

[1]: ../MobileConnectWebInterface/README.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: README.md
[5]: ../../_icons/Help.png