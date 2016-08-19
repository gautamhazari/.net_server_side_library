RestClient Class
================
Wrapper for Http requests, returning a simple normalised response object


Inheritance Hierarchy
---------------------
[System.Object][1]  
  **GSMA.MobileConnect.Utils.RestClient**  

**Namespace:** [GSMA.MobileConnect.Utils][2]  
**Assembly:** GSMA.MobileConnect (in GSMA.MobileConnect.dll)

Syntax
------

```csharp
public class RestClient : IDisposable
```

The **RestClient** type exposes the following members.


Constructors
------------

                 | Name                                                          | Description                                                                                               
---------------- | ------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- 
![Public method] | [RestClient()][3]                                             | Creates a new instance of RestClient with default timeout of 30 seconds and headless timeout of 2 minutes 
![Public method] | [RestClient(Nullable&lt;TimeSpan>, Nullable&lt;TimeSpan>)][4] | Creates a new instance of RestClient with optional timeout specified                                      


Methods
-------

                    | Name                                                                                                                     | Description                                                                                                                                         
------------------- | ------------------------------------------------------------------------------------------------------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------- 
![Public method]    | [Dispose][5]                                                                                                             | Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.                                            
![Public method]    | [GetAsync][6]                                                                                                            | Executes a HTTP GET to the supplied uri with optional basic auth, cookies and query params                                                          
![Public method]    | [GetFinalRedirect][7]                                                                                                    | Attempts to follow a redirect path until a concrete url is loaded or the expectedRedirectUrl is reached                                             
![Public method]    | [PostAsync(String, RestAuthentication, IEnumerable&lt;BasicKeyValuePair>, String, IEnumerable&lt;BasicKeyValuePair>)][8] | Executes a HTTP POST to the supplied uri with x-www-form-urlencoded content and optional cookies                                                    
![Protected method] | [PostAsync(String, RestAuthentication, HttpContent, String, IEnumerable&lt;BasicKeyValuePair>)][9]                       | Executes a HTTP POST to the supplied uri with the supplied HttpContent object, with optional cookies. Used as the base for other PostAsync methods. 
![Public method]    | [PostAsync(String, RestAuthentication, Object, String, IEnumerable&lt;BasicKeyValuePair>)][10]                           | Executes a HTTP POST to the supplied uri with application/json content and optional cookies                                                         
![Public method]    | [PostAsync(String, RestAuthentication, String, String, String, IEnumerable&lt;BasicKeyValuePair>)][11]                   | Executes a HTTP POST to the supplied uri with the supplied content type and content, with optional cookies                                          


See Also
--------

#### Reference
[GSMA.MobileConnect.Utils Namespace][2]  

[1]: http://msdn.microsoft.com/en-us/library/e5kfa45b
[2]: ../README.md
[3]: _ctor.md
[4]: _ctor_1.md
[5]: Dispose.md
[6]: GetAsync.md
[7]: GetFinalRedirect.md
[8]: PostAsync.md
[9]: PostAsync_1.md
[10]: PostAsync_2.md
[11]: PostAsync_3.md
[12]: ../../_icons/Help.png
[Public method]: ../../_icons/pubmethod.gif "Public method"
[Protected method]: ../../_icons/protmethod.gif "Protected method"