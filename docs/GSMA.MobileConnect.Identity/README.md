GSMA.MobileConnect.Identity Namespace
=====================================

[Missing &lt;summary> documentation for "N:GSMA.MobileConnect.Identity"]



Classes
-------

                | Class                 | Description                                                                                                                                                                                                                                                                                                                                                              
--------------- | --------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
![Public class] | [AddressData][1]      | Stores data related to an Address Claim received from UserInfo/PremiumInfo                                                                                                                                                                                                                                                                                               
![Public class] | [IdentityService][2]  | Implementation of [IIdentityService][3] interface                                                                                                                                                                                                                                                                                                                        
![Public class] | [UserInfoData][4]     | Class containing properties for all available openid connect 1.0 UserInfo claims, can be used to retrieve [ResponseJson][5] as a concrete object. Use the [ResponseDataAs&lt;T>()][6] method with this type as the parameter T. Alternatively a leaner type or type with additional custom properties can be provided for more control over the deserialization process. 
![Public class] | [UserInfoResponse][7] | Class to hold response from UserInfo service                                                                                                                                                                                                                                                                                                                             


Interfaces
----------

                    | Interface             | Description                                                         
------------------- | --------------------- | ------------------------------------------------------------------- 
![Public interface] | [IIdentityService][3] | Interface for Mobile Connect UserInfo and Identity related requests 

[1]: AddressData/README.md
[2]: IdentityService/README.md
[3]: IIdentityService/README.md
[4]: UserInfoData/README.md
[5]: UserInfoResponse/ResponseJson.md
[6]: UserInfoResponse/ResponseDataAs__1.md
[7]: UserInfoResponse/README.md
[8]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public interface]: ../_icons/pubinterface.gif "Public interface"