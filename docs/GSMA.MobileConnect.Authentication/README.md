GSMA.MobileConnect.Authentication Namespace
===========================================
This namespace contains classes pertaining to the Authentication steps of the MobileConnect process


Classes
-------

                | Class                            | Description                                                                                                                                                                  
--------------- | -------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public class] | [Authentication][1]              | Concrete implementation of [IAuthentication][2]                                                                                                                              
![Public class] | [AuthenticationOptions][3]       | Holds required and optional options for [!:IAuthentication.StartAuthentication(string, string, string, string, string, string, string, AuthenticationOptions)]               
![Public class] | [RequestTokenResponse][4]        | Class to hold the response of [RequestTokenAsync(String, String, String, String, String)][5] Will contain either an error response or request data                           
![Public class] | [RequestTokenResponseData][6]    | A class that holds a valid response from [RequestTokenAsync(String, String, String, String, String)][5]                                                                      
![Public class] | [StartAuthenticationResponse][7] | Class to hold the response from [!:IAuthentication.StartAuthentication(string, string, string, string, string, string, int?, string, string, string, AuthenticationOptions)] 


Interfaces
----------

                    | Interface            | Description                               
------------------- | -------------------- | ----------------------------------------- 
![Public interface] | [IAuthentication][2] | Interface for the Mobile Connect Requests 

[1]: Authentication/README.md
[2]: IAuthentication/README.md
[3]: AuthenticationOptions/README.md
[4]: RequestTokenResponse/README.md
[5]: IAuthentication/RequestTokenAsync.md
[6]: RequestTokenResponseData/README.md
[7]: StartAuthenticationResponse/README.md
[8]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public interface]: ../_icons/pubinterface.gif "Public interface"