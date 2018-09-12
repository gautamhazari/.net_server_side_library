# GSMA MobileConnect .Net SDK Demos

- These demos should provide full example code for completing the authorization flow of MobileConnect
- Demo code is only for example purposes


- Though demos only exist for Windows 10 UWP, ASP.NET WebApi 2, WPF and Windows 8.1, the SDK also supports ASP.NET Core 1.0, Windows 8 and Windows Phone 8.1

## Recommended Setup

In order to build and run all demo applications the following are required

- Visual Studio 2013 Update 3 or above
- Windows 10 SDK (To Build Windows 10 Demo Only)
- Windows 10 (To Run Windows 10 Demo Only)
- Windows 8+ (To Build and Run Windows 8 Demo Only)

## Getting Started

You must have first registered an account on the [MobileConnect Developer Site](https://developer.mobileconnect.io) and created an application to get your sandbox credentials.

Using the credentials from your account page either replace the credentials in GSMA.Demo.Config.DemoConfiguration or in GSMA.Demo.Config/config.json these will be used across all demo applications.

Build and run the applications.

The MobileConnect process is implemented in one file for each application
- GSMA.MobileConnect.Demo.Universal - MainPage.xaml.cs
- GSMA.MobileConnect.Demo.Web - MobileConnectController.cs
- GSMA.MobileConnect.Demo.Win8 - MainPage.xaml.cs
- GSMA.MobileConnect.Demo.Wpf - MainWindow.xaml.cs

## Resources

- [SDK Class Documentation](../docs/README.md)
- [MobileConnect Discovery API Information](https://developer.mobileconnect.io/content/discovery-api-0)
- [MobileConnect Authentication API Information](https://developer.mobileconnect.io/content/mobile-connect-api)
