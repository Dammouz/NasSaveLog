using Common.Extensions;
using NUnit.Framework;

namespace Common.Tests.Extensions
{
    [TestFixture]
    public sealed class StringExtensionsTests
    {
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", true)]
        [TestCase("string", true)]
        public void GivenAString_ThenShouldReturnIfStringIsNotEmptyNorNull(string toCheck, bool expectedResult)
        {
            // Act
            var result = toCheck.IsNotNullNorEmpty();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), "Extension method string.IsNotNullNorEmpty() is not given the expected result.");
        }
    }
}
