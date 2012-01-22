using System;
using WineApi;
using NUnit.Framework;
using Rhino.Mocks;

namespace WineApiUnitTests
{
    [TestFixture]
    internal class ReferenceServiceTests
    {
        [Test]
        public void Execute_MerlotReferences_Succeeds()
        {
            var stubUrlInvoker = MockRepository.GenerateStub<IUrlInvoker>();

            stubUrlInvoker.Stub(stub => stub.InvokeUrl(string.Empty))
                .IgnoreArguments()
                .Return(Utils.GetTestData("MerlotReferences"));

            var referenceService = new ReferenceService();
            referenceService.UrlInvoker = stubUrlInvoker;

            Reference reference = referenceService.CategoriesFilter(138).Execute();

            stubUrlInvoker.AssertWasCalled(stub => stub.InvokeUrl(Arg<string>.Matches(s => s.Contains("categories(138)"))));
            Assert.That(reference, Is.Not.Null);
            Assert.That(reference.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(reference.Status.Messages, Has.Length.EqualTo(0));
            Assert.That(reference.Books, Has.Length.EqualTo(1));
            Assert.That(reference.Books[0].Id, Is.EqualTo("5"));
            Assert.That(reference.Books[0].Title, Is.EqualTo("Varietal"));
            Assert.That(reference.Books[0].Articles, Has.Length.EqualTo(1));
            Assert.That(reference.Books[0].Articles[0].Id, Is.EqualTo("138"));
            Assert.That(reference.Books[0].Articles[0].Title, Is.EqualTo("Merlot"));
        }
    }
}
