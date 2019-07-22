using System;
using NUnit.Framework;

namespace Common.Tests
{
    [TestFixture]
    public class CommonTextTests
    {
        [TestCase(DateFormat.Undefined, "12/31/2017 23:59:59")]
        [TestCase(DateFormat.DateDebug, "2017-12-31 23:59:59.1230000")]
        [TestCase(DateFormat.DateFile, "201712312359")]
        [TestCase(DateFormat.DateLong, "20171231235959")]
        [TestCase(DateFormat.Date, "20171231")]
        public void Check_Format_Date(DateFormat format, string expected)
        {
            // Arrange
            var date = new DateTime(2017, 12, 31, 23, 59, 59, 123, DateTimeKind.Utc);

            // Act
            var resultFormatted = CommonText.FormatDate(date, format);

            // Assert
            Assert.That(resultFormatted, Is.EqualTo(expected), "Failed to format.");
        }


        [Test]
        public void Check_LogMsg()
        {
            // Arrange
            var message = "Test de fonction LogMsg().";

            // Act
            var msgLogged = CommonText.LogMsg(message);
            var expected = $"{CommonText.NewLine}{CommonText.FormatDate(DateTime.Now, DateFormat.DateDebug)} : Test de fonction LogMsg().";

            // Assert
            Assert.That(msgLogged, Is.EqualTo(expected),
               $"Mismatching between :{CommonText.NewLine}{msgLogged}{CommonText.NewLine}And expected:{CommonText.NewLine}{expected}");
        }
    }
}
