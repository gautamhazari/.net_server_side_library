# GSMA MobileConnect .Net SDK Demos

- These demos should provide full example code for completing the authorization flow of MobileConnect
- Demo code is only for example purposes



## Recommended Setup

In order to build and run all demo applications the following are required

- Visual Studio 2017 or above
- .NET Framework 4.6

## Getting Started

You must have first registered an account on the [MobileConnect Developer Site](https://developer.mobileconnect.io) and created an application to get your sandbox credentials.

Using the credentials from your account page either replace the credentials in GSMA.Demo.Config.DemoConfiguration or in GSMA.Demo.Config/config.json these will be used across all demo applications.

1. Clone reporitory

2. Open the configuration file: [local path]\mobile-connect-demos\GSMA.MobileConnect.Demo.ServerSide\App_Data\OperatorData.json to pass required parameter values for with discovery mode:

```posh
{
  "clientID": your client Id,
  "clientSecret": your client Secret,
  "clientName": your client Name,
  "discoveryURL": your Discovery endpoint,
  "redirectURL": "<protocol>://<hostname>/server_side_api/discovery_callback",
  "xRedirect": "True",
  "includeRequestIP": "False",
  "apiVersion": api version: "mc_v1.1", "mc_v2.0" or "mc_di_r2_v2.3",
  "scope": scope,
  "acrValues":  acr_values,
  "MaxDiscoveryCacheSize": max cache size
}
```

3. Open the configuration file: [local path]\mobile-connect-demo\src\main\resources\config\OperatorData.json to pass required parameter values for without discovery mode:
```posh
{
  "clientID": your client Id,
  "clientSecret": your client Secret,
  "clientName": your client Name,
  "discoveryURL": your Discovery endpoint,
  "redirectURL": "<protocol>://<hostname>/server_side_api/discovery_callback",
  "xRedirect": "True",
  "includeRequestIP": "True",
  "apiVersion": api version: "mc_v1.1", "mc_v2.0" or "mc_di_r2_v2.3",
  "scope": scope,
  "acrValues": acr_values,
  "MaxDiscoveryCacheSize": max cache size,
  "operatorUrls": {
    "authorizationUrl": authorize endpoint,
    "requestTokenUrl": token endpoint,
    "userInfoUrl": userinfo endpoint,
    "premiumInfoUri": premiuminfo endpoint,
    "providerMetadataUri": provider metadata endpoint
  }
}
```

4. Open sector_identifier_uri.json file and specify the value of sector_identifier_uri with a single JSON array of redirect_uri values.
```posh
["<protocol>://<hostname>/server_side_api/discovery_callback"]
```

5. Download and install any missing dependencies.

6. Build the project. You can configure your application (clientID, clientSecret, discoveryURL, redirectURL). You can also configure your parameters for auth request (xRedirect, . includeRequestIP, apiVersion, scope, acrValues). And You can configure cache size (maxDiscoveryCacheSize) and if you want to run or not to run get user info request and get identity request (userInfo, identity).

7. Run GSMA.MobileConnect.ServerSide.Web or publish using 'Web Deploy' and deploy application to your server using IIS

8. Prepare client side application (IOS or Android application) or Demo App for Server Side application.


## Resources

- [SDK Class Documentation](../docs/README.md)
- [MobileConnect Discovery API Information](https://developer.mobileconnect.io/content/discovery-api-0)
- [MobileConnect Authentication API Information](https://developer.mobileconnect.io/content/mobile-connect-api)
