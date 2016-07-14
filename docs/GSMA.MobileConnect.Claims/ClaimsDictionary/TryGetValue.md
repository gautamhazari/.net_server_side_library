ClaimsDictionary.TryGetValue Method
===================================
Gets the value associated with the specified key.

**Namespace:** [GSMA.MobileConnect.Claims][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public bool TryGetValue(
	string key,
	out ClaimsValue value
)
```

#### Parameters

##### *key*
Type: [System.String][2]  
The key whose value to get.

##### *value*
Type: [GSMA.MobileConnect.Claims.ClaimsValue][3]  
When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the *value* parameter. This parameter is passed uninitialized.

#### Return Value
Type: [Boolean][4]  
true if the object that implements [IDictionary&lt;TKey, TValue>][5] contains an element with the specified key; otherwise, false.
#### Implements
[IDictionary&lt;TKey, TValue>.TryGetValue(TKey, TValue)][6]  


Exceptions
----------

Exception                  | Condition      
-------------------------- | -------------- 
[ArgumentNullException][7] | *key* is null. 


See Also
--------

#### Reference
[ClaimsDictionary Class][8]  
[GSMA.MobileConnect.Claims Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: ../ClaimsValue/README.md
[4]: http://msdn.microsoft.com/en-us/library/a28wyd50
[5]: http://msdn.microsoft.com/en-us/library/s4ys34ea
[6]: http://msdn.microsoft.com/en-us/library/bb299639
[7]: http://msdn.microsoft.com/en-us/library/27426hcy
[8]: README.md
[9]: ../../_icons/Help.png