IIdentityService.RequestUserInfo Method (String, String, String)
================================================================
Request the user info for the provided access token. Some of the information returned by the user info service requires the authorization/authentication to be executed with additional scope values e.g. phone number [MOBILECONNECTIDENTITYPHONE][1]

**Namespace:** [GSMA.MobileConnect.Identity][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
Task<UserInfoResponse> RequestUserInfo(
	string userInfoUrl,
	string accessToken,
	string claims
)
```

#### Parameters

##### *userInfoUrl*
Type: [System.String][3]  
Url for accessing user info (Returned in discovery response)

##### *accessToken*
Type: [System.String][3]  
Access token for authorising user info request

##### *claims*
Type: [System.String][3]  
List of claims to request (optional)

#### Return Value
Type: [Task][4]&lt;[UserInfoResponse][5]>  
UserInfo object if request succeeds

See Also
--------

#### Reference
[IIdentityService Interface][6]  
[GSMA.MobileConnect.Identity Namespace][2]  

[1]: ../../GSMA.MobileConnect/MobileConnectConstants/MOBILECONNECTIDENTITYPHONE.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: http://msdn.microsoft.com/en-us/library/dd321424
[5]: ../UserInfoResponse/README.md
[6]: README.md
[7]: ../../_icons/Help.png