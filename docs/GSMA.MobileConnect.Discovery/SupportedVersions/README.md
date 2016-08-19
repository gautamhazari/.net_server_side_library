SupportedVersions Class
=======================
Storage for supported mobile connect versions in [MobileConnectVersionSupported][1]


Inheritance Hierarchy
---------------------
[System.Object][2]  
  **GSMA.MobileConnect.Discovery.SupportedVersions**  

**Namespace:** [GSMA.MobileConnect.Discovery][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class SupportedVersions
```

The **SupportedVersions** type exposes the following members.


Constructors
------------

                 | Name                   | Description                                                                                                          
---------------- | ---------------------- | -------------------------------------------------------------------------------------------------------------------- 
![Public method] | [SupportedVersions][4] | Creates a new instance of the SupportedVersions class using the versionSupport dictionary to generate initial values 


Methods
-------

                 | Name                     | Description                                                                                                                                          
---------------- | ------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [GetSupportedVersion][5] | Gets the available mobile connect version for the specified scope value. If versions aren't available then configured default versions will be used. 
![Public method] | [IsVersionSupported][6]  | Test for support of the specified version or a greater version                                                                                       


See Also
--------

#### Reference
[GSMA.MobileConnect.Discovery Namespace][3]  

[1]: ../ProviderMetadata/MobileConnectVersionSupported.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: GetSupportedVersion.md
[6]: IsVersionSupported.md
[7]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"