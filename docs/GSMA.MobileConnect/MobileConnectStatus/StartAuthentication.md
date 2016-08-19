MobileConnectStatus.StartAuthentication Method
==============================================
Creates a Status with ResponseType StartAuthorization and the complete [DiscoveryResponse][1]. Indicates that the next step should be starting authorization.

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static MobileConnectStatus StartAuthentication(
	DiscoveryResponse response,
	string caller = null
)
```

#### Parameters

##### *response*
Type: [GSMA.MobileConnect.Discovery.DiscoveryResponse][3]  
DiscoveryResponse returned from [IDiscoveryService][4]

##### *caller* (Optional)
Type: [System.String][5]  
Name of calling method

#### Return Value
Type: [MobileConnectStatus][6]  
MobileConnectStatus with ResponseType StartAuthorization

See Also
--------

#### Reference
[MobileConnectStatus Class][6]  
[GSMA.MobileConnect Namespace][2]  

[1]: DiscoveryResponse.md
[2]: ../README.md
[3]: ../../GSMA.MobileConnect.Discovery/DiscoveryResponse/README.md
[4]: ../../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: README.md
[7]: ../../_icons/Help.png