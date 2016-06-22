AuthenticationOptions.Display Property
======================================
ASCII String value to specify the user interface display for the Authentication and Consent flow. See remarks form more information.

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public string Display { get; set; }
```

#### Property Value
Type: [String][2]

Remarks
-------
 The values can be: 

- "page": Default value, if the display parameter is not added. The UI SHOULD be consistent with a full page view of the User-Agent.

- "popup": The popup window SHOULD be 450px X 500px [wide X tall].

- "touch": The Authorization Server SHOULD display the UI consistent with a "touch" based interface.

- "wap": The UI SHOULD be consistent with a "feature-phone" device display.


See Also
--------

#### Reference
[AuthenticationOptions Class][3]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png