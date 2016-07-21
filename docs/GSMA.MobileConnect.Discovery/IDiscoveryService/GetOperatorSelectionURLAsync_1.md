IDiscoveryService.GetOperatorSelectionURLAsync Method (String, String, String, String)
======================================================================================
Allows an application to get the URL for the operator selection UI of the discovery service. This will not reference the discovery result cache. The returned URL will contain a session id created by the discovery server. The URL must be used as-is.

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
Task<DiscoveryResponse> GetOperatorSelectionURLAsync(
	string clientId,
	string clientSecret,
	string discoveryUrl,
	string redirectUrl
)
```

#### Parameters

##### *clientId*
Type: [System.String][2]  
The registered application client id. (Required)

##### *clientSecret*
Type: [System.String][2]  
The registered application client secret. (Required)

##### *discoveryUrl*
Type: [System.String][2]  
The URL of the discovery end point. (Required)

##### *redirectUrl*
Type: [System.String][2]  
The URL the operator selection functionality redirects to. (Required)

#### Return Value
Type: [Task][3]&lt;[DiscoveryResponse][4]>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.IDiscoveryService.GetOperatorSelectionURLAsync(System.String,System.String,System.String,System.String)"]


See Also
--------

#### Reference
[IDiscoveryService Interface][5]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: ../DiscoveryResponse/README.md
[5]: README.md
[6]: ../../_icons/Help.png