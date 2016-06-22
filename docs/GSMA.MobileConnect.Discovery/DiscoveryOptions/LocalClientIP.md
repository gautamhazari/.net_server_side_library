DiscoveryOptions.LocalClientIP Property
=======================================
The current local IP address of the client application i.e. the actual IP address currently allocated to the device running the application.

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public string LocalClientIP { get; set; }
```

#### Property Value
Type: [String][2]

Remarks
-------
 This can be used within header injection processes from the MNO to confirm the application is directly using a mobile data connection from the consumption device rather than MiFi/WiFi to mobile hotspot. 

See Also
--------

#### Reference
[DiscoveryOptions Class][3]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png