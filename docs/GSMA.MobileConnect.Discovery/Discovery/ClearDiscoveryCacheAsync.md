Discovery.ClearDiscoveryCacheAsync Method
=========================================
Helper function which clears any result from the discovery cache which corresponds with the provided parameters

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task ClearDiscoveryCacheAsync(
	string mcc = null,
	string mnc = null
)
```

#### Parameters

##### *mcc* (Optional)
Type: [System.String][2]  
The mobile country code of the cached object (optional)

##### *mnc* (Optional)
Type: [System.String][2]  
The mobile network code of the cached object (optional)

#### Return Value
Type: [Task][3]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.Discovery.ClearDiscoveryCacheAsync(System.String,System.String)"]

#### Implements
[IDiscovery.ClearDiscoveryCacheAsync(String, String)][4]  


Remarks
-------
If either mcc or mnc are null or empty the cache will be cleared

See Also
--------

#### Reference
[Discovery Class][5]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd235678
[4]: ../IDiscovery/ClearDiscoveryCacheAsync.md
[5]: README.md
[6]: ../../_icons/Help.png