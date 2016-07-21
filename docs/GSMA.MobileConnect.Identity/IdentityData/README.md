IdentityData Class
==================
Class containing properties for all available Mobile Connect Identity Claims, can be used to retrieve [ResponseJson][1] as a concrete object. Use the [ResponseDataAs&lt;T>()][2] method with this type as the parameter T. Alternatively a leaner type or type with additional custom properties can be provided for more control over the deserialization process.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **GSMA.MobileConnect.Identity.IdentityData**  

**Namespace:** [GSMA.MobileConnect.Identity][4]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class IdentityData
```

The **IdentityData** type exposes the following members.


Constructors
------------

                 | Name              | Description                                              
---------------- | ----------------- | -------------------------------------------------------- 
![Public method] | [IdentityData][5] | Initializes a new instance of the **IdentityData** class 


Properties
----------

                   | Name                       | Description                                                                                                                          
------------------ | -------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ 
![Public property] | [BirthDate][6]             | User's birthdate                                                                                                                     
![Public property] | [City][7]                  | User's city                                                                                                                          
![Public property] | [Country][8]               | User's postal country                                                                                                                
![Public property] | [Email][9]                 | User's email                                                                                                                         
![Public property] | [FamilyName][10]           | Family name(s)                                                                                                                       
![Public property] | [GivenName][11]            | Given name(s)                                                                                                                        
![Public property] | [MiddleName][12]           | Middle name(s)                                                                                                                       
![Public property] | [NationalIdentifier][13]   | User’s Identifier (eIDAS), any national identifier like Social Security Identifier, passport etc. (depends on the local regulations) 
![Public property] | [PhoneNumber][14]          | User's Mobile Connect designated mobile number                                                                                       
![Public property] | [PhoneNumberAlternate][15] | User's alternate/secondary telephone number                                                                                          
![Public property] | [PostalCode][16]           | User's Zip/Postcode                                                                                                                  
![Public property] | [State][17]                | User's State/County                                                                                                                  
![Public property] | [StreetAddress][18]        | User's street (incl. house name/number)                                                                                              
![Public property] | [Sub][19]                  | Subject - Identifier for the End-User at the Issuer                                                                                  
![Public property] | [Title][20]                | Users salutation/honorific                                                                                                           


See Also
--------

#### Reference
[GSMA.MobileConnect.Identity Namespace][4]  
[GSMA.MobileConnect.Identity.IdentityResponse][21]  

[1]: ../IdentityResponse/ResponseJson.md
[2]: ../IdentityResponse/ResponseDataAs__1.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: _ctor.md
[6]: BirthDate.md
[7]: City.md
[8]: Country.md
[9]: Email.md
[10]: FamilyName.md
[11]: GivenName.md
[12]: MiddleName.md
[13]: NationalIdentifier.md
[14]: PhoneNumber.md
[15]: PhoneNumberAlternate.md
[16]: PostalCode.md
[17]: State.md
[18]: StreetAddress.md
[19]: Sub.md
[20]: Title.md
[21]: ../IdentityResponse/README.md
[22]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"