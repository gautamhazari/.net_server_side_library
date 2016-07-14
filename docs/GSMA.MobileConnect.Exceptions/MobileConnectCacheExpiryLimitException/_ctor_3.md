MobileConnectCacheExpiryLimitException Constructor (Type, Nullable&lt;TimeSpan>, Nullable&lt;TimeSpan>)
=======================================================================================================
Creates an instance of the class MobileConnectCacheExpiryLimitException with a message detailing the target type and the configured limits for that type

**Namespace:** [GSMA.MobileConnect.Exceptions][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public MobileConnectCacheExpiryLimitException(
	Type targetType,
	Nullable<TimeSpan> lower,
	Nullable<TimeSpan> upper
)
```

#### Parameters

##### *targetType*
Type: [System.Type][2]  
Target type for cache expiry

##### *lower*
Type: [System.Nullable][3]&lt;[TimeSpan][4]>  
Lower limit for configuring the cache expiry against the target type

##### *upper*
Type: [System.Nullable][3]&lt;[TimeSpan][4]>  
Upper limit for configuring the cache expiry against the target type


See Also
--------

#### Reference
[MobileConnectCacheExpiryLimitException Class][5]  
[GSMA.MobileConnect.Exceptions Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/42892f65
[3]: http://msdn.microsoft.com/en-us/library/b3h38hb0
[4]: http://msdn.microsoft.com/en-us/library/269ew577
[5]: README.md
[6]: ../../_icons/Help.png