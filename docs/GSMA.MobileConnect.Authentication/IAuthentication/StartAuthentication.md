IAuthentication.StartAuthentication Method
==========================================
Generates an authorisation url based on the supplied options and previous discovery response

**Namespace:** [GSMA.MobileConnect.Authentication][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
StartAuthenticationResponse StartAuthentication(
	string clientId,
	string authorizeUrl,
	string redirectUrl,
	string state,
	string nonce,
	string scope,
	Nullable<int> maxAge,
	string acrValues,
	string encryptedMSISDN,
	AuthenticationOptions options
)
```

#### Parameters

##### *clientId*
Type: [System.String][2]  
The registered application ClientId (Required)

##### *authorizeUrl*
Type: [System.String][2]  
The authorization url returned by the discovery process (Required)

##### *redirectUrl*
Type: [System.String][2]  
On completion or error where the result information is sent using a HTTP 302 redirect (Required)

##### *state*
Type: [System.String][2]  
Application specified unique scope value

##### *nonce*
Type: [System.String][2]  
Application specified nonce value. (Required)

##### *scope*
Type: [System.String][2]  
Requested scope. If omitted or empty defaults to the value "openid"

##### *maxAge*
Type: [System.Nullable][3]&lt;[Int32][4]>  
Requested maximum time in seconds since last user authentication. If omitted or empty defaults to the value 3600

##### *acrValues*
Type: [System.String][2]  
Requested Authentication Context class Reference. If omitted or empty defaults to the value "2"

##### *encryptedMSISDN*
Type: [System.String][2]  
Encrypted MSISDN for user if returned from discovery service

##### *options*
Type: [GSMA.MobileConnect.Authentication.AuthenticationOptions][5]  
Optional parameters

#### Return Value
Type: [StartAuthenticationResponse][6]  

[Missing &lt;returns> documentation for "M:GSMA.MobileConnect.Authentication.IAuthentication.StartAuthentication(System.String,System.String,System.String,System.String,System.String,System.String,System.Nullable{System.Int32},System.String,System.String,GSMA.MobileConnect.Authentication.AuthenticationOptions)"]


See Also
--------

#### Reference
[IAuthentication Interface][7]  
[GSMA.MobileConnect.Authentication Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/b3h38hb0
[4]: http://msdn.microsoft.com/en-us/library/td2s409d
[5]: ../AuthenticationOptions/README.md
[6]: ../StartAuthenticationResponse/README.md
[7]: README.md
[8]: ../../_icons/Help.png