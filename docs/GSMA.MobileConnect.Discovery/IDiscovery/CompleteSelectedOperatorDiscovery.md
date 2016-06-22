IDiscovery.CompleteSelectedOperatorDiscovery Method (IPreferences, String, String, String)
==========================================================================================
Synchronous wrapper for [CompleteSelectedOperatorDiscoveryAsync(IPreferences, String, String, String)][1]

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
DiscoveryResponse CompleteSelectedOperatorDiscovery(
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
Type: [DiscoveryResponse][5]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.IDiscovery.CompleteSelectedOperatorDiscovery(GSMA.MobileConnect.Discovery.IPreferences,System.String,System.String,System.String)"]


See Also
--------

#### Reference
[IDiscovery Interface][6]  
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: CompleteSelectedOperatorDiscoveryAsync.md
[2]: ../README.md
[3]: ../IPreferences/README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../DiscoveryResponse/README.md
[6]: README.md
[7]: ../../_icons/Help.png