using NUnit.Framework;

namespace Common.Tests
{
    [TestFixture]
    public class CommonDebugToolsTests
    {
        [Ignore("UT not finish")]
        [TestCase("Hello !", "coucou", 1)]
        [TestCase(5, 0, 1)]
        public void Check_if_VarDump_working(object varToDump, object expectedResult, int recursion)
        {
            var resultOfVarDump = CommonDebugTools.VarDump(varToDump, recursion);
            Assert.That(resultOfVarDump, Is.EqualTo(expectedResult), $"Essaye encore de trouver le VarDump de {varToDump}, type: {varToDump.GetType().Name} depth: {recursion}");
        }
    }
}
