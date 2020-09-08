using NUnit.Framework;
using SaveFileLogNAS.Globalization;

namespace SaveFileLogNAS.Tests.Globalization
{
    [TestFixture]
    class LocaleTests
    {
        [Test]
        public void GivenFrenchIsoCode_ShouldRetrieveFrenchGuiObject()
        {
            // Arrange & Act
            IGui localeGui = LocaleHelper.GetLocaleGui("fr-FR");

            // Assert
            Assert.That(localeGui, Is.TypeOf(typeof(GuiFrench)), "French GUI is choosen when selected.");
        }

        [TestCase(null)]
        [TestCase("en-US")]
        [TestCase("WrongIsoCode")]
        public void GivenEnglishIsoCodeOrNothing_ShouldRetrieveEnglishGuiObject(string isoCode)
        {
            // Arrange & Act
            IGui localeGui = LocaleHelper.GetLocaleGui(isoCode);

            // Assert
            Assert.That(localeGui, Is.TypeOf(typeof(GuiEnglish)), "English GUI is choosen if selected or by default.");
        }
    }
}
