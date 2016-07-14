ClaimsDictionary.Remove Method (KeyValuePair&lt;String, ClaimsValue>)
=====================================================================
Removes the first occurrence of a specific object from the [ICollection&lt;T>][1].

**Namespace:** [GSMA.MobileConnect.Claims][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public bool Remove(
	KeyValuePair<string, ClaimsValue> item
)
```

#### Parameters

##### *item*
Type: [System.Collections.Generic.KeyValuePair][3]&lt;[String][4], [ClaimsValue][5]>  
The object to remove from the [ICollection&lt;T>][1].

#### Return Value
Type: [Boolean][6]  
true if *item* was successfully removed from the [ICollection&lt;T>][1]; otherwise, false. This method also returns false if *item* is not found in the original [ICollection&lt;T>][1].
#### Implements
[ICollection&lt;T>.Remove(T)][7]  


Exceptions
----------

Exception                  | Condition                                
-------------------------- | ---------------------------------------- 
[NotSupportedException][8] | The [ICollection&lt;T>][1] is read-only. 


See Also
--------

#### Reference
[ClaimsDictionary Class][9]  
[GSMA.MobileConnect.Claims Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/92t2ye13
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/5tbh8a42
[4]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[5]: ../ClaimsValue/README.md
[6]: http://msdn.microsoft.com/en-us/library/a28wyd50
[7]: http://msdn.microsoft.com/en-us/library/bye7h94w
[8]: http://msdn.microsoft.com/en-us/library/8a7a4e64
[9]: README.md
[10]: ../../_icons/Help.png