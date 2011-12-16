# WineApi

This project started off by looking at the OData service provided by wine.com (see the WineApiConsoleApp project).
However, I then switched to the RESTful API. I have created a C# class library called WineApi that implements the
entire object model. I have also started work on a demo WPF client application using MVVM.

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
            Config.ApiKey = "<your api key here>";

            CatalogService catalogService = new CatalogService();

            try {
                Catalog catalog = catalogService
                    .State("CA")
                    .InStock(true)
                    .Search("Merlot")
                    .RatingFilter(90, 96)
                    .SortBy(SortOptions.Rating, SortDirection.Descending)
                    .Execute();
                Console.WriteLine("Number of products found: {0}", catalog.Products.Total);
            }
            catch (WineApiStatusException ex) {
                Console.Error.WriteLine(ex.Status.Messages[0]);
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
