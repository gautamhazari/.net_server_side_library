DiscoveryOptions.ClientIP Property
==================================
Allows a server application to indicate the 'public IP address' of the connection from a client application/mobile browser to the server.

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public string ClientIP { get; set; }
```

#### Property Value
Type: [String][2]

Remarks
-------
 This is used in place of the public IP address normally detected by the discovery service. Note this will usually differ from the Local-Client-IP address, and the public IP address detected by the application server should not be used for the Local-Client-IP address. 

See Also
--------

#### Reference
[DiscoveryOptions Class][3]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png