using Common.Extensions;
using NUnit.Framework;

namespace Common.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("string", true)]
        public void GivenString_ShouldReturnIfStringIsNotEmptyNorNull(string toCheck, bool expectedResult)
        {
            // Act
            var result = toCheck.IsNotNullNorEmpty();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), "Extension method string.IsNotNullNorEmpty() is not given the expected result.");
        }
    }
}
