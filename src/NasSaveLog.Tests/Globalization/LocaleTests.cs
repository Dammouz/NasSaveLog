using NasSaveLog.Globalization;
using NUnit.Framework;

namespace NasSaveLog.Tests.Globalization
{
    [TestFixture]
    public sealed class LocaleTests
    {
        [Test]
        public void GivenFrenchIsoCode_ThenShouldRetrieveFrenchGuiObject()
        {
            // Arrange & Act
            IGui localeGui = LocaleHelper.GetLocaleGui("fr-FR");

            // Assert
            Assert.That(localeGui, Is.TypeOf(typeof(GuiFrench)), "French GUI is choosen when selected.");
        }

        [TestCase(null)]
        [TestCase("en-US")]
        [TestCase("WrongIsoCode")]
        public void GivenEnglishIsoCodeOrNothing_ThenShouldRetrieveEnglishGuiObject(string isoCode)
        {
            // Arrange & Act
            IGui localeGui = LocaleHelper.GetLocaleGui(isoCode);

            // Assert
            Assert.That(localeGui, Is.TypeOf(typeof(GuiEnglish)), "English GUI is choosen if selected or by default.");
        }
    }
}
