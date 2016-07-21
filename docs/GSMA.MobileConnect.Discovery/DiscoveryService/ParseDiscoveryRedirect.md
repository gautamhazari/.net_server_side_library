DiscoveryService.ParseDiscoveryRedirect Method
==============================================
Allows an application to obtain parameters which have been passed within a discovery redirect URL

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public ParsedDiscoveryRedirect ParseDiscoveryRedirect(
	Uri redirectUrl
)
```

#### Parameters

##### *redirectUrl*
Type: [System.Uri][2]  

[Missing &lt;param name="redirectUrl"/> documentation for "M:GSMA.MobileConnect.Discovery.DiscoveryService.ParseDiscoveryRedirect(System.Uri)"]


#### Return Value
Type: [ParsedDiscoveryRedirect][3]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.DiscoveryService.ParseDiscoveryRedirect(System.Uri)"]

#### Implements
[IDiscoveryService.ParseDiscoveryRedirect(Uri)][4]  


Remarks
-------

The function will parse the redirect URL and parse out the components expected for discovery i.e.

- selectedMCC

- selectedMNC

- encryptedMSISDN


See Also
--------

#### Reference
[DiscoveryService Class][5]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/txt7706a
[3]: ../ParsedDiscoveryRedirect/README.md
[4]: ../IDiscoveryService/ParseDiscoveryRedirect.md
[5]: README.md
[6]: ../../_icons/Help.png