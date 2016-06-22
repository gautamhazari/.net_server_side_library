MobileConnectRequestOptions.LoginHint Property
==============================================
An indication to the IDP/Authorization Server on what ID to use for login. If known this will default to the encrypted MSISDN value. See remarks for more information.

**Namespace:** [GSMA.MobileConnect][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public string LoginHint { get; set; }
```

#### Property Value
Type: [String][2]

Remarks
-------
 The login_hint can contain the MSISDN or the Encrypted MSISDN and SHOULD be tagged as MSISDN:&lt;Value> and ENCR_MSISDN:&lt;Value> respectively - in case MSISDN or Encrypted MSISDN is passed in login_hint. Encrypted MSISDN value is returned by Discovery API in the form of "subscriber_id" 

See Also
--------

#### Reference
[MobileConnectRequestOptions Class][3]  
[GSMA.MobileConnect Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: README.md
[4]: ../../_icons/Help.png