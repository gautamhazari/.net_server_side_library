SupportedVersionsConverter Class
================================
Converts an array of supported versions to a [SupportedVersions][1] object


Inheritance Hierarchy
---------------------
[System.Object][2]  
  JsonConverter  
    **GSMA.MobileConnect.Json.Converters.SupportedVersionsConverter**  

**Namespace:** [GSMA.MobileConnect.Json.Converters][3]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class SupportedVersionsConverter : JsonConverter
```

The **SupportedVersionsConverter** type exposes the following members.


Constructors
------------

                 | Name                            | Description                                                            
---------------- | ------------------------------- | ---------------------------------------------------------------------- 
![Public method] | [SupportedVersionsConverter][4] | Initializes a new instance of the **SupportedVersionsConverter** class 


Properties
----------

                   | Name     | Description                     
------------------ | -------- | ------------------------------- 
![Public property] | CanRead  | (Inherited from JsonConverter.) 
![Public property] | CanWrite | (Inherited from JsonConverter.) 


Methods
-------

                 | Name            | Description                                                                                           
---------------- | --------------- | ----------------------------------------------------------------------------------------------------- 
![Public method] | [CanConvert][5] | Returns true if the target type is [SupportedVersions][1] (Overrides JsonConverter.CanConvert(Type).) 
![Public method] | GetSchema       |  **Obsolete.** (Inherited from JsonConverter.)                                                        
![Public method] | [ReadJson][6]   | (Overrides JsonConverter.ReadJson(JsonReader, Type, Object, JsonSerializer).)                         
![Public method] | [WriteJson][7]  | (Overrides JsonConverter.WriteJson(JsonWriter, Object, JsonSerializer).)                              


See Also
--------

#### Reference
[GSMA.MobileConnect.Json.Converters Namespace][3]  

[1]: ../../GSMA.MobileConnect.Discovery/SupportedVersions/README.md
[2]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[3]: ../README.md
[4]: _ctor.md
[5]: CanConvert.md
[6]: ReadJson.md
[7]: WriteJson.md
[8]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"