using NasSaveLog.Business;
using NUnit.Framework;

namespace NasSaveLog.Tests.Business
{
    [TestFixture]
    public sealed class NasLogTests
    {
        [Test]
        public void GivenANasLog_WhenSettingAnError_ThenShouldReturnTheTypeRelativeToTheError()
        {
            // Arrange & Act
            var logNas = new NasLog()
            {
                IsError = true
            };

            // Assert
            Assert.That(logNas.LogType, Is.EqualTo("error"), $"LogType is not well defined depending on {nameof(NasLog.IsError)} field.");
        }

        [Test]
        public void GivenANasLog_WhenSettingALog_ThenShouldReturnTheTypeRelativeToTheLog()
        {
            // Arrange & Act
            var logNas = new NasLog()
            {
                IsError = false
            };

            // Assert
            Assert.That(logNas.LogType, Is.EqualTo("log"), $"LogType is not well defined depending on {nameof(NasLog.IsError)} field.");
        }
    }
}
