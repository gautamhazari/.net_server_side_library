ClaimsDictionary.Item Property
==============================
Get or set claim value at specified key

**Namespace:** [GSMA.MobileConnect.Claims][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public ClaimsValue this[
	string key
] { get; set; }
```

#### Parameters

##### *key*
Type: [System.String][2]  
Claim key

#### Return Value
Type: [ClaimsValue][3]  
Claims value or null if no claim found for key
#### Implements
[IDictionary&lt;TKey, TValue>.Item[TKey]][4]  


See Also
--------

#### Reference
[ClaimsDictionary Class][5]  
[GSMA.MobileConnect.Claims Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../ClaimsValue/README.md
[4]: http://msdn.microsoft.com/en-us/library/zyxt2e2h
[5]: README.md
[6]: ../../_icons/Help.png