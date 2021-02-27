using NUnit.Framework;

namespace Common.Tests
{
    [TestFixture]
    public sealed class CommonDebugToolsTests
    {
        [Ignore("UT not finish")]
        [TestCase("Hello !", "coucou", 1)]
        [TestCase(5, 0, 1)]
        public void GivenAnObject_WhenTryToVarDump_ThenShouldReturnCorrectString(object varToDump, object expectedResult, int recursion)
        {
            // Arrange & Act
            var resultOfVarDump = CommonDebugTools.VarDump(varToDump, recursion);

            // Assert
            Assert.That(resultOfVarDump, Is.EqualTo(expectedResult), $"Essaye encore de trouver le VarDump de {varToDump}, type: {varToDump.GetType().Name} depth: {recursion}");
        }
    }
}
