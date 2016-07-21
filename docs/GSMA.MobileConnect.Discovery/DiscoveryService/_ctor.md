DiscoveryService Constructor
============================
Creates a new instance of the class DiscoveryService using the specified RestClient for all HTTP requests

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public DiscoveryService(
	IDiscoveryCache cache,
	RestClient client
)
```

#### Parameters

##### *cache*
Type: [GSMA.MobileConnect.Cache.IDiscoveryCache][2]  
Cache implmentation to use for storage of [DiscoveryResponse][3] and [ProviderMetadata][4]

##### *client*
Type: [GSMA.MobileConnect.Utils.RestClient][5]  
RestClient for handling HTTP requests


See Also
--------

#### Reference
[DiscoveryService Class][6]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: ../../GSMA.MobileConnect.Cache/IDiscoveryCache/README.md
[3]: ../DiscoveryResponse/README.md
[4]: ../ProviderMetadata/README.md
[5]: ../../GSMA.MobileConnect.Utils/RestClient/README.md
[6]: README.md
[7]: ../../_icons/Help.png