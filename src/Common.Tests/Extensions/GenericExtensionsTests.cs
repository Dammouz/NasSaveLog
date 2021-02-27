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
    }
}
