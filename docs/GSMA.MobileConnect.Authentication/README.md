GSMA.MobileConnect.Authentication Namespace
===========================================
This namespace contains classes pertaining to the Authentication steps of the MobileConnect process


Classes
-------

                | Class                            | Description                                                                                                                                                                         
--------------- | -------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public class] | [Authentication][1]              | Concrete implementation of [IAuthentication][2]                                                                                                                                     
![Public class] | [AuthenticationOptions][3]       | Holds required and optional options for [StartAuthentication(String, String, String, String, String, String, Nullable&lt;Int32>, String, String, String, AuthenticationOptions)][4] 
![Public class] | [RequestTokenResponse][5]        | Class to hold the response of [RequestTokenAsync(String, String, String, String, String)][6] Will contain either an error response or request data                                  
![Public class] | [RequestTokenResponseData][7]    | A class that holds a valid response from [RequestTokenAsync(String, String, String, String, String)][6]                                                                             
![Public class] | [StartAuthenticationResponse][8] | Class to hold the response from [StartAuthentication(String, String, String, String, String, String, Nullable&lt;Int32>, String, String, String, AuthenticationOptions)][4]         


Interfaces
----------

                    | Interface            | Description                               
------------------- | -------------------- | ----------------------------------------- 
![Public interface] | [IAuthentication][2] | Interface for the Mobile Connect Requests 

[1]: Authentication/README.md
[2]: IAuthentication/README.md
[3]: AuthenticationOptions/README.md
[4]: IAuthentication/StartAuthentication.md
[5]: RequestTokenResponse/README.md
[6]: IAuthentication/RequestTokenAsync.md
[7]: RequestTokenResponseData/README.md
[8]: StartAuthenticationResponse/README.md
[9]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public interface]: ../_icons/pubinterface.gif "Public interface"