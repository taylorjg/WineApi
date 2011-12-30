using System;
using WineApi;
using NUnit.Framework;

namespace WineApiTests
{
    [TestFixture]
    internal class GeneralServiceIntegrationTests
    {
        [Test]
        public void Execute_WithoutSettingApiKey_ThrowsException()
        {
            Config.Reset();
            var categoryMapService = new CategoryMapService();

            try {
                CategoryMap categoryMap = categoryMapService.Show(4).Execute();
                Assert.Fail("Expected a WineApiStatusException to be thrown!");
            }
            catch (WineApiStatusException ex) {
                Assert.That(ex.Status.ReturnCode, Is.EqualTo(ReturnCode.UnableToAuthorize));
            }
        }

        [Test]
        public void Execute_WithNullApiKey_ThrowsException()
        {
            Config.Reset();
            Config.ApiKey = null;
            var categoryMapService = new CategoryMapService();

            try {
                CategoryMap categoryMap = categoryMapService.Show(4).Execute();
                Assert.Fail("Expected a WineApiStatusException to be thrown!");
            }
            catch (WineApiStatusException ex) {
                Assert.That(ex.Status.ReturnCode, Is.EqualTo(ReturnCode.UnableToAuthorize));
            }
        }

        [Test]
        public void Execute_WithEmptyApiKey_ThrowsException()
        {
            Config.Reset();
            Config.ApiKey = string.Empty;
            var categoryMapService = new CategoryMapService();

            try {
                CategoryMap categoryMap = categoryMapService.Show(4).Execute();
                Assert.Fail("Expected a WineApiStatusException to be thrown!");
            }
            catch (WineApiStatusException ex) {
                Assert.That(ex.Status.ReturnCode, Is.EqualTo(ReturnCode.UnableToAuthorize));
            }
        }

        [Test]
        public void Execute_WithBogusApiKey_ThrowsException()
        {
            Config.Reset();
            Config.ApiKey = "BogusApiKey";
            var categoryMapService = new CategoryMapService();

            try {
                CategoryMap categoryMap = categoryMapService.Show(4).Execute();
                Assert.Fail("Expected a WineApiStatusException to be thrown!");
            }
            catch (WineApiStatusException ex) {
                Assert.That(ex.Status.ReturnCode, Is.EqualTo(ReturnCode.NoAccess));
            }
        }

        [Test]
        public void Execute_WithNullVersion_ThrowsException()
        {
            Config.Reset();
            Config.ApiKey = WineApiTestsConstants.API_KEY;
            Config.Version = null;
            var categoryMapService = new CategoryMapService();

            try {
                CategoryMap categoryMap = categoryMapService.Show(4).Execute();
                Assert.Fail("Expected a WineApiServiceException to be thrown!");
            }
            catch (WineApiServiceException) {
            }
        }

        [Test]
        public void Execute_WithEmptyVersion_ThrowsException()
        {
            Config.Reset();
            Config.ApiKey = WineApiTestsConstants.API_KEY;
            Config.Version = string.Empty;
            var categoryMapService = new CategoryMapService();

            try {
                CategoryMap categoryMap = categoryMapService.Show(4).Execute();
                Assert.Fail("Expected a WineApiServiceException to be thrown!");
            }
            catch (WineApiServiceException) {
            }
        }

        [Test]
        public void Execute_WithBogusVersion_ThrowsException()
        {
            Config.Reset();
            Config.ApiKey = WineApiTestsConstants.API_KEY;
            Config.Version = "BogusVersion";
            var categoryMapService = new CategoryMapService();

            try {
                CategoryMap categoryMap = categoryMapService.Show(4).Execute();
                Assert.Fail("Expected a WineApiServiceException to be thrown!");
            }
            catch (WineApiServiceException) {
            }
        }

        // Further tests to add:
        // Unicode e.g. WIneType Rose with accent
        // Negative ids e.g. wine type -1
        // etc.
    }
}
