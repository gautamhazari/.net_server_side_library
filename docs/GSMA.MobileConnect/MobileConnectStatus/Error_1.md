MobileConnectStatus.Error Method (String, String, Exception, RequestTokenResponse)
==================================================================================
Creates a Status with ResponseType error and error related properties filled. Indicates that the MobileConnect process has been aborted due to an issue encountered.

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static MobileConnectStatus Error(
	string error,
	string message,
	Exception ex,
	RequestTokenResponse response
)
```

#### Parameters

##### *error*
Type: [System.String][2]  
Error code

##### *message*
Type: [System.String][2]  
User friendly error message

##### *ex*
Type: [System.Exception][3]  
Exception encountered (allows null)

##### *response*
Type: [GSMA.MobileConnect.Authentication.RequestTokenResponse][4]  
RequestTokenResponse if returned from [IAuthenticationService][5]

#### Return Value
Type: [MobileConnectStatus][6]  
MobileConnectStatus with ResponseType Error

See Also
--------

#### Reference
[MobileConnectStatus Class][6]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/c18k6c59
[4]: ../../GSMA.MobileConnect.Authentication/RequestTokenResponse/README.md
[5]: ../../GSMA.MobileConnect.Authentication/IAuthenticationService/README.md
[6]: README.md
[7]: ../../_icons/Help.png