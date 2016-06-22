ParsedDiscoveryRedirect Class
=============================
Class to hold details parsed from the discovery redirect


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Discovery.ParsedDiscoveryRedirect**  

**Namespace:** [GSMA.MobileConnect.Discovery][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class ParsedDiscoveryRedirect
```

The **ParsedDiscoveryRedirect** type exposes the following members.


Constructors
------------

                 | Name                         | Description                                                          
---------------- | ---------------------------- | -------------------------------------------------------------------- 
![Public method] | [ParsedDiscoveryRedirect][3] | Creates a ParsedDiscoveryRedirect instance with the specified values 


Properties
----------

                   | Name                 | Description                                      
------------------ | -------------------- | ------------------------------------------------ 
![Public property] | [EncryptedMSISDN][4] | The encrypted MSISDN is specified                
![Public property] | [HasMCCAndMNC][5]    | Returns true if data exists for MCC and MNC      
![Public property] | [SelectedMCC][6]     | The Mobile Country Code of the selected operator 
![Public property] | [SelectedMNC][7]     | The Mobile Network Code of the selected operator 


See Also
--------

#### Reference
[GSMA.MobileConnect.Discovery Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: EncryptedMSISDN.md
[5]: HasMCCAndMNC.md
[6]: SelectedMCC.md
[7]: SelectedMNC.md
[8]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"