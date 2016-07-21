DiscoveryService.GetOperatorSelectionURLAsync Method (IPreferences, String)
===========================================================================
Convenience wrapper for [GetOperatorSelectionURLAsync(String, String, String, String)][1] where the clientId, clientSecret and discoveryUrl are provided by the IPreferences implementation

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<DiscoveryResponse> GetOperatorSelectionURLAsync(
	IPreferences preferences,
	string redirectUrl
)
```

#### Parameters

##### *preferences*
Type: [GSMA.MobileConnect.Discovery.IPreferences][3]  
Instance of IPreferences that provides clientId, clientSecret and discoveryUrl (Required)

##### *redirectUrl*
Type: [System.String][4]  
The URL the operator selection functionality redirects to. (Required)

#### Return Value
Type: [Task][5]&lt;[DiscoveryResponse][6]>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.DiscoveryService.GetOperatorSelectionURLAsync(GSMA.MobileConnect.Discovery.IPreferences,System.String)"]

#### Implements
[IDiscoveryService.GetOperatorSelectionURLAsync(IPreferences, String)][7]  


See Also
--------

#### Reference
[DiscoveryService Class][8]  
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: ../IDiscoveryService/GetOperatorSelectionURLAsync_1.md
[2]: ../README.md
[3]: ../IPreferences/README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: http://msdn.microsoft.com/en-us/library/dd321424
[6]: ../DiscoveryResponse/README.md
[7]: ../IDiscoveryService/GetOperatorSelectionURLAsync.md
[8]: README.md
[9]: ../../_icons/Help.png