Discovery.StartAutomatedOperatorDiscoveryAsync Method (String, String, String, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)
===========================================================================================================================================
Allows an application to conduct discovery based on the predetermined operator/network identified operator semantics. If the operator cannot be identified the function will return the 'operator selection' form of the response. The application can then determine how to proceed i.e. open the operator selection page separately or otherwise handle this.

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<DiscoveryResponse> StartAutomatedOperatorDiscoveryAsync(
	string clientId,
	string clientSecret,
	string discoveryUrl,
	string redirectUrl,
	DiscoveryOptions options,
	IEnumerable<BasicKeyValuePair> currentCookies
)
```

#### Parameters

##### *clientId*
Type: [System.String][2]  
The registered application clientId (Required)

##### *clientSecret*
Type: [System.String][2]  
the registered application client secret (Required)

##### *discoveryUrl*
Type: [System.String][2]  
The URL of the discovery endpoint (Required)

##### *redirectUrl*
Type: [System.String][2]  
The URL of the operator selection functionality redirects to. (Required)

##### *options*
Type: [GSMA.MobileConnect.Discovery.DiscoveryOptions][3]  
Optional parameters

##### *currentCookies*
Type: [System.Collections.Generic.IEnumerable][4]&lt;[BasicKeyValuePair][5]>  
List of the current cookies sent by the browser if applicable

#### Return Value
Type: [Task][6]&lt;[DiscoveryResponse][7]>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.Discovery.StartAutomatedOperatorDiscoveryAsync(System.String,System.String,System.String,System.String,GSMA.MobileConnect.Discovery.DiscoveryOptions,System.Collections.Generic.IEnumerable{GSMA.MobileConnect.Utils.BasicKeyValuePair})"]

#### Implements
[IDiscovery.StartAutomatedOperatorDiscoveryAsync(String, String, String, String, DiscoveryOptions, IEnumerable&lt;BasicKeyValuePair>)][8]  


Remarks
-------
 The operator selection functionality will display a series of pages that enables the user to identify an operator, the results are passed back to the current application as parameters on the redirect URL. 

Valid discovery responses can be cached and this method can return cached data


See Also
--------

#### Reference
[Discovery Class][9]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../DiscoveryOptions/README.md
[4]: http://msdn.microsoft.com/en-us/library/9eekhta0
[5]: ../../GSMA.MobileConnect.Utils/BasicKeyValuePair/README.md
[6]: http://msdn.microsoft.com/en-us/library/dd321424
[7]: ../DiscoveryResponse/README.md
[8]: ../IDiscovery/StartAutomatedOperatorDiscoveryAsync_1.md
[9]: README.md
[10]: ../../_icons/Help.png