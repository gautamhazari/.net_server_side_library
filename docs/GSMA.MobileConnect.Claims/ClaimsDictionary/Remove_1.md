ClaimsDictionary.Remove Method (String)
=======================================
Removes the element with the specified key from the [IDictionary&lt;TKey, TValue>][1].

**Namespace:** [GSMA.MobileConnect.Claims][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public bool Remove(
	string key
)
```

#### Parameters

##### *key*
Type: [System.String][3]  
The key of the element to remove.

#### Return Value
Type: [Boolean][4]  
true if the element is successfully removed; otherwise, false. This method also returns false if *key* was not found in the original [IDictionary&lt;TKey, TValue>][1].
#### Implements
[IDictionary&lt;TKey, TValue>.Remove(TKey)][5]  


Exceptions
----------

Exception                  | Condition                                           
-------------------------- | --------------------------------------------------- 
[ArgumentNullException][6] | *key* is null.                                      
[NotSupportedException][7] | The [IDictionary&lt;TKey, TValue>][1] is read-only. 


See Also
--------

#### Reference
[ClaimsDictionary Class][8]  
[GSMA.MobileConnect.Claims Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/s4ys34ea
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/a28wyd50
[5]: http://msdn.microsoft.com/en-us/library/k8s489f0
[6]: http://msdn.microsoft.com/en-us/library/27426hcy
[7]: http://msdn.microsoft.com/en-us/library/8a7a4e64
[8]: README.md
[9]: ../../_icons/Help.png