UserInfoData Class
==================
Class containing properties for all available openid connect 1.0 UserInfo claims, can be used to retrieve [ResponseJson][1] as a concrete object. Use the [ResponseDataAs&lt;T>()][2] method with this type as the parameter T. Alternatively a leaner type or type with additional custom properties can be provided for more control over the deserialization process.


Inheritance Hierarchy
---------------------
[System.Object][3]  
  **GSMA.MobileConnect.Identity.UserInfoData**  

**Namespace:** [GSMA.MobileConnect.Identity][4]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class UserInfoData
```

The **UserInfoData** type exposes the following members.


Constructors
------------

                 | Name              | Description                                              
---------------- | ----------------- | -------------------------------------------------------- 
![Public method] | [UserInfoData][5] | Initializes a new instance of the **UserInfoData** class 


Properties
----------

                   | Name                      | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
------------------ | ------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public property] | [Address][6]              | End-User's preferred postal address.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
![Public property] | [Birthdate][7]            | End-User's birthday in ISO Date format, the year may be omitted in which case the year will be specified as 0000, the month and day may also be omitted in which case the year will be the only component returned                                                                                                                                                                                                                                                                                                                                                
![Public property] | [Email][8]                | End-User's preferred e-mail address. Its value MUST conform to the RFC 5322 [RFC5322] addr-spec syntax. The RP MUST NOT rely upon this value being unique, as discussed in open-id-connect-core-1_0 Section 5.7                                                                                                                                                                                                                                                                                                                                                   
![Public property] | [EmailVerified][9]        | True if the End-User's e-mail address has been verified; otherwise false. When this Claim Value is true, this means that the OP took affirmative steps to ensure that this e-mail address was controlled by the End-User at the time the verification was performed. The means by which an e-mail address is verified is context-specific, and dependent upon the trust framework or contractual agreements within which the parties are operating.                                                                                                               
![Public property] | [FamilyName][10]          | Surname(s) or last name(s) of the End-User. Note that in some cultures, people can have multiple family names or no family name; all can be present with the names being separated by space characters                                                                                                                                                                                                                                                                                                                                                            
![Public property] | [Gender][11]              | End-User's gender. Values defined by this specification are female and male. Other values MAY be used when neither of the defined values are applicable.                                                                                                                                                                                                                                                                                                                                                                                                          
![Public property] | [GivenName][12]           | Given name(s) or first name(s) of the End-User. Note that in some cultures, people can have multiple given names; all can be present, with the names being separated by space characters                                                                                                                                                                                                                                                                                                                                                                          
![Public property] | [Locale][13]              | End-User's locale, represented as a BCP47 [RFC5646] language tag. This is typically an ISO 639-1 Alpha-2 [ISO639‑1] language code in lowercase and an ISO 3166-1 Alpha-2 [ISO3166‑1] country code in uppercase, separated by a dash. For example, en-US or fr-CA. As a compatibility note, some implementations have used an underscore as the separator rather than a dash, for example, en_US; Relying Parties MAY choose to accept this locale syntax as well.                                                                                                 
![Public property] | [MiddleName][14]          | Middle name(s) of the End-User. Note that in some cultures, people can have multiple middle names; all can be present, with the names being separated by space characters                                                                                                                                                                                                                                                                                                                                                                                         
![Public property] | [Name][15]                | End-User's full name in a displayable form including all name parts, possibly including titles and suffixes, ordered according to the End-User's locale and preferences.                                                                                                                                                                                                                                                                                                                                                                                          
![Public property] | [Nickname][16]            | Casual name of the End-User that may or may not be the same as the [GivenName][12]. For instance a Nickname value of Mike may return alongside a [GivenName][12] of Michael                                                                                                                                                                                                                                                                                                                                                                                       
![Public property] | [PhoneNumber][17]         | End-User's preferred telephone number. E.164 [E.164] is RECOMMENDED as the format of this Claim, for example, +1 (425) 555-1212 or +56 (2) 687 2400. If the phone number contains an extension, it is RECOMMENDED that the extension be represented using the RFC 3966 [RFC3966] extension syntax, for example, +1 (604) 555-1234;ext=5678.                                                                                                                                                                                                                       
![Public property] | [PhoneNumberVerified][18] | True if the End-User's phone number has been verified; otherwise false. When this Claim Value is true, this means that the OP took affirmative steps to ensure that this phone number was controlled by the End-User at the time the verification was performed. The means by which a phone number is verified is context-specific, and dependent upon the trust framework or contractual agreements within which the parties are operating. When true, the phone_number Claim MUST be in E.164 format and any extensions MUST be represented in RFC 3966 format. 
![Public property] | [Picture][19]             | URL of the End-User's profile picture. This URL MUST refer to an image file (for example, a PNG, JPEG, or GIF image file), rather than to a Web page containing an image. Note that this URL SHOULD specifically reference a profile photo of the End-User suitable for displaying when describing the End-User, rather than an arbitrary photo taken by the End-User.                                                                                                                                                                                            
![Public property] | [PreferredUsername][20]   | Shorthand name by which the End-User wishes to be referred to at the RP, such as janedoe or j.doe. This value MAY be any valid JSON string including special characters such as @, /, or whitespace. The RP MUST NOT rely upon this value being unique, as discussed in open-id-connect-core-1_0 Section 5.7                                                                                                                                                                                                                                                      
![Public property] | [Profile][21]             | URL of the End-User's profile page. The contents of this Web page SHOULD be about the End-User.                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
![Public property] | [Sub][22]                 | Subject - Identifier for the End-User at the Issuer                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
![Public property] | [UpdatedAt][23]           | Time the End-User's information was last updated in UTC time                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
![Public property] | [Website][24]             | URL of the End-User's Web page or blog. This Web page SHOULD contain information published by the End-User or an organization that the End-User is affiliated with.                                                                                                                                                                                                                                                                                                                                                                                               
![Public property] | [ZoneInfo][25]            | String from zoneinfo time zone database representing the End-User's time zone. For example, Europe/Paris or America/Los_Angeles.                                                                                                                                                                                                                                                                                                                                                                                                                                  


See Also
--------

#### Reference
[GSMA.MobileConnect.Identity Namespace][4]  
[GSMA.MobileConnect.Identity.IdentityResponse][26]  

[1]: ../IdentityResponse/ResponseJson.md
[2]: ../IdentityResponse/ResponseDataAs__1.md
[3]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[4]: ../README.md
[5]: _ctor.md
[6]: Address.md
[7]: Birthdate.md
[8]: Email.md
[9]: EmailVerified.md
[10]: FamilyName.md
[11]: Gender.md
[12]: GivenName.md
[13]: Locale.md
[14]: MiddleName.md
[15]: Name.md
[16]: Nickname.md
[17]: PhoneNumber.md
[18]: PhoneNumberVerified.md
[19]: Picture.md
[20]: PreferredUsername.md
[21]: Profile.md
[22]: Sub.md
[23]: UpdatedAt.md
[24]: Website.md
[25]: ZoneInfo.md
[26]: ../IdentityResponse/README.md
[27]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"