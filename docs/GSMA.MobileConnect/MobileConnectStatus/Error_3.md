MobileConnectStatus.Error Method (String, String, Exception, String)
====================================================================
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
	string caller = null
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

##### *caller* (Optional)
Type: [System.String][2]  
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
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/c18k6c59
[4]: README.md
[5]: ../../_icons/Help.png