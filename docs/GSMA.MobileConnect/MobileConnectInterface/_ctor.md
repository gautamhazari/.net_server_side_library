MobileConnectInterface Constructor (IDiscoveryService, IAuthenticationService, MobileConnectConfig)
===================================================================================================

**Note: This API is now obsolete.**
R1 supporting constructor, identity and jwks services will be defaulted

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
[ObsoleteAttribute("Constructor will be removed in v3")]
public MobileConnectInterface(
	IDiscoveryService discovery,
	IAuthenticationService authentication,
	MobileConnectConfig config
)
```

#### Parameters

##### *discovery*
Type: [GSMA.MobileConnect.Discovery.IDiscoveryService][2]  
Instance of IDiscovery concrete implementation

##### *authentication*
Type: [GSMA.MobileConnect.Authentication.IAuthenticationService][3]  
Instance of IAuthentication concrete implementation

##### *config*
Type: [GSMA.MobileConnect.MobileConnectConfig][4]  
Configuration options


See Also
--------

#### Reference
[MobileConnectInterface Class][5]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: ../../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[3]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[4]: ../MobileConnectConfig/README.md
[5]: README.md
[6]: ../../_icons/Help.png