using System;
using WineApi;
using NUnit.Framework;
using Rhino.Mocks;

namespace WineApiUnitTests
{
    [TestFixture]
    internal class CatalogServiceTests
    {
        [Test]
        public void Execute_MerlotNapaValleyProducts_Succeeds()
        {
            var stubUrlInvoker = MockRepository.GenerateStub<IUrlInvoker>();

            stubUrlInvoker.Stub(stub => stub.InvokeUrl(string.Empty))
                .IgnoreArguments()
                .Return(Utils.GetTestData("MerlotNapaValleyProducts"));

            var catalogService = new CatalogService();
            catalogService.UrlInvoker = stubUrlInvoker;

            Catalog catalog = catalogService.CategoriesFilter(138, 2398).Execute();

            stubUrlInvoker.AssertWasCalled(
                stub => stub.InvokeUrl(
                    Arg<string>.Matches(url => url.Contains("categories(138+2398)"))));

            Assert.That(catalog, Is.Not.Null);
            Assert.That(catalog.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(catalog.Status.Messages, Has.Length.EqualTo(0));

            Assert.That(catalog.Products, Is.Not.Null);
            Assert.That(catalog.Products.List, Has.Length.EqualTo(10));

            Assert.That(catalog.Products.List[0].Id, Is.EqualTo(108074));
            Assert.That(catalog.Products.List[0].Name, Is.EqualTo("Duckhorn Napa Merlot 2008"));
            Assert.That(catalog.Products.List[0].Appellation.Id, Is.EqualTo(2398));
            Assert.That(catalog.Products.List[0].Appellation.Name, Is.EqualTo("Napa Valley"));
            Assert.That(catalog.Products.List[0].Appellation.Region.Id, Is.EqualTo(101));
            Assert.That(catalog.Products.List[0].Appellation.Region.Name, Is.EqualTo("California"));
            Assert.That(catalog.Products.List[0].Appellation.Region.Area, Is.Null);
        }
    }
}
