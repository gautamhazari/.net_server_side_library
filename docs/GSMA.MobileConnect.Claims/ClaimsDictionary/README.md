ClaimsDictionary Class
======================
JSON Serializable class to store configured claims values for use with mobile connect methods


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Claims.ClaimsDictionary**  

**Namespace:** [GSMA.MobileConnect.Claims][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class ClaimsDictionary : IDictionary<string, ClaimsValue>, 
	ICollection<KeyValuePair<string, ClaimsValue>>, IEnumerable<KeyValuePair<string, ClaimsValue>>, 
	IEnumerable
```

The **ClaimsDictionary** type exposes the following members.


Constructors
------------

                 | Name                  | Description                                                  
---------------- | --------------------- | ------------------------------------------------------------ 
![Public method] | [ClaimsDictionary][3] | Initializes a new instance of the **ClaimsDictionary** class 


Properties
----------

                   | Name            | Description                                                                                    
------------------ | --------------- | ---------------------------------------------------------------------------------------------- 
![Public property] | [Count][4]      | Gets the number of elements contained in the [ICollection&lt;T>][5].                           
![Public property] | [IsReadOnly][6] | Gets a value indicating whether the [ICollection&lt;T>][5] is read-only.                       
![Public property] | [Item][7]       | Get or set claim value at specified key                                                        
![Public property] | [Keys][8]       | Gets an [ICollection&lt;T>][5] containing the keys of the [IDictionary&lt;TKey, TValue>][9].   
![Public property] | [Values][10]    | Gets an [ICollection&lt;T>][5] containing the values in the [IDictionary&lt;TKey, TValue>][9]. 


Methods
-------

                 | Name                                               | Description                                                                                                                                                                    
---------------- | -------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public method] | [Add(KeyValuePair&lt;String, ClaimsValue>)][11]    | Adds an item to the [ICollection&lt;T>][5].                                                                                                                                    
![Public method] | [Add(String)][12]                                  | Add a voluntary claim with the specified key                                                                                                                                   
![Public method] | [Add(String, ClaimsValue)][13]                     | Add a claim value with the specified key                                                                                                                                       
![Public method] | [AddRequired][14]                                  | Add a required claim with the specified key                                                                                                                                    
![Public method] | [AddWithValue][15]                                 | Add a claim with the specified key and value. When claims are sent to a method that accepts them the response will only contain the claim if the values match.                 
![Public method] | [AddWithValues][16]                                | Add a claim with the specified key and values. When claims are sent to a method that accepts them the response will only contain the claim if the value is in the values list. 
![Public method] | [Clear][17]                                        | Removes all items from the [ICollection&lt;T>][5].                                                                                                                             
![Public method] | [Contains][18]                                     | Determines whether the [ICollection&lt;T>][5] contains a specific value.                                                                                                       
![Public method] | [ContainsKey][19]                                  | Determines whether the [IDictionary&lt;TKey, TValue>][9] contains an element with the specified key.                                                                           
![Public method] | [CopyTo][20]                                       | Copies the elements of the [ICollection&lt;T>][5] to an [Array][21], starting at a particular [Array][21] index.                                                               
![Public method] | [GetEnumerator][22]                                | Returns an enumerator that iterates through the collection.                                                                                                                    
![Public method] | [Remove(KeyValuePair&lt;String, ClaimsValue>)][23] | Removes the first occurrence of a specific object from the [ICollection&lt;T>][5].                                                                                             
![Public method] | [Remove(String)][24]                               | Removes the element with the specified key from the [IDictionary&lt;TKey, TValue>][9].                                                                                         
![Public method] | [TryGetValue][25]                                  | Gets the value associated with the specified key.                                                                                                                              


Explicit Interface Implementations
----------------------------------

                                                      | Name                            | Description                                               
----------------------------------------------------- | ------------------------------- | --------------------------------------------------------- 
![Explicit interface implementation]![Private method] | [IEnumerable.GetEnumerator][26] | Returns an enumerator that iterates through a collection. 


See Also
--------

#### Reference
[GSMA.MobileConnect.Claims Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: Count.md
[5]: http://msdn.microsoft.com/en-us/library/92t2ye13
[6]: IsReadOnly.md
[7]: Item.md
[8]: Keys.md
[9]: http://msdn.microsoft.com/en-us/library/s4ys34ea
[10]: Values.md
[11]: Add.md
[12]: Add_1.md
[13]: Add_2.md
[14]: AddRequired.md
[15]: AddWithValue.md
[16]: AddWithValues.md
[17]: Clear.md
[18]: Contains.md
[19]: ContainsKey.md
[20]: CopyTo.md
[21]: http://msdn.microsoft.com/en-us/library/czz5hkty
[22]: GetEnumerator.md
[23]: Remove.md
[24]: Remove_1.md
[25]: TryGetValue.md
[26]: System_Collections_IEnumerable_GetEnumerator.md
[27]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"
[Explicit interface implementation]: ../../_icons/pubinterface.gif "Explicit interface implementation"
[Private method]: ../../_icons/privmethod.gif "Private method"