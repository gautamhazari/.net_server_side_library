IDiscovery.GetOperatorSelectionURL Method (String, String, String, String)
==========================================================================
Synchronous wrapper for [GetOperatorSelectionURLAsync(String, String, String, String)][1]

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
DiscoveryResponse GetOperatorSelectionURL(
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

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.IDiscovery.GetOperatorSelectionURL(System.String,System.String,System.String,System.String)"]


See Also
--------

#### Reference
[IDiscovery Interface][5]  
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: GetOperatorSelectionURLAsync_1.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../DiscoveryResponse/README.md
[5]: README.md
[6]: ../../_icons/Help.png