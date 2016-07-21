GSMA.MobileConnect.Identity Namespace
=====================================

[Missing &lt;summary> documentation for "N:GSMA.MobileConnect.Identity"]



Classes
-------

                | Class                 | Description                                                                                                                                                                                                                                                                                                                                                              
--------------- | --------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public class] | [AddressData][1]      | Stores data related to an Address Claim received from UserInfo/PremiumInfo                                                                                                                                                                                                                                                                                               
![Public class] | [IdentityData][2]     | Class containing properties for all available Mobile Connect Identity Claims, can be used to retrieve [ResponseJson][3] as a concrete object. Use the [ResponseDataAs&lt;T>()][4] method with this type as the parameter T. Alternatively a leaner type or type with additional custom properties can be provided for more control over the deserialization process.     
![Public class] | [IdentityResponse][5] | Class to hold response from UserInfo service                                                                                                                                                                                                                                                                                                                             
![Public class] | [IdentityService][6]  | Implementation of [IIdentityService][7] interface                                                                                                                                                                                                                                                                                                                        
![Public class] | [UserInfoData][8]     | Class containing properties for all available openid connect 1.0 UserInfo claims, can be used to retrieve [ResponseJson][3] as a concrete object. Use the [ResponseDataAs&lt;T>()][4] method with this type as the parameter T. Alternatively a leaner type or type with additional custom properties can be provided for more control over the deserialization process. 


Interfaces
----------

                    | Interface             | Description                                                         
------------------- | --------------------- | ------------------------------------------------------------------- 
![Public interface] | [IIdentityService][7] | Interface for Mobile Connect UserInfo and Identity related requests 

[1]: AddressData/README.md
[2]: IdentityData/README.md
[3]: IdentityResponse/ResponseJson.md
[4]: IdentityResponse/ResponseDataAs__1.md
[5]: IdentityResponse/README.md
[6]: IdentityService/README.md
[7]: IIdentityService/README.md
[8]: UserInfoData/README.md
[9]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public interface]: ../_icons/pubinterface.gif "Public interface"