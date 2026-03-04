using System;
using Common.Constants;
using Common.Enums;
using Common.Text;
using NUnit.Framework;

namespace Common.Tests.Text
{
    [TestFixture]
    public sealed class LogTests
    {
        [Test]
        public void GivenAMessage_WhenLogging_ThenShouldReturnCompleteMatchingWithTime()
        {
            // Arrange
            // ReSharper disable once ConvertToConstant.Local
            var message = "Test de fonction LogMsg().";

            // Act
            var mesageLogged = Log.LogMessage(message);
            var expectedLogging = $"{TextConstants.NewLine}{DateHelper.FormatDate(DateTime.UtcNow, DateFormat.DateLog)} : Test de fonction LogMsg().";

            // Assert
            Assert.That(mesageLogged, Is.EqualTo(expectedLogging),
               $"Mismatching after logging:{TextConstants.NewLine}{mesageLogged}{TextConstants.NewLine}And expected:{TextConstants.NewLine}{expectedLogging}");
        }
    }
}
