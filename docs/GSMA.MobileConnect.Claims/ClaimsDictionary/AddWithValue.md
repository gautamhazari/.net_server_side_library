ClaimsDictionary.AddWithValue Method
====================================
Add a claim with the specified key and value. When claims are sent to a method that accepts them the response will only contain the claim if the values match.

**Namespace:** [GSMA.MobileConnect.Claims][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public void AddWithValue(
	string key,
	bool required,
	Object value
)
```

#### Parameters

##### *key*
Type: [System.String][2]  
Claim key

##### *required*
Type: [System.Boolean][3]  
Is claim essential

##### *value*
Type: [System.Object][4]  
Claim value


See Also
--------

#### Reference
[ClaimsDictionary Class][5]  
[GSMA.MobileConnect.Claims Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/a28wyd50
[4]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[5]: README.md
[6]: ../../_icons/Help.png