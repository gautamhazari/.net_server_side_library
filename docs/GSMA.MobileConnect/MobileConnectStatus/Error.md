MobileConnectStatus.Error Method (ErrorResponse, String)
========================================================
Creates a status with ResponseType erorr and error related properties filled. Indicates that the MobileConnect process has been aborted due to an issue encountered.

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static MobileConnectStatus Error(
	ErrorResponse error,
	string caller = null
)
```

#### Parameters

##### *error*
Type: [GSMA.MobileConnect.ErrorResponse][2]  
ErrorResponse to retrieve error information from (Required)

##### *caller* (Optional)
Type: [System.String][3]  
Name of calling method

#### Return Value
Type: [MobileConnectStatus][4]  
MobileConnectStatus with ResponseType Error

See Also
--------

#### Reference
[MobileConnectStatus Class][4]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: ../ErrorResponse/README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: README.md
[5]: ../../_icons/Help.png