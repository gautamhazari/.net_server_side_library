GSMA MobileConnect .Net SDK Demo Applications
==============================================================================================================

- Examples of GSMA MobileConnect SDK Integration in .Net applications
- These demos should provide full example code for completing the authorization flow of MobileConnect
- Demo code is only for example purposes

- Though demos only exist for Windows 10 UWP, ASP.NET WebApi 2, WPF and Windows 8.1, the SDK also supports ASP.NET Core 1.0, Windows 8 and Windows Phone 8.1

Getting Started
-----------------
You must have first registered an account on the [MobileConnect Developer Site](https://developer.mobileconnect.io) and created an application to get your sandbox credentials.

Using the credentials from your account page either replace the credentials in GSMA.Demo.Config.DemoConfiguration or in GSMA.Demo.Config/config.json these will be used across all demo applications.

Build and run the applications.

The MobileConnect process is implemented in one file for each application
- GSMA.MobileConnect.Demo.Universal - MainPage.xaml.cs
- GSMA.MobileConnect.Demo.Web - MobileConnectController.cs
- GSMA.MobileConnect.Demo.Win8 - MainPage.xaml.cs
- GSMA.MobileConnect.Demo.Wpf - MainWindow.xaml.cs

Using The SDK
---------------
Install the SDK to your .Net application using [Nuget](https://www.nuget.org/packages/GSMA.MobileConnect)

```posh
Install-Package GSMA.MobileConnect
```

Configure your MobileConnect options using [MobileConnectConfig](Docs/GSMA.MobileConnect/MobileConnectConfig/README.md)

```csharp
var config = new MobileConnectConfig
{
    ClientId = "66742a85-2282-2a85-4747-ed5b76674d2d",
    ClientSecret = "f1519951-b658-e409-9988-e409b6583392",
    RedirectUrl = "http://localhost:8001/mobileconnect.html",
    DiscoveryUrl = "http://discovery.sandbox2.mobileconnect.io/v2/discovery/",
};
```

Use the class corresponding to your application type
- For ASP.NET server applications use [MobileConnectWebInterface](Docs/GSMA.MobileConnect/MobileConnectWebInterface/README.md)
- For non-web applications such as Win10 UWP, Win8 or .Net 4.5+ use [MobileConnectInterface](Docs/GSMA.MobileConnect/MobileConnectInterface/README.md)

Classes are designed to support dependency injection so custom versions of many components can be used, ninject is used as an example.

```csharp
kernel.Bind<Utils.RestClient>().ToSelf();
kernel.Bind<Cache.IDiscoveryCache>().To<Cache.ConcurrentDiscoveryCache>();
kernel.Bind<Discovery.IDiscovery>().To<Discovery.Discovery>();
kernel.Bind<Authentication.IAuthentication>().To<Authentication.Authentication>();
kernel.Bind<MobileConnectConfig>().ToConstant(config);
kernel.Bind<MobileConnectWebInterface>().ToSelf().InSingletonScope();
```

Non-server applications will require the use of some WebView to show the user certain web pages in the authorization process with any redirects to the registered RedirectUrl being caught and handled.

Resources
---------
- [SDK Class Documentation](Docs/README.md)
- [MobileConnect Discovery API Information](https://developer.mobileconnect.io/content/discovery-api-0)
- [MobileConnect Authentication API Information](https://developer.mobileconnect.io/content/mobile-connect-api)
