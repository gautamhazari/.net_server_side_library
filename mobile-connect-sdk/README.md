# GSMA MobileConnect .Net SDK

## Recommended Setup

To utilise the SDK the following are required

- Visual Studio 2017+

## Using The SDK

### Installation

Install the SDK to your .Net application using [Nuget](https://www.nuget.org/packages/GSMA.MobileConnect)

```posh
Install-Package GSMA.MobileConnect
```

### Configuration

Configure your MobileConnect options using [MobileConnectConfig](../Docs/GSMA.MobileConnect/MobileConnectConfig/README.md)

```csharp
var config = new MobileConnectConfig
{
    ClientId = "ab416e2c-edbe-4570-b218-26dd3239fcee",
    ClientSecret = "bc8425c6-c9ad-45a4-9866-0add468ece50",
    RedirectUrl = "http://localhost:8080/server_side_api/discovery_callback",
    DiscoveryUrl = "https://discovery.sandbox.mobileconnect.io/v2/discovery",
};
```

## Resources

- [SDK Class Documentation](../docs/README.md)
- [MobileConnect Discovery API Information](https://developer.mobileconnect.io/content/discovery-api-0)
- [MobileConnect Authentication API Information](https://developer.mobileconnect.io/content/mobile-connect-api)
