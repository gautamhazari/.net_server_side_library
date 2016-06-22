IDiscovery.ClearDiscoveryCacheAsync Method
==========================================
Helper function which clears any result from the discovery cache which corresponds with the provided parameters

**Namespace:** [GSMA.MobileConnect.Discovery][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
Task ClearDiscoveryCacheAsync(
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

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Discovery.IDiscovery.ClearDiscoveryCacheAsync(System.String,System.String)"]


Remarks
-------
If either mcc or mnc are null or empty the cache will be cleared

See Also
--------

#### Reference
[IDiscovery Interface][4]  
[GSMA.MobileConnect.Discovery Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd235678
[4]: README.md
[5]: ../../_icons/Help.png