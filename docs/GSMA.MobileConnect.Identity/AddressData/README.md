AddressData Class
=================
Stores data related to an Address Claim received from UserInfo/PremiumInfo


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Identity.AddressData**  

**Namespace:** [GSMA.MobileConnect.Identity][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class AddressData
```

The **AddressData** type exposes the following members.


Constructors
------------

                 | Name             | Description                                             
---------------- | ---------------- | ------------------------------------------------------- 
![Public method] | [AddressData][3] | Initializes a new instance of the **AddressData** class 


Properties
----------

                   | Name               | Description                                                                                                                                                                                                               
------------------ | ------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [Country][4]       | Country name                                                                                                                                                                                                              
![Public property] | [Formatted][5]     | Full mailing address, formatted for display or use on a mailing label. May contain multiple lines, separated by newlines (either "\r\n" or "\n")                                                                          
![Public property] | [Locality][6]      | City or locality                                                                                                                                                                                                          
![Public property] | [PostalCode][7]    | Zip or postal code                                                                                                                                                                                                        
![Public property] | [Region][8]        | State, province, prefecture or region                                                                                                                                                                                     
![Public property] | [StreetAddress][9] | Full street address component, which MAY include house number, street name, Post Office Box and multi line extended street address information. May contain multiple lines, separated by newlines (either "\r\n" or "\n") 


See Also
--------

#### Reference
[GSMA.MobileConnect.Identity Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: Country.md
[5]: Formatted.md
[6]: Locality.md
[7]: PostalCode.md
[8]: Region.md
[9]: StreetAddress.md
[10]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"