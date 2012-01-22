using System;
using WineApi;
using NUnit.Framework;
using Rhino.Mocks;

namespace WineApiUnitTests
{
    [TestFixture]
    internal class CategoryMapServiceTests
    {
        [Test]
        public void Execute_ShowWineTypes_Succeeds()
        {
            var stubUrlInvoker = MockRepository.GenerateStub<IUrlInvoker>();

            stubUrlInvoker.Stub(stub => stub.InvokeUrl(string.Empty))
                .IgnoreArguments()
                .Return(Utils.GetTestData("WineTypes"));

            var categoryMapService = new CategoryMapService();
            categoryMapService.UrlInvoker = stubUrlInvoker;

            CategoryMap categoryMap = categoryMapService.Show(4).Execute();

            stubUrlInvoker.AssertWasCalled(stub => stub.InvokeUrl(Arg<string>.Matches(s => s.Contains("show=(4)"))));
            Assert.That(categoryMap, Is.Not.Null);
            Assert.That(categoryMap.Status.ReturnCode, Is.EqualTo(ReturnCode.Success));
            Assert.That(categoryMap.Status.Messages, Has.Length.EqualTo(0));
            Assert.That(categoryMap.Categories, Has.Length.EqualTo(1));
            Assert.That(categoryMap.Categories[0].Id, Is.EqualTo(4));
            Assert.That(categoryMap.Categories[0].Name, Is.EqualTo("Wine Type"));
            Assert.That(categoryMap.Categories[0].Refinements, Has.Length.GreaterThan(0));
        }

        [Test]
        public void Execute_ShowWineTypesAndVarietals_Succeeds()
        {
            var stubUrlInvoker = MockRepository.GenerateStub<IUrlInvoker>();

            stubUrlInvoker.Stub(stub => stub.InvokeUrl(string.Empty))
                .IgnoreArguments()
                .Return(Utils.GetTestData("WineTypes"));

            var categoryMapService = new CategoryMapService();
            categoryMapService.UrlInvoker = stubUrlInvoker;

            CategoryMap categoryMap = categoryMapService.Show(4, 5).Execute();

            stubUrlInvoker.AssertWasCalled(stub => stub.InvokeUrl(Arg<string>.Matches(s => s.Contains("show=(4+5)"))));
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
