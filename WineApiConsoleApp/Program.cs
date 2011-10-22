using System;
using System.Linq;
using System.Data.Services.Client;
using WineApiConsoleApp.WineDataService;

// http://wine.cloudapp.net/WineTypes()?apikey=...
// Id: 124; Name: Red Wine; Url:
// Id: 125; Name: White Wine; Url:
// Id: 126; Name: RosÃ© Wine; Url:
// Id: 123; Name: Champagne & Sparkling; Url:
// Id: 134; Name: SakÃ©; Url:
// Id: 128; Name: Dessert, Sherry & Port; Url:
//
// http://wine.cloudapp.net/WineTypes()?apikey=...&$filter=(Id eq '124')
// Id: 124; Name: Red Wine; Url:
//
// http://wine.cloudapp.net/Products()?apikey=...&$top=5
// Id: 91856; Name: RockBare Shiraz 2005; Url: http://www.wine.com/V6/RockBare-Shiraz-2005/wine/91856/detail.aspx
// Id: 92192; Name: Chateau Mont Redon Cotes-du-Rhone 2005; Url: http://www.wine.com/V6/Chateau-Mont-Redon-Cotes-du-Rhone-2005/wine/92192/detail.aspx
// Id: 105144; Name: Hahn Estates Santa Lucia Highlands Estate Syrah 2007; Url: http://www.wine.com/V6/Hahn-Estates-Santa-Lucia-Highlands-Estate-Syrah-2007/wine/105144/detail.aspx
// Id: 87133; Name: Veramonte Primus 2004; Url: http://www.wine.com/V6/Veramonte-Primus-2004/wine/87133/detail.aspx
// Id: 93707; Name: Veramonte Primus 2005; Url: http://www.wine.com/V6/Veramonte-Primus-2005/wine/93707/detail.aspx
//
// http://wine.cloudapp.net/Products()?apikey=...&$filter=(Id eq '91856')
// Id: 91856; Name: RockBare Shiraz 2005; Url: http://www.wine.com/V6/RockBare-Shiraz-2005/wine/91856/detail.aspx
//
// http://wine.cloudapp.net/Products()?apikey=...&$filter=(Name eq 'RockBare Shiraz 2005')
// Id: 91856; Name: RockBare Shiraz 2005; Url: http://www.wine.com/V6/RockBare-Shiraz-2005/wine/91856/detail.aspx
//
// http://wine.cloudapp.net/Products('91856')?apikey=...
// Id: 91856; Name: RockBare Shiraz 2005; Url: http://www.wine.com/V6/RockBare-Shiraz-2005/wine/91856/detail.aspx

namespace WineApiConsoleApp
{
    internal class Program
    {
        private static string API_KEY = "...";

        private static void Main(string[] args)
        {
            try {
                var wineData = new WineData(new Uri("http://wine.cloudapp.net"));

                var wineTypes = wineData.WineTypes
                    .AddQueryOption("apikey", API_KEY);
                Console.WriteLine(wineTypes.RequestUri.ToString());
                foreach (var wineType in wineTypes) {
                    Console.WriteLine("Id: {0}; Name: {1}; Url: {2}", wineType.Id, wineType.Name, wineType.Url);
                }

                Console.WriteLine();
                var wineTypes2 = wineData.WineTypes
                    .AddQueryOption("apikey", API_KEY)
                    .AddQueryOption("$filter", "(Id eq '124')");
                Console.WriteLine(wineTypes2.RequestUri.ToString());
                foreach (var wineType in wineTypes2) {
                    Console.WriteLine("Id: {0}; Name: {1}; Url: {2}", wineType.Id, wineType.Name, wineType.Url);
                }

                Console.WriteLine();
                var products = wineData.Products
                    .AddQueryOption("apikey", API_KEY)
                    .AddQueryOption("$top", 5);
                Console.WriteLine(products.RequestUri.ToString());
                foreach (var product in products) {
                    Console.WriteLine("Id: {0}; Name: {1}; Url: {2}", product.Id, product.Name, product.Url);
                }

                Console.WriteLine();
                var products2 = wineData.Products
                    .AddQueryOption("apikey", API_KEY)
                    .AddQueryOption("$filter", "(Id eq '91856')");
                Console.WriteLine(products2.RequestUri.ToString());
                foreach (var product in products2) {
                    Console.WriteLine("Id: {0}; Name: {1}; Url: {2}", product.Id, product.Name, product.Url);
                }

                Console.WriteLine();
                var products3 = wineData.Products
                    .AddQueryOption("apikey", API_KEY)
                    .AddQueryOption("$filter", "(Name eq 'RockBare Shiraz 2005')");
                Console.WriteLine(products3.RequestUri.ToString());
                foreach (var product in products3) {
                    Console.WriteLine("Id: {0}; Name: {1}; Url: {2}", product.Id, product.Name, product.Url);
                }

                Console.WriteLine();
                var productLinqQuery =
                    from p in wineData.Products
                    where p.Id == "91856"
                    select p;
                if (productLinqQuery is DataServiceQuery<Product>) {
                    productLinqQuery = (productLinqQuery as DataServiceQuery<Product>).AddQueryOption("apikey", API_KEY);
                    Console.WriteLine((productLinqQuery as DataServiceQuery<Product>).RequestUri.ToString());
                }
                foreach (var product in productLinqQuery) {
                    Console.WriteLine("Id: {0}; Name: {1}; Url: {2}", product.Id, product.Name, product.Url);
                }
            }
            catch (Exception ex) {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
