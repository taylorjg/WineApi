using System;
using WineApi;
using NUnit.Framework;

namespace WineApiIntegrationTests
{
    [TestFixture]
    internal class CatalogServiceTests
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Config.ApiKey = WineApiTestsConstants.API_KEY;
            Config.Version = WineApiTestsConstants.VERSION;
        }

        [Test]
        public void Execute_WithProductFilterForOneSpecificProduct_Succeeds()
        {
            var catalogService = new CatalogService();

            Catalog catalog = catalogService.ProductFilter(95457).Execute();

            Assert.That(catalog, Is.Not.Null);
            Assert.That(catalog.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(catalog.Status.Messages, Has.Length.EqualTo(0));
        }

        [Test]
        public void Execute_SearchForOneThing_Succeeds()
        {
            var catalogService = new CatalogService();

            Catalog catalog = catalogService
                .Search("Merlot")
                .Execute();

            Assert.That(catalog, Is.Not.Null);
            Assert.That(catalog.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(catalog.Status.Messages, Has.Length.EqualTo(0));
        }

        [Test]
        public void Execute_SearchForTwoThingsSpecifiedTogether_Succeeds()
        {
            var catalogService = new CatalogService();

            Catalog catalog = catalogService
                .Search("Merlot", "Shiraz")
                .Execute();

            Assert.That(catalog, Is.Not.Null);
            Assert.That(catalog.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(catalog.Status.Messages, Has.Length.EqualTo(0));
        }

        [Test]
        public void Execute_SearchForTwoThingsSpecifiedSeparately_Succeeds()
        {
            var catalogService = new CatalogService();

            Catalog catalog = catalogService
                .Search("Merlot")
                .Search("Shiraz")
                .Execute();

            Assert.That(catalog, Is.Not.Null);
            Assert.That(catalog.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(catalog.Status.Messages, Has.Length.EqualTo(0));
        }

        [Test]
        public void Execute_SortingByPriceAscending_Succeeds()
        {
            var catalogService = new CatalogService();

            Catalog catalog = catalogService
                .State("CA")
                .Search("Merlot")
                .SortBy(SortOptions.Price, SortDirection.Ascending)
                .Execute();

            Assert.That(catalog, Is.Not.Null);
            Assert.That(catalog.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(catalog.Status.Messages, Has.Length.EqualTo(0));
        }

        [Test]
        public void Execute_SortingByPriceDescending_Succeeds()
        {
            var catalogService = new CatalogService();

            Catalog catalog = catalogService
                .State("CA")
                .Search("Merlot")
                .SortBy(SortOptions.Price, SortDirection.Descending)
                .Execute();

            Assert.That(catalog, Is.Not.Null);
            Assert.That(catalog.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(catalog.Status.Messages, Has.Length.EqualTo(0));
        }

        [Test]
        public void Execute_ForComplexProductQuery_Succeeds()
        {
            var catalogService = new CatalogService();

            decimal minPrice = 100M;
            decimal maxPrice = 200M;

            Catalog catalog = catalogService
                .State("CA")
                .PriceFilter(minPrice, maxPrice)
                .SortBy(SortOptions.Price, SortDirection.Descending)
                .InStock()
                .Offset(10)
                .Size(5)
                .Execute();

            Assert.That(catalog, Is.Not.Null);
            Assert.That(catalog.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(catalog.Status.Messages, Has.Length.EqualTo(0));
            Assert.That(catalog.Products.Offset, Is.EqualTo(10));
            Assert.That(catalog.Products.List, Has.Length.EqualTo(5));
            Assert.That(catalog.Products.List, Is.All.Matches<Product>(p => p.Retail != null ? p.Retail.Price >= minPrice : true));
            Assert.That(catalog.Products.List, Is.All.Matches<Product>(p => p.Retail != null ? p.Retail.Price <= maxPrice : true));
            Assert.That(catalog.Products.List, Is.All.Matches<Product>(p => p.Retail != null ? p.Retail.InStock : true));
            // ordered descending
        }

        [Test]
        public void Execute_ForProductByPriceAndCategoriesAndRating_Succeeds()
        {
            var catalogService = new CatalogService();

            decimal minPrice = 500M;
            decimal maxPrice = 1000M;
            int minRating = 93;
            int maxRating = 96;

            Catalog catalog = catalogService
                .State("CA")
                .PriceFilter(minPrice, maxPrice)
                .CategoriesFilter(124, 7155)
                .RatingFilter(minRating, maxRating)
                .SortBy(SortOptions.Price, SortDirection.Descending)
                .SortBy(SortOptions.Rating, SortDirection.Descending)
                .Execute();

            Assert.That(catalog, Is.Not.Null);
            Assert.That(catalog.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(catalog.Status.Messages, Has.Length.EqualTo(0));
            Assert.That(catalog.Products.List, Is.All.Matches<Product>(p => p.Retail != null ? p.Retail.Price >= minPrice : true));
            Assert.That(catalog.Products.List, Is.All.Matches<Product>(p => p.Retail != null ? p.Retail.Price <= maxPrice : true));
            Assert.That(catalog.Products.List, Is.All.Matches<Product>(p => p.Ratings.HighestScore >= minRating));
            Assert.That(catalog.Products.List, Is.All.Matches<Product>(p => p.Ratings.HighestScore <= maxRating));
        }
    }
}
