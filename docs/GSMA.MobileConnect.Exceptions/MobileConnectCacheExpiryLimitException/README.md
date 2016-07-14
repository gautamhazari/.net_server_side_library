MobileConnectCacheExpiryLimitException Class
============================================
Exception raised when a cache expiry time is set to a value outside of the min and max expiry time range


Inheritance Hierarchy
---------------------
[System.Object][1]  
  [System.Exception][2]  
    **GSMA.MobileConnect.Exceptions.MobileConnectCacheExpiryLimitException**  

**Namespace:** [GSMA.MobileConnect.Exceptions][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class MobileConnectCacheExpiryLimitException : Exception
```


Constructors
------------

                 | Name                                                                                            | Description                                                                                                                                                       
---------------- | ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [MobileConnectCacheExpiryLimitException()][4]                                                   | Initializes a new instance of the [Exception][2] class.                                                                                                           
![Public method] | [MobileConnectCacheExpiryLimitException(String)][5]                                             | Initializes a new instance of the [Exception][2] class with a specified error message.                                                                            
![Public method] | [MobileConnectCacheExpiryLimitException(String, Exception)][6]                                  | Initializes a new instance of the [Exception][2] class with a specified error message and a reference to the inner exception that is the cause of this exception. 
![Public method] | [MobileConnectCacheExpiryLimitException(Type, Nullable&lt;TimeSpan>, Nullable&lt;TimeSpan>)][7] | Creates an instance of the class MobileConnectCacheExpiryLimitException with a message detailing the target type and the configured limits for that type          


See Also
--------

#### Reference
[GSMA.MobileConnect.Exceptions Namespace][3]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: http://msdn.microsoft.com/en-us/library/c18k6c59
[3]: ../README.md
[4]: _ctor.md
[5]: _ctor_1.md
[6]: _ctor_2.md
[7]: _ctor_3.md
[8]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"