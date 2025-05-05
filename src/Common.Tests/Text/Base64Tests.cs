using Common.Text;
using NUnit.Framework;

namespace Common.Tests.Text
{
    [TestFixture]
    public sealed class Base64Tests
    {
        [Test]
        public void Convertb64()
        {
            // Arrange
            const string CodeToEncode = "MyCodeToto123";

            // Act
            var base64Encoded = Base64.Base64Encode(CodeToEncode);
            var base64Decoded = Base64.Base64Decode(base64Encoded);

            // Assert
            Assert.That(base64Decoded, Is.EqualTo(CodeToEncode),
               $"We should have decoded base 64 with is equal to the initial {nameof(CodeToEncode)}");
        }
    }
}
