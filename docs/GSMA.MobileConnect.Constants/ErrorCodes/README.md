ErrorCodes Class
================
Error codes to be returned by MobileConnectStatus


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Constants.ErrorCodes**  

**Namespace:** [GSMA.MobileConnect.Constants][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static class ErrorCodes
```

The **ErrorCodes** type exposes the following members.


Fields
------

                                | Name                   | Description                                                                                                
------------------------------- | ---------------------- | ---------------------------------------------------------------------------------------------------------- 
![Public field]![Static member] | [AuthCancelled][3]     | Headless authentication was cancelled via timeout or cancellation token                                    
![Public field]![Static member] | [CacheDisabled][4]     | The cache is disabled so sdksession caching is not available                                               
![Public field]![Static member] | [HttpFailure][5]       | A failure occurred when attempting to make a HTTP request                                                  
![Public field]![Static member] | [InvalidArgument][6]   | An argument in the MobileConnect process was invalid or not supplied                                       
![Public field]![Static member] | [InvalidRedirect][7]   | The redirected url did not contain enough information to continue the mobile connect process               
![Public field]![Static member] | [InvalidSdkSession][8] | The sdksession supplied was invalid and does not match a cached session                                    
![Public field]![Static member] | [InvalidState][9]      | The state supplied when requesting a token did not match the state returned by the authentication redirect 
![Public field]![Static member] | [InvalidToken][10]     | The token response did not pass all validation checks                                                      
![Public field]![Static member] | [NotSupported][11]     | The requested functionality is not supported by the current operator                                       
![Public field]![Static member] | [Unknown][12]          | An unknown error has occurred, the attached exception should include diagnosable information               


See Also
--------

#### Reference
[GSMA.MobileConnect.Constants Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: AuthCancelled.md
[4]: CacheDisabled.md
[5]: HttpFailure.md
[6]: InvalidArgument.md
[7]: InvalidRedirect.md
[8]: InvalidSdkSession.md
[9]: InvalidState.md
[10]: InvalidToken.md
[11]: NotSupported.md
[12]: Unknown.md
[13]: ../../_icons/Help.png
[Public field]: ../../_icons/pubfield.gif "Public field"
[Static member]: ../../_icons/static.gif "Static member"