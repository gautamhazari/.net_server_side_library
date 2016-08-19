MobileConnectInterface Constructor (MobileConnectConfig, IDiscoveryService, IAuthenticationService, IIdentityService, IJWKeysetService)
=======================================================================================================================================
Initializes a new instance of the MobileConnectInterface class

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public MobileConnectInterface(
	MobileConnectConfig config,
	IDiscoveryService discovery,
	IAuthenticationService authentication,
	IIdentityService identity,
	IJWKeysetService jwks
)
```

#### Parameters

##### *config*
Type: [GSMA.MobileConnect.MobileConnectConfig][2]  
Configuration options

##### *discovery*
Type: [GSMA.MobileConnect.Discovery.IDiscoveryService][3]  
Instance of IDiscovery concrete implementation

##### *authentication*
Type: [GSMA.MobileConnect.Authentication.IAuthenticationService][4]  
Instance of IAuthentication concrete implementation

##### *identity*
Type: [GSMA.MobileConnect.Identity.IIdentityService][5]  
Instance of IIdentityService concrete implementation

##### *jwks*
Type: [GSMA.MobileConnect.Authentication.IJWKeysetService][6]  
Instance of IJWKeysetService concrete implementation


See Also
--------

#### Reference
[MobileConnectInterface Class][7]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: ../MobileConnectConfig/README.md
[3]: ../../GSMA.MobileConnect.Discovery/IDiscoveryService/README.md
[4]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[5]: ../../GSMA.MobileConnect.Identity/IIdentityService/README.md
[6]: ../../GSMA.MobileConnect.Authentication/IJWKeysetService/README.md
[7]: README.md
[8]: ../../_icons/Help.png