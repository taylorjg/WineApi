using System;

namespace WineApiTests
{
    internal class Utils
    {
        public static string GetTestData(string resourceName)
        {
            return TestData.ResourceManager.GetString(resourceName);
        }
    }
}
