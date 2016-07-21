DiscoveryService.CompleteSelectedOperatorDiscoveryAsync Method (String, String, String, String, String, String)
===============================================================================================================
Allows an application to use the selected operator MCC and MNC to obtain the discovery response. In the case there is already a discovery result in the cache and the Selected-MCC/Selected-MNC in the new request are the same as relates to the discovery result for the cached result, the cached result will be returned.

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<DiscoveryResponse> CompleteSelectedOperatorDiscoveryAsync(
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
The registered application redirect url (Required)

##### *selectedMCC*
Type: [System.String][2]  
The Mobile Country Code of the selected operator. (Required)

##### *selectedMNC*
Type: [System.String][2]  
The Mobile Network Code of the selected operator. (Required)

#### Return Value
Type: [Task][3]&lt;[DiscoveryResponse][4]>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.DiscoveryService.CompleteSelectedOperatorDiscoveryAsync(System.String,System.String,System.String,System.String,System.String,System.String)"]

#### Implements
[IDiscoveryService.CompleteSelectedOperatorDiscoveryAsync(String, String, String, String, String, String)][5]  


Remarks
-------
 If the operator cannot be identified by the discovery service the function will return the 'operator selection' form of the response. 

See Also
--------

#### Reference
[DiscoveryService Class][6]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: ../DiscoveryResponse/README.md
[5]: ../IDiscoveryService/CompleteSelectedOperatorDiscoveryAsync_1.md
[6]: README.md
[7]: ../../_icons/Help.png