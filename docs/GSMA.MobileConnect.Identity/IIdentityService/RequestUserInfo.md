IIdentityService.RequestUserInfo Method (String, String, ClaimsParameter)
=========================================================================
Convenience method alternative to [RequestUserInfo(String, String, String)][1] so claims can be specified using a ClaimsParameter which will be serialized to JSON

**Namespace:** [GSMA.MobileConnect.Identity][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
Task<UserInfoResponse> RequestUserInfo(
	string userInfoUrl,
	string accessToken,
	ClaimsParameter claims
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
Type: [GSMA.MobileConnect.Claims.ClaimsParameter][4]  
Claims parameter with requested claims (optional)

#### Return Value
Type: [Task][5]&lt;[UserInfoResponse][6]>  
UserInfo object if request succeeds

See Also
--------

#### Reference
[IIdentityService Interface][7]  
[GSMA.MobileConnect.Identity Namespace][2]  

[1]: RequestUserInfo_1.md
[2]: ../README.md
[3]: http://msdn.microsoft.com/en-us/library/s1wwdcbf
[4]: ../../GSMA.MobileConnect.Claims/ClaimsParameter/README.md
[5]: http://msdn.microsoft.com/en-us/library/dd321424
[6]: ../UserInfoResponse/README.md
[7]: README.md
[8]: ../../_icons/Help.png