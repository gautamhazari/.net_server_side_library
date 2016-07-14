ClaimsDictionary.Add Method (KeyValuePair&lt;String, ClaimsValue>)
==================================================================
Adds an item to the [ICollection&lt;T>][1].

**Namespace:** [GSMA.MobileConnect.Claims][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public void Add(
	KeyValuePair<string, ClaimsValue> item
)
```

#### Parameters

##### *item*
Type: [System.Collections.Generic.KeyValuePair][3]&lt;[String][4], [ClaimsValue][5]>  
The object to add to the [ICollection&lt;T>][1].

#### Implements
[ICollection&lt;T>.Add(T)][6]  


Exceptions
----------

Exception                  | Condition                                
-------------------------- | ---------------------------------------- 
[NotSupportedException][7] | The [ICollection&lt;T>][1] is read-only. 


See Also
--------

#### Reference
[ClaimsDictionary Class][8]  
[GSMA.MobileConnect.Claims Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/92t2ye13
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/5tbh8a42
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../ClaimsValue/README.md
[6]: http://msdn.microsoft.com/en-us/library/63ywd54z
[7]: http://msdn.microsoft.com/en-us/library/8a7a4e64
[8]: README.md
[9]: ../../_icons/Help.png