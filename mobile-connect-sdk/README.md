# GSMA MobileConnect .Net SDK

## Recommended Setup

To utilise the SDK the following are required

- Visual Studio 2012 + Phone SDK 8.0 or Visual Studio 2013+

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

Use the class corresponding to your application type
- For ASP.NET server applications use [MobileConnectWebInterface](../Docs/GSMA.MobileConnect/MobileConnectWebInterface/README.md)
- For non-web applications such as Win10 UWP, Win8 or .Net 4.5+ use [MobileConnectInterface](../Docs/GSMA.MobileConnect/MobileConnectInterface/README.md)

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

### Extending ICache

Certain parts of the Discovery and MobileConnect processes utilise an implementation of [ICache](../Docs/GSMA.MobileConnect.Cache/ICache) if provided.
The [ICache](../Docs/GSMA.MobileConnect.Cache/ICache) is designed to appear as a simple key/value store for any information that needs to be cached with a configurable lifetime.
The cache also provides convenience methods for accessing and storing DiscoveryResponse objects.

To make implementation of custom cache types easier the abstract class [BaseCache](../Docs/GSMA.MobileConnect.Cache/ICache) is provided to cut down on the number of required method implementations.
The [BaseCache](../Docs/GSMA.MobileConnect.Cache/ICache) also implements basic cache object lifetime to trigger expiry of objects at fetch time if required, expired results can be either removed at this point or returned to be used as a fallback value for a HTTP call.

Currently the only cache implementation available is [ConcurrentCache](../Docs/GSMA.MobileConnect.Cache/ConcurrentCache) which utilises JSON serialisation and a ConcurrentDictionary for thread safe storage and retrieval.
This cache implementation will not share across application instances, if that functionality is required an implementation wrapping a third party in memory cache such as redis or memcached should be created.

## Resources

- [SDK Class Documentation](../docs/README.md)
- [MobileConnect Discovery API Information](https://developer.mobileconnect.io/content/discovery-api-0)
- [MobileConnect Authentication API Information](https://developer.mobileconnect.io/content/mobile-connect-api)
