using NUnit.Framework;
using SaveFileLogNAS.Business;

namespace SaveFileLogNAS.Tests.Business
{
    [TestFixture]
    class LogNasTests
    {
        [TestCase(false, "log")]
        [TestCase(true, "error")]
        public void CheckTypeDependingOnError(bool isError, string expectedLogType)
        {
            // Arrange & Act
            var logNas = new LogNas()
            {
                IsError = isError
            };

            // Assert
            Assert.That(logNas.LogType, Is.EqualTo(expectedLogType),
				$"LogType is not well defined depending on {nameof(LogNas.IsError)} field.");
        }
    }
}
