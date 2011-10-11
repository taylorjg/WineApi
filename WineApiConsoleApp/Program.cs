using System;
using WineApiConsoleApp.WineDataService;

namespace WineApiConsoleApp
{
    internal class Program
    {
        private static string API_KEY = "00000000000000000000000000000000";

        private static void Main(string[] args)
        {
            var wineData = new WineData(new Uri("http://wine.cloudapp.net"));
            var wineTypes = wineData.WineTypes.AddQueryOption("apikey", API_KEY);
            foreach (var wineType in wineTypes) {
                Console.WriteLine(wineType.Name);
            }
        }
    }
}
