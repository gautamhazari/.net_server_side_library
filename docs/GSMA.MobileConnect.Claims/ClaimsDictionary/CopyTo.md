ClaimsDictionary.CopyTo Method
==============================
Copies the elements of the [ICollection&lt;T>][1] to an [Array][2], starting at a particular [Array][2] index.

**Namespace:** [GSMA.MobileConnect.Claims][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public void CopyTo(
	KeyValuePair<string, ClaimsValue>[] array,
	int arrayIndex
)
```

#### Parameters

##### *array*
Type: [System.Collections.Generic.KeyValuePair][4]&lt;[String][5], [ClaimsValue][6]>[]  
The one-dimensional [Array][2] that is the destination of the elements copied from [ICollection&lt;T>][1]. The [Array][2] must have zero-based indexing.

##### *arrayIndex*
Type: [System.Int32][7]  
The zero-based index in *array* at which copying begins.

#### Implements
[ICollection&lt;T>.CopyTo(T[], Int32)][8]  


Exceptions
----------

Exception                         | Condition                                                                                                                                                
--------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------- 
[ArgumentNullException][9]        | *array* is null.                                                                                                                                         
[ArgumentOutOfRangeException][10] | *arrayIndex* is less than 0.                                                                                                                             
[ArgumentException][11]           | The number of elements in the source [ICollection&lt;T>][1] is greater than the available space from *arrayIndex* to the end of the destination *array*. 


See Also
--------

#### Reference
[ClaimsDictionary Class][12]  
[GSMA.MobileConnect.Claims Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/92t2ye13
[2]: http://msdn.microsoft.com/en-us/library/czz5hkty
[3]: ../README.md
[4]: http://msdn.microsoft.com/en-us/library/5tbh8a42
[5]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[6]: ../ClaimsValue/README.md
[7]: http://msdn.microsoft.com/en-us/library/td2s409d
[8]: http://msdn.microsoft.com/en-us/library/0efx51xw
[9]: http://msdn.microsoft.com/en-us/library/27426hcy
[10]: http://msdn.microsoft.com/en-us/library/8xt94y6e
[11]: http://msdn.microsoft.com/en-us/library/3w1b3114
[12]: README.md
[13]: ../../_icons/Help.png