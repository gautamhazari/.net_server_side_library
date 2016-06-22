Discovery.CompleteSelectedOperatorDiscoveryAsync Method (IPreferences, String, String, String)
==============================================================================================
Convenience version of [CompleteSelectedOperatorDiscoveryAsync(String, String, String, String, String, String)][1] where the clientId, clientSecret and discoveryUrl are provided by the IPreferences implementation

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<DiscoveryResponse> CompleteSelectedOperatorDiscoveryAsync(
	IPreferences preferences,
	string redirectUrl,
	string selectedMCC,
	string selectedMNC
)
```

#### Parameters

##### *preferences*
Type: [GSMA.MobileConnect.Discovery.IPreferences][3]  
Instance of IPreferences that provides clientId, clientSecret and discoveryUrl (Required)

##### *redirectUrl*
Type: [System.String][4]  
The registered application redirect url (Required)

##### *selectedMCC*
Type: [System.String][4]  
The Mobile Country Code of the selected operator. (Required)

##### *selectedMNC*
Type: [System.String][4]  
The Mobile Network Code of the selected operator. (Required)

#### Return Value
Type: [Task][5]&lt;[DiscoveryResponse][6]>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.Discovery.CompleteSelectedOperatorDiscoveryAsync(GSMA.MobileConnect.Discovery.IPreferences,System.String,System.String,System.String)"]

#### Implements
[IDiscovery.CompleteSelectedOperatorDiscoveryAsync(IPreferences, String, String, String)][7]  


See Also
--------

#### Reference
[Discovery Class][8]  
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: ../IDiscovery/CompleteSelectedOperatorDiscoveryAsync_1.md
[2]: ../README.md
[3]: ../IPreferences/README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: http://msdn.microsoft.com/en-us/library/dd321424
[6]: ../DiscoveryResponse/README.md
[7]: ../IDiscovery/CompleteSelectedOperatorDiscoveryAsync.md
[8]: README.md
[9]: ../../_icons/Help.png