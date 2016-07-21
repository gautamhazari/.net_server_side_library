IDiscoveryService.StartAutomatedOperatorDiscovery Method (IPreferences, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)
====================================================================================================================================
Synchronous wrapper for [StartAutomatedOperatorDiscoveryAsync(IPreferences, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][1]

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
DiscoveryResponse StartAutomatedOperatorDiscovery(
	IPreferences preferences,
	string redirectUrl,
	DiscoveryOptions options,
	IEnumerable<BasicKeyValuePair> currentCookies
)
```

#### Parameters

##### *preferences*
Type: [GSMA.MobileConnect.Discovery.IPreferences][3]  
Instance of IPreferences that provides clientId, clientSecret and discoveryUrl (Required)

##### *redirectUrl*
Type: [System.String][4]  
The URL of the operator selection functionality redirects to. (Required)

##### *options*
Type: [GSMA.MobileConnect.Discovery.DiscoveryOptions][5]  
Optional parameters

##### *currentCookies*
Type: [System.Collections.Generic.IEnumerable][6]&lt;[BasicKeyValuePair][7]>  
List of the current cookies sent by the browser if applicable

#### Return Value
Type: [DiscoveryResponse][8]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.IDiscoveryService.StartAutomatedOperatorDiscovery(GSMA.MobileConnect.Discovery.IPreferences,System.String,GSMA.MobileConnect.Discovery.DiscoveryOptions,System.Collections.Generic.IEnumerable{GSMA.MobileConnect.Utils.BasicKeyValuePair})"]


See Also
--------

#### Reference
[IDiscoveryService Interface][9]  
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: StartAutomatedOperatorDiscoveryAsync.md
[2]: ../README.md
[3]: ../IPreferences/README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../DiscoveryOptions/README.md
[6]: http://msdn.microsoft.com/en-us/library/9eekhta0
[7]: ../../GSMA.MobileConnect.Utils/BasicKeyValuePair/README.md
[8]: ../DiscoveryResponse/README.md
[9]: README.md
[10]: ../../_icons/Help.png