using System;
using WineApi;
using NUnit.Framework;
using Rhino.Mocks;

namespace WineApiUnitTests
{
    [TestFixture]
    internal class CommonServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            Config.Reset();
        }

        [Test]
        public void Execute_StatusWithReturnCode200And2Messages_ThrowsException()
        {
            var stubUrlInvoker = MockRepository.GenerateStub<IUrlInvoker>();

            stubUrlInvoker.Stub(stub => stub.InvokeUrl(string.Empty))
                .IgnoreArguments()
                .Return(Utils.GetTestData("StatusWithReturnCode200And2Messages"));

            var categoryMapService = new CategoryMapService();
            categoryMapService.UrlInvoker = stubUrlInvoker;

            try {
                CategoryMap categoryMap = categoryMapService.Show(4).Execute();
                Assert.Fail("Expected a WineApiStatusException to be thrown!");
            }
            catch (WineApiStatusException ex) {
                Assert.That(ex.Status, Is.Not.Null);
                Assert.That(ex.Status.ReturnCode, Is.EqualTo(ReturnCode.UnableToAuthorize));
                Assert.That(ex.Status.Messages, Has.Length.EqualTo(2));
                Assert.That(ex.Status.Messages[0], Is.EqualTo("Message1"));
                Assert.That(ex.Status.Messages[1], Is.EqualTo("Message2"));
            }
        }

        [Test]
        public void Execute_StatusWithUnknownReturnCode_ThrowsException()
        {
            var stubUrlInvoker = MockRepository.GenerateStub<IUrlInvoker>();

            stubUrlInvoker.Stub(stub => stub.InvokeUrl(string.Empty))
                .IgnoreArguments()
                .Return(Utils.GetTestData("StatusWithUnknownReturnCode"));

            var categoryMapService = new CategoryMapService();
            categoryMapService.UrlInvoker = stubUrlInvoker;

            try {
                CategoryMap categoryMap = categoryMapService.Show(4).Execute();
                Assert.Fail("Expected a WineApiStatusException to be thrown!");
            }
            catch (WineApiStatusException ex) {
                Assert.That(ex.Status, Is.Not.Null);
                Assert.That(ex.Status.ReturnCode, Is.EqualTo((ReturnCode)123));
                Assert.That((int)ex.Status.ReturnCode, Is.EqualTo(123));
            }
        }

        [Test]
        public void Execute_BadJson_ThrowsException()
        {
            var stubUrlInvoker = MockRepository.GenerateStub<IUrlInvoker>();

            stubUrlInvoker.Stub(stub => stub.InvokeUrl(string.Empty))
                .IgnoreArguments()
                .Return(Utils.GetTestData("BadJson"));

            var categoryMapService = new CategoryMapService();
            categoryMapService.UrlInvoker = stubUrlInvoker;

            try {
                CategoryMap categoryMap = categoryMapService.Show(4).Execute();
                Assert.Fail("Expected a WineApiServiceException to be thrown!");
            }
            catch (WineApiServiceException ex) {
                Assert.That(ex.InnerException, Is.Not.Null);
            }
        }
    }
}
