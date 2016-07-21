IdentityService.RequestIdentity Method
======================================
Request the identity for the provided access token. Information returned by the identity service requires the authorization to be executed with additional scope values e.g. phone number [MOBILECONNECTIDENTITYPHONE][1]

**Namespace:** [GSMA.MobileConnect.Identity][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<IdentityResponse> RequestIdentity(
	string premiumInfoUrl,
	string accessToken
)
```

#### Parameters

##### *premiumInfoUrl*
Type: [System.String][3]  
Url for accessing premium info identity services (Returned in discovery response)

##### *accessToken*
Type: [System.String][3]  
Access token for authorising identity request

#### Return Value
Type: [Task][4]&lt;[IdentityResponse][5]>  
UserInfo object if request succeeds
#### Implements
[IIdentityService.RequestIdentity(String, String)][6]  


See Also
--------

#### Reference
[IdentityService Class][7]  
[GSMA.MobileConnect.Identity Namespace][2]  

[1]: ../../GSMA.MobileConnect/MobileConnectConstants/MOBILECONNECTIDENTITYPHONE.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/dd321424
[5]: ../IdentityResponse/README.md
[6]: ../IIdentityService/RequestIdentity.md
[7]: README.md
[8]: ../../_icons/Help.png