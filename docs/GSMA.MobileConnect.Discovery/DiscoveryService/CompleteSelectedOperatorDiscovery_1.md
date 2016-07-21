DiscoveryService.CompleteSelectedOperatorDiscovery Method (String, String, String, String, String, String)
==========================================================================================================
Synchronous wrapper for [CompleteSelectedOperatorDiscoveryAsync(String, String, String, String, String, String)][1]

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public DiscoveryResponse CompleteSelectedOperatorDiscovery(
	string clientId,
	string clientSecret,
	string discoveryUrl,
	string redirectUrl,
	string selectedMCC,
	string selectedMNC
)
```

#### Parameters

##### *clientId*
Type: [System.String][3]  
The registered application clientId (Required)

##### *clientSecret*
Type: [System.String][3]  
the registered application client secret (Required)

##### *discoveryUrl*
Type: [System.String][3]  
The URL of the discovery endpoint (Required)

##### *redirectUrl*
Type: [System.String][3]  
The registered application redirect url (Required)

##### *selectedMCC*
Type: [System.String][3]  
The Mobile Country Code of the selected operator. (Required)

##### *selectedMNC*
Type: [System.String][3]  
The Mobile Network Code of the selected operator. (Required)

#### Return Value
Type: [DiscoveryResponse][4]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.DiscoveryService.CompleteSelectedOperatorDiscovery(System.String,System.String,System.String,System.String,System.String,System.String)"]

#### Implements
[IDiscoveryService.CompleteSelectedOperatorDiscovery(String, String, String, String, String, String)][5]  


See Also
--------

#### Reference
[DiscoveryService Class][6]  
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: ../IDiscoveryService/CompleteSelectedOperatorDiscoveryAsync_1.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../DiscoveryResponse/README.md
[5]: ../IDiscoveryService/CompleteSelectedOperatorDiscovery_1.md
[6]: README.md
[7]: ../../_icons/Help.png