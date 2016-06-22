IDiscovery.ParseDiscoveryRedirect Method
========================================
Allows an application to obtain parameters which have been passed within a discovery redirect URL

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
ParsedDiscoveryRedirect ParseDiscoveryRedirect(
	Uri redirectedUrl
)
```

#### Parameters

##### *redirectedUrl*
Type: [System.Uri][2]  
The URL the operator selection functionality redirected to (Required)

#### Return Value
Type: [ParsedDiscoveryRedirect][3]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.IDiscovery.ParseDiscoveryRedirect(System.Uri)"]


Remarks
-------

The function will parse the redirect URL and parse out the components expected for discovery i.e.

- selectedMCC

- selectedMNC

- encryptedMSISDN


See Also
--------

#### Reference
[IDiscovery Interface][4]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/txt7706a
[3]: ../ParsedDiscoveryRedirect/README.md
[4]: README.md
[5]: ../../_icons/Help.png