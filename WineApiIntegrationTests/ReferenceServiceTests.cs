using System;
using WineApi;
using NUnit.Framework;

namespace WineApiIntegrationTests
{
    [TestFixture]
    internal class ReferenceServiceTests
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Config.ApiKey = WineApiTestsConstants.API_KEY;
            Config.Version = WineApiTestsConstants.VERSION;
        }

        [Test]
        public void Execute_ForCategory_Succeeds()
        {
            var referenceService = new ReferenceService();

            Reference reference = referenceService.CategoriesFilter(2288).Execute();

            Assert.That(reference, Is.Not.Null);
            Assert.That(reference.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(reference.Status.Messages, Has.Length.EqualTo(0));
        }
    }
}
