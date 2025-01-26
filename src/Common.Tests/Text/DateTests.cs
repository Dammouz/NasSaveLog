using System;
using Common.Enums;
using Common.Text;
using NUnit.Framework;

namespace Common.Tests.Text
{
    [TestFixture]
    public sealed class DateTests
    {
        [TestCase(DateFormat.Undefined, "12/31/2017 23:59:59")]
        [TestCase(DateFormat.DateDebug, "2017-12-31 23:59:59.1230000")]
        [TestCase(DateFormat.DateFile, "201712312359")]
        [TestCase(DateFormat.DateLong, "20171231235959")]
        [TestCase(DateFormat.Date, "20171231")]
        [TestCase(DateFormat.DateHuman, "31/12/2017 23:59:59")]
        public void GivenADate_WithSpecialFormat_ThenShouldReturnExpectedFormat(DateFormat format, string expected)
        {
            // Arrange
            var date = new DateTime(2017, 12, 31, 23, 59, 59, 123, DateTimeKind.Utc);

            // Act
            var resultFormatted = Date.FormatDate(date, format);

            // Assert
            Assert.That(resultFormatted, Is.EqualTo(expected), "Failed to format.");
        }
    }
}
