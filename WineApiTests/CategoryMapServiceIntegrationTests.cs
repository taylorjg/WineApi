using System;
using WineApi;
using NUnit.Framework;

namespace WineApiTests
{
    [TestFixture]
    internal class CategoryMapServiceIntegrationTests
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Config.ApiKey = WineApiTestsConstants.API_KEY;
            Config.Version = WineApiTestsConstants.VERSION;
        }

        [Test]
        public void Execute_ShowWineTypes_Succeeds()
        {
            var categoryMapService = new CategoryMapService();

            CategoryMap categoryMap = categoryMapService.Show(4).Execute();

            Assert.That(categoryMap, Is.Not.Null);
            Assert.That(categoryMap.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(categoryMap.Status.Messages, Has.Length.EqualTo(0));
            Assert.That(categoryMap.Categories, Has.Length.EqualTo(1));
            Assert.That(categoryMap.Categories[0].Id, Is.EqualTo(4));
            Assert.That(categoryMap.Categories[0].Name, Is.EqualTo("Wine Type"));
            Assert.That(categoryMap.Categories[0].Refinements, Has.Length.GreaterThan(0));
        }
    }
}
