ClaimsDictionary.ContainsKey Method
===================================
Determines whether the [IDictionary&lt;TKey, TValue>][1] contains an element with the specified key.

**Namespace:** [GSMA.MobileConnect.Claims][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public bool ContainsKey(
	string key
)
```

#### Parameters

##### *key*
Type: [System.String][3]  
The key to locate in the [IDictionary&lt;TKey, TValue>][1].

#### Return Value
Type: [Boolean][4]  
true if the [IDictionary&lt;TKey, TValue>][1] contains an element with the key; otherwise, false.
#### Implements
[IDictionary&lt;TKey, TValue>.ContainsKey(TKey)][5]  


Exceptions
----------

Exception                  | Condition      
-------------------------- | -------------- 
[ArgumentNullException][6] | *key* is null. 


See Also
--------

#### Reference
[ClaimsDictionary Class][7]  
[GSMA.MobileConnect.Claims Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/s4ys34ea
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/a28wyd50
[5]: http://msdn.microsoft.com/en-us/library/htszx2dy
[6]: http://msdn.microsoft.com/en-us/library/27426hcy
[7]: README.md
[8]: ../../_icons/Help.png