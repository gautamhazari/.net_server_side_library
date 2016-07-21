IdentityService.RequestUserInfo Method
======================================
Request the user info for the provided access token. Some of the information returned by the user info service requires the authorization/authentication to be executed with additional scope values e.g. email => openid email

**Namespace:** [GSMA.MobileConnect.Identity][1]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public Task<IdentityResponse> RequestUserInfo(
	string userInfoUrl,
	string accessToken
)
```

#### Parameters

##### *userInfoUrl*
Type: [System.String][2]  
Url for accessing user info (Returned in discovery response)

##### *accessToken*
Type: [System.String][2]  
Access token for authorising user info request

#### Return Value
Type: [Task][3]&lt;[IdentityResponse][4]>  
UserInfo object if request succeeds
#### Implements
[IIdentityService.RequestUserInfo(String, String)][5]  


See Also
--------

#### Reference
[IdentityService Class][6]  
[GSMA.MobileConnect.Identity Namespace][1]  

[1]: ../README.md
[2]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[3]: http://msdn.microsoft.com/en-us/library/dd321424
[4]: ../IdentityResponse/README.md
[5]: ../IIdentityService/RequestUserInfo.md
[6]: README.md
[7]: ../../_icons/Help.png