MobileConnectStatus.Complete Method
===================================
Creates a Status with ResponseType Complete and the complete [RequestTokenResponse][1]. Indicates that the MobileConnect process is complete and the user is authenticated.

**Namespace:** [GSMA.MobileConnect][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static MobileConnectStatus Complete(
	RequestTokenResponse response,
	string caller = null
)
```

#### Parameters

##### *response*
Type: [GSMA.MobileConnect.Authentication.RequestTokenResponse][1]  
RequestTokenResponse returned from [IAuthenticationService][3]

##### *caller* (Optional)
Type: [System.String][4]  
Name of calling method

#### Return Value
Type: [MobileConnectStatus][5]  
MobileConnectStatus with ResponseType Complete

See Also
--------

#### Reference
[MobileConnectStatus Class][5]  
[GSMA.MobileConnect Namespace][2]  

[1]: ../../GSMA.MobileConnect.Authentication/RequestTokenResponse/README.md
[2]: ../README.md
[3]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: README.md
[6]: ../../_icons/Help.png