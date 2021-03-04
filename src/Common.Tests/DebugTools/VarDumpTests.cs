using Common.DebugTools;
using NUnit.Framework;

namespace Common.Tests.DebugTools
{
    [TestFixture]
    public sealed class VarDumpTests
    {
        [TestCase(5, "5")]
        [TestCase("Hello !", "\"Hello !\"")]
        [TestCase(new[] { "toto", "tata" }, @"[
  ""toto"",
  ""tata""
]")]
        public void GivenSimpleObject_WhenDumping_ThenShouldReturnCorrectString(object varToDump, object expectedResult)
        {
            // Arrange & Act
            var resultOfVarDump = VarDump.VarDumpJson(varToDump);

            // Assert
            Assert.That(resultOfVarDump, Is.EqualTo(expectedResult), $"Essaye encore de trouver le VarDump de {varToDump}, type: {varToDump.GetType().Name}, depth: 1");
        }

        [Test]
        public void GivenMoreComplexObject_WhenDumping_ThenShouldReturnCorrectString()
        {
            // Arrange
            object varToDump = new
            {
                Id = 42,
                PropertyString = "toto",
                PropertyDouble = 4.2,
                PropertyObject = new
                {
                    SubProperty1 = "SubObject",
                    SubProperty2 = 422
                }
            };
            var expectedDump = @"{
  ""Id"": 42,
  ""PropertyString"": ""toto"",
  ""PropertyDouble"": 4.2,
  ""PropertyObject"": {
    ""SubProperty1"": ""SubObject"",
    ""SubProperty2"": 422
  }
}";

            // Act
            var resultOfVarDump = VarDump.VarDumpJson(varToDump);

            // Assert
            Assert.That(resultOfVarDump, Is.EqualTo(expectedDump), $"Essaye encore de trouver le VarDump de {varToDump}");
        }
    }
}
