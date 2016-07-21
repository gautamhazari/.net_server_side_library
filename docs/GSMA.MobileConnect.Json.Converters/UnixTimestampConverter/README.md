UnixTimestampConverter Class
============================
Converts a unix timestamp to a DateTime


Inheritance Hierarchy
---------------------
[System.Object][1]  
  JsonConverter  
    **GSMA.MobileConnect.Json.Converters.UnixTimestampConverter**  

**Namespace:** [GSMA.MobileConnect.Json.Converters][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class UnixTimestampConverter : JsonConverter
```

The **UnixTimestampConverter** type exposes the following members.


Constructors
------------

                 | Name                        | Description                                                        
---------------- | --------------------------- | ------------------------------------------------------------------ 
![Public method] | [UnixTimestampConverter][3] | Initializes a new instance of the **UnixTimestampConverter** class 


Properties
----------

                   | Name     | Description                     
------------------ | -------- | ------------------------------- 
![Public property] | CanRead  | (Inherited from JsonConverter.) 
![Public property] | CanWrite | (Inherited from JsonConverter.) 


Methods
-------

                 | Name            | Description                                                                                                                        
---------------- | --------------- | ---------------------------------------------------------------------------------------------------------------------------------- 
![Public method] | [CanConvert][4] | Returns true if the target type is DateTime or DateTime? (Overrides JsonConverter.CanConvert(Type).)                               
![Public method] | GetSchema       |  **Obsolete.** (Inherited from JsonConverter.)                                                                                     
![Public method] | [ReadJson][5]   | Reads a unix timestamp and returns a DateTime object (Overrides JsonConverter.ReadJson(JsonReader, Type, Object, JsonSerializer).) 
![Public method] | [WriteJson][6]  | Writes a DateTime object as a unix timestamp (Overrides JsonConverter.WriteJson(JsonWriter, Object, JsonSerializer).)              


See Also
--------

#### Reference
[GSMA.MobileConnect.Json.Converters Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: CanConvert.md
[5]: ReadJson.md
[6]: WriteJson.md
[7]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Public property]: ../../_icons/pubproperty.gif "Public property"