using System;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Tests.Extensions
{
    [TestFixture]
    public sealed class GenericExtensionsTests
    {
        [Test]
        public void GivenAString_ThenShouldDumpAsOneValue()
        {
            // Act
            var result = "string dump".Dump();

            // Assert
            Assert.That(result, Is.EqualTo("\"string dump\""), "Extension method object.Dump() is not given the expected result.");
        }

        [Test]
        public void GivenAnInt_ThenShouldDumpAsOneValue()
        {
            // Act
            var result = 1.Dump();

            // Assert
            Assert.That(result, Is.EqualTo("1"), "Extension method object.Dump() is not given the expected result.");
        }

        [Test]
        public void GivenAnObjectNull_ThenShouldDumpAsOneValue()
        {
            // Arrange
            object nullObject = null;

            // Act
            var result = nullObject.Dump();

            // Assert
            Assert.That(result, Is.EqualTo("null"), "Extension method object.Dump() is not given the expected result.");
        }

        [Test]
        public void GivenAMoreComplexObject_WhenformattedThenShouldDumpAJsonObject()
        {
            // Arrange
            var moreComplexObject = new
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

            var expectedResult = @"{
  ""Content"": ""content of log nas"",
  ""Contents"": [
    ""content"",
    ""of log nas""
  ],
  ""LogDateTime"": ""2018-01-01T21:59:59.123Z"",
  ""LogInfo"": ""MoreInfosToGive"",
  ""IsError"": true,
  ""LogExt"": ""ext"",
  ""Path"": ""C:\\titi\\tata""
}";
            // Act
            var result = moreComplexObject.Dump();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), "Extension method object.Dump() is not given the expected result.");
        }

        [Test]
        public void GivenAComplexObject_WhenUnformattedThenShouldDumpAJsonObject()
        {
            // Arrange
            var logNas = new
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
            //var expectedResult = "{{\"Content\":\"content of log nas\",\"Contents\":[\"content\",\"of log nas\"],\"LogDateTime\":\"2018-01-01T21:59:59.123Z\",\"LogInfo\":\"MoreInfosToGive\",\"IsError\":true,\"LogType\":\"error\",\"LogExt\":\"ext\",\"FullLogName\":\"{softName}-error-201801012159-MoreInfosToGive.ext\",\"Path\":\"C:\\\\titi\\\\tata\",\"FullPath\":\"C:\\\\titi\\\\tata\\\\{softName}-error-201801012159-MoreInfosToGive.ext\"}}";
            var expectedResult = @"{""Content"":""content of log nas"",""Contents"":[""content"",""of log nas""],""LogDateTime"":""2018-01-01T21:59:59.123Z"",""LogInfo"":""MoreInfosToGive"",""IsError"":true,""LogExt"":""ext"",""Path"":""C:\\titi\\tata""}";
            // Act
            var result = logNas.DumpUnFormatted();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), "Extension method object.DumpUnFormatted() is not given the expected result.");
        }
    }
}
