IDiscoveryService.GetProviderMetadata Method
============================================
Retrieves an updated version of the ProviderMetadata if available, the discovery response property ProviderMetadata will also be updated with this version for future access

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
Task<ProviderMetadata> GetProviderMetadata(
	DiscoveryResponse response,
	bool forceCacheBypass
)
```

#### Parameters

##### *response*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][2]  
Discovery response to retrieve provider metadata for

##### *forceCacheBypass*
Type: [System.Boolean][3]  
 True if cache should be bypassed and the latest version of the ProviderMetadata should be fetched from the provider metadata endpoint. False if the cache should be tested first for a non-expired ProviderMetadata before trying the provider metadata endpoint.

#### Return Value
Type: [Task][4]&lt;[ProviderMetadata][5]>  
An updated ProviderMetadata object

Remarks
-------
This method can trigger an HTTP GET request

See Also
--------

#### Reference
[IDiscoveryService Interface][6]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: ../DiscoveryResponse/README.md
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: http://msdn.microsoft.com/en-us/library/dd321424
[5]: ../ProviderMetadata/README.md
[6]: README.md
[7]: ../../_icons/Help.png