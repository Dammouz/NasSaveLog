using System;
using Common.Extensions;
using NasSaveLog.Business;
using NUnit.Framework;

namespace NasSaveLog.Tests.Helpers
{
    [TestFixture]
    public sealed class ApplyExtensionsTests
    {
        [Test]
        public void GivenALogNas_ThenShouldDumpAnJsonObject()
        {
            // Arrange
            var softName = "NasSaveLog";
            var logNas = new NasLog
            {
                Content = "content of log nas",
                Contents = new[]
                {
                    "content",
                    "of log nas"
                },
                LogDateTime = new DateTime(2018, 01, 01, 21, 59, 59, 123, DateTimeKind.Utc),
                LogInfo = "MoreInfosToGive",
                IsError = true,
                LogExt = "ext",
                Path = "C:\\titi\\tata"
            };
            var expectedResult = $"{{\"Content\":\"content of log nas\",\"Contents\":[\"content\",\"of log nas\"],\"LogDateTime\":\"2018-01-01T21:59:59.123Z\",\"LogInfo\":\"MoreInfosToGive\",\"IsError\":true,\"LogType\":\"error\",\"LogExt\":\"ext\",\"FullLogName\":\"{softName}-error-201801012159-MoreInfosToGive.ext\",\"Path\":\"C:\\\\titi\\\\tata\",\"FullPath\":\"C:\\\\titi\\\\tata\\\\{softName}-error-201801012159-MoreInfosToGive.ext\"}}";

            // Act
            var result = logNas.DumpUnFormatted();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), "Extension method object.Dump() is not given the expected result.");
        }
    }
}
