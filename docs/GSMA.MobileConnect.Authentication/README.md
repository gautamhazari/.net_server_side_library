GSMA.MobileConnect.Authentication Namespace
===========================================
This namespace contains classes pertaining to the Authentication steps of the MobileConnect process


Classes
-------

                | Class                            | Description                                                                                                                                                
--------------- | -------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public class] | [AuthenticationOptions][1]       | Holds required and optional options for [StartAuthentication(String, String, String, String, String, String, SupportedVersions, AuthenticationOptions)][2] 
![Public class] | [AuthenticationService][3]       | Concrete implementation of [IAuthenticationService][4]                                                                                                     
![Public class] | [RequestTokenResponse][5]        | Class to hold the response of [RequestTokenAsync(String, String, String, String, String)][6] Will contain either an error response or request data         
![Public class] | [RequestTokenResponseData][7]    | A class that holds a valid response from [RequestTokenAsync(String, String, String, String, String)][6]                                                    
![Public class] | [StartAuthenticationResponse][8] | Class to hold the response from [StartAuthentication(String, String, String, String, String, String, SupportedVersions, AuthenticationOptions)][2]         


Interfaces
----------

                    | Interface                   | Description                               
------------------- | --------------------------- | ----------------------------------------- 
![Public interface] | [IAuthenticationService][4] | Interface for the Mobile Connect Requests 

[1]: AuthenticationOptions/README.md
[2]: IAuthenticationService/StartAuthentication.md
[3]: AuthenticationService/README.md
[4]: IAuthenticationService/README.md
[5]: RequestTokenResponse/README.md
[6]: IAuthenticationService/RequestTokenAsync.md
[7]: RequestTokenResponseData/README.md
[8]: StartAuthenticationResponse/README.md
[9]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public interface]: ../_icons/pubinterface.gif "Public interface"