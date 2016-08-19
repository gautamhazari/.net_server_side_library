UnixTimestamp.ToUTCDateTime Method (String)
===========================================
Converts a unix timestamp to a UTC DateTime representation

**Namespace:** [GSMA.MobileConnect.Utils][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public static DateTime ToUTCDateTime(
	string timestamp
)
```

#### Parameters

##### *timestamp*
Type: [System.String][2]  
Timestamp to convert

#### Return Value
Type: [DateTime][3]  
UTC DateTime

Exceptions
----------

Exception                  | Condition                       
-------------------------- | ------------------------------- 
[ArgumentNullException][4] | timestamp is null               
[FormatException][5]       | timestamp is not a valid number 
[OverflowException][6]     | timestamp is not a valid int    


See Also
--------

#### Reference
[UnixTimestamp Class][7]  
[GSMA.MobileConnect.Utils Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/03ybds8y
[4]: http://msdn.microsoft.com/en-us/library/27426hcy
[5]: http://msdn.microsoft.com/en-us/library/b5s9cs7s
[6]: http://msdn.microsoft.com/en-us/library/41ktf3wy
[7]: README.md
[8]: ../../_icons/Help.png