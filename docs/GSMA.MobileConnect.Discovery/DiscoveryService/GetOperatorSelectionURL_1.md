DiscoveryService.GetOperatorSelectionURL Method (String, String, String, String)
================================================================================
Synchronous wrapper for [GetOperatorSelectionURLAsync(String, String, String, String)][1]

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public DiscoveryResponse GetOperatorSelectionURL(
	string clientId,
	string clientSecret,
	string discoveryUrl,
	string redirectUrl
)
```

#### Parameters

##### *clientId*
Type: [System.String][3]  
The registered application client id. (Required)

##### *clientSecret*
Type: [System.String][3]  
The registered application client secret. (Required)

##### *discoveryUrl*
Type: [System.String][3]  
The URL of the discovery end point. (Required)

##### *redirectUrl*
Type: [System.String][3]  
The URL the operator selection functionality redirects to. (Required)

#### Return Value
Type: [DiscoveryResponse][4]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.DiscoveryService.GetOperatorSelectionURL(System.String,System.String,System.String,System.String)"]

#### Implements
[IDiscoveryService.GetOperatorSelectionURL(String, String, String, String)][5]  


See Also
--------

#### Reference
[DiscoveryService Class][6]  
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: ../IDiscoveryService/GetOperatorSelectionURLAsync_1.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../DiscoveryResponse/README.md
[5]: ../IDiscoveryService/GetOperatorSelectionURL_1.md
[6]: README.md
[7]: ../../_icons/Help.png