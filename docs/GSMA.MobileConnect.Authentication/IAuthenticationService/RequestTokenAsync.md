IAuthenticationService.RequestTokenAsync Method
===============================================
Allows an application to use the authorization code obtained from authentication/authorization to obtain an access token and related information from the authorization server.

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
Task<RequestTokenResponse> RequestTokenAsync(
	string clientId,
	string clientSecret,
	string requestTokenUrl,
	string redirectUrl,
	string code
)
```

#### Parameters

##### *clientId*
Type: [System.String][2]  
The registered application ClientId (Required)

##### *clientSecret*
Type: [System.String][2]  
The registered application ClientSecret (Required)

##### *requestTokenUrl*
Type: [System.String][2]  
The url for token requests recieved from the discovery process (Required)

##### *redirectUrl*
Type: [System.String][2]  
Confirms the redirectURI that the application used when the authorization request (Required)

##### *code*
Type: [System.String][2]  
The authorization code provided to the application via the call to the authentication/authorization API (Required)

#### Return Value
Type: [Task][3]&lt;[RequestTokenResponse][4]>  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Authentication.IAuthenticationService.RequestTokenAsync(System.String,System.String,System.String,System.String,System.String)"]


Remarks
-------
 This function requires a valid token url from the discovery process and a valid code from the initial authorization call 

See Also
--------

#### Reference
[IAuthenticationService Interface][5]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: ../RequestTokenResponse/README.md
[5]: README.md
[6]: ../../_icons/Help.png