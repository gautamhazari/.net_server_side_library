ResponseConverter.Convert Method
================================
Convert to lightweight serializable MobileConnectWebResponse

**Namespace:** [GSMA.MobileConnect.Web][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static MobileConnectWebResponse Convert(
	MobileConnectStatus status
)
```

#### Parameters

##### *status*
Type: [GSMA.MobileConnect.MobileConnectStatus][2]  
Input status instance

#### Return Value
Type: [MobileConnectWebResponse][3]  
Serializable response instance

Examples
--------

```csharp
[HttpGet]
[Route("start_discovery")]
public async Task<object> StartDiscovery(string msisdn = "", string mcc = "", string mnc = "")
{
    var response = await _mobileConnect.AttemptDiscovery(Request, msisdn, mcc, mnc, true, new MobileConnectRequestOptions());
    return ResponseConverter.Convert(response);
}
```


See Also
--------

#### Reference
[ResponseConverter Class][4]  
[GSMA.MobileConnect.Web Namespace][1]  

[1]: ../README.md
[2]: ../../GSMA.MobileConnect/MobileConnectStatus/README.md
[3]: ../MobileConnectWebResponse/README.md
[4]: README.md
[5]: ../../_icons/Help.png