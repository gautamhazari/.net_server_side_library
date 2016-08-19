GSMA.MobileConnect.Authentication Namespace
===========================================
This namespace contains classes pertaining to the Authentication steps of the MobileConnect process


Classes
-------

                | Class                             | Description                                                                                                                                                
--------------- | --------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public class] | [AuthenticationOptions][1]        | Holds required and optional options for [StartAuthentication(String, String, String, String, String, String, SupportedVersions, AuthenticationOptions)][2] 
![Public class] | [AuthenticationService][3]        | Concrete implementation of [IAuthenticationService][4]                                                                                                     
![Public class] | [JWKey][5]                        | Represents a cryptographic key that belongs to a JWKeyset                                                                                                  
![Public class] | [JWKeyset][6]                     | JWKS retrieved from the JWKS endpoint                                                                                                                      
![Public class] | [JWKeysetService][7]              | Concrete implementation [IJWKeysetService][8]                                                                                                              
![Public class] | [LoginHint][9]                    | Utility methods for working with login hints for the auth login hint parameter                                                                             
![Public class] | [RequestTokenResponse][10]        | Class to hold the response of [RequestTokenAsync(String, String, String, String, String)][11] Will contain either an error response or request data        
![Public class] | [RequestTokenResponseData][12]    | A class that holds a valid response from [RequestTokenAsync(String, String, String, String, String)][11]                                                   
![Public class] | [StartAuthenticationResponse][13] | Class to hold the response from [StartAuthentication(String, String, String, String, String, String, SupportedVersions, AuthenticationOptions)][2]         
![Public class] | [TokenValidation][14]             | Utility methods for token validation                                                                                                                       
![Public class] | [TokenValidationOptions][15]      | Options for handling token validation                                                                                                                      


Interfaces
----------

                    | Interface                   | Description                                                                  
------------------- | --------------------------- | ---------------------------------------------------------------------------- 
![Public interface] | [IAuthenticationService][4] | Interface for the Mobile Connect Requests                                    
![Public interface] | [IJWKeysetService][8]       | Service for retrieving, caching and managing JWKS keysets for JWT validation 


Enumerations
------------

                      | Enumeration                 | Description                                 
--------------------- | --------------------------- | ------------------------------------------- 
![Public enumeration] | [TokenValidationResult][16] | Enum for available token validation results 

[1]: AuthenticationOptions/README.md
[2]: IAuthenticationService/StartAuthentication.md
[3]: AuthenticationService/README.md
[4]: IAuthenticationService/README.md
[5]: JWKey/README.md
[6]: JWKeyset/README.md
[7]: JWKeysetService/README.md
[8]: IJWKeysetService/README.md
[9]: LoginHint/README.md
[10]: RequestTokenResponse/README.md
[11]: IAuthenticationService/RequestTokenAsync.md
[12]: RequestTokenResponseData/README.md
[13]: StartAuthenticationResponse/README.md
[14]: TokenValidation/README.md
[15]: TokenValidationOptions/README.md
[16]: TokenValidationResult/README.md
[17]: ../_icons/Help.png
[Public class]: ../_icons/pubclass.gif "Public class"
[Public interface]: ../_icons/pubinterface.gif "Public interface"
[Public enumeration]: ../_icons/pubenumeration.gif "Public enumeration"