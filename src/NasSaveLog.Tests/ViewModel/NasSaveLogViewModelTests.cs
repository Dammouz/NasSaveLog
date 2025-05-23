using NasSaveLog.ViewModel;
using NUnit.Framework;

namespace NasSaveLog.Tests.ViewModel
{
    [TestFixture]
    public sealed class NasSaveLogViewModelTests
    {
        [Test]
        public void GivenANasLogViewModel_WhenChangingAnErrorProperty_ThenShouldChangeErrorType()
        {
            // Arrange
            var vm = new NasSaveLogViewModel();
            var nasSaveLog = vm.LogObjectViewModel;
            Assert.That(nasSaveLog.IsError, Is.False, "Is Error is not equals or initialized to 'false'.");

            // Act
            vm.IsError = true;

            // Assert
            Assert.That(nasSaveLog.IsError, Is.True, $"LogObjectViewModel.IsError hasn't been changed.");
        }
    }
}
