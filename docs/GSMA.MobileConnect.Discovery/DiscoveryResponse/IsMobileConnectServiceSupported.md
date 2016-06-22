DiscoveryResponse.IsMobileConnectServiceSupported Method
========================================================
Check to see if provided scopes are supported by the operator linked to the discovery response

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public bool IsMobileConnectServiceSupported(
	string scope
)
```

#### Parameters

##### *scope*
Type: [System.String][2]  
A space or comma delimited string of required scope values, if empty or null true will be returned

#### Return Value
Type: [Boolean][3]  
True if all scope values requested are supported by the operator, false otherwise

Exceptions
----------

Exception                                              | Condition                                                    
------------------------------------------------------ | ------------------------------------------------------------ 
[MobileConnectProviderMetadataUnavailableException][4] | Throws if ProviderMetadata or ScopesSupported is unavailable 


See Also
--------

#### Reference
[DiscoveryResponse Class][5]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: ../../GSMA.MobileConnect.Exceptions/MobileConnectProviderMetadataUnavailableException/README.md
[5]: README.md
[6]: ../../_icons/Help.png