using System;
using NUnit.Framework;

namespace Common.Tests
{
    [TestFixture]
    public sealed class CommonTextTests
    {
        [TestCase(DateFormat.Undefined, "12/31/2017 23:59:59")]
        [TestCase(DateFormat.DateDebug, "2017-12-31 23:59:59.1230000")]
        [TestCase(DateFormat.DateFile, "201712312359")]
        [TestCase(DateFormat.DateLong, "20171231235959")]
        [TestCase(DateFormat.Date, "20171231")]
        public void GivenADate_WithSpecialFormat_ThenShouldReturnExpectedFormat(DateFormat format, string expected)
        {
            // Arrange
            var date = new DateTime(2017, 12, 31, 23, 59, 59, 123, DateTimeKind.Utc);

            // Act
            var resultFormatted = CommonText.FormatDate(date, format);

            // Assert
            Assert.That(resultFormatted, Is.EqualTo(expected), "Failed to format.");
        }


        [Test]
        public void GivenAMessage_WhenLogging_ThenShouldReturnCompleteMatchingWithTime()
        {
            // Arrange
            var message = "Test de fonction LogMsg().";

            // Act
            var mesageLogged = CommonText.LogMsg(message);
            var expectedLogging = $"{ComonTextConstants.NewLine}{CommonText.FormatDate(DateTime.UtcNow, DateFormat.DateLog)} : Test de fonction LogMsg().";

            // Assert
            Assert.That(mesageLogged, Is.EqualTo(expectedLogging),
               $"Mismatching after logging:{ComonTextConstants.NewLine}{mesageLogged}{ComonTextConstants.NewLine}And expected:{ComonTextConstants.NewLine}{expectedLogging}");
        }
    }
}
