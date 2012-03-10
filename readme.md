# WineApi

This project started off by looking at the OData service provided by wine.com (see the WineApiConsoleApp project).
However, I then switched to the RESTful API. I have created a C# class library called WineApi that implements the
entire object model. I have also started work on a demo WPF client application using MVVM.

## NuGet

WineApi is available as NuGet package - see http://nuget.org/packages/WineApi. It has a dependency on [Newtonsoft.Json](http://nuget.org/packages/Newtonsoft.Json) which is
a strongly named assembly. The current WineApi NuGet package was built against 4.0.5 of Newtonsoft.Json. However, 4.0.5 has been superceded (4.0.8 as of March 10th 2012).
This causes a problem at run time:

```
Could not load file or assembly
'Newtonsoft.Json, Version=4.0.5.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed'
or one of its dependencies.
The located assembly's manifest definition does not match the assembly reference.
```

This can be fixed by running Add-BindingRedirect in the Package Manager Console:

```
PM> add-bindingredirect

Name                                     OldVersion                                                            NewVersion                                                          
----                                     ----------                                                            ----------                                                          
Newtonsoft.Json                          0.0.0.0-4.0.8.0                                                       4.0.8.0                                                             

```

Note that when I first tried this, it did nothing. I then upgraded my NuGet version from 1.2.blah to 1.6.21215.9133
by uninstalling and re-installing it. After upgrading NuGet, running Add-BindingRedirect worked fine - it added
a bindingRedirect to my app.config:

```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="Newtonsoft.Json" publicKeyToken="30ad4fe6b2a6aeed" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-4.0.8.0" newVersion="4.0.8.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
</configuration>
```

See the following post for further information:

- http://blog.davidebbo.com/2011/01/nuget-versioning-part-3-unification-via.html 

## Simple C# Client Example

```C#
using System;
using WineApi;

namespace WineApiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Config.ApiKey = "<your api key here>";
                CatalogService catalogService = new CatalogService();
                Catalog catalog = catalogService
                    .State("CA")
                    .InStock(true)
                    .Search("Merlot")
                    .RatingFilter(90, 96)
                    .SortBy(SortOptions.Rating, SortDirection.Descending)
                    .Execute();
                Console.WriteLine("Number of products found: {0}", catalog.Products.Total);
            }
            catch (WineApiException ex) {
                Console.Error.WriteLine(ex.Message);
                if (ex.InnerException != null) {
                    Console.Error.WriteLine(ex.InnerException.Message);
                }
            }
        }
    }
}
```

## Wine.com RESTful References

- http://api.wine.com
- http://api.wine.com/wiki
- http://api.wine.com/forum

## WPF Data Virtualisation

In the WineDemo WPF application, I have a ListBox which is data bound to the results of the CatalogService.Execute() call.
But, the current search criteria may have 100's or 1000's of matches. Therefore, I looked for a way to load the results
incrementally as the user scrolled through the list. I came across the following excellent document which discusses this issue
in great detail. I incorporated this technique into WineDemo and it works well.

- http://bea.stollnitz.com/files/52/DataVirtualization.pdf
- http://bea.stollnitz.com/files/52/DataVirtualizationVincent.zip
- http://bea.stollnitz.com/blog/?p=344

## (Wine.com OData References)

- http://wine.cloudapp.net
- http://www.odata.org/
