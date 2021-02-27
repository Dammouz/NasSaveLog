using NUnit.Framework;
using NasSaveLog.ViewModel;

namespace NasSaveLog.Tests.ViewModel
{
    [TestFixture]
    public sealed class NasSaveLogViewModelTests
    {
        [Test]
        public void GivenANasLogViewModel_WhenChangingAnErrorProperty_ThenShouldChangeErrorType()
        {
            var vm = new NasSaveLogViewModel();
            var nasSaveLog = vm.LogObjectViewModel;
            Assert.That(nasSaveLog.IsError, Is.EqualTo(false), "Is Error is not equals or initialized to 'false'.");
            vm.IsError = true;
            Assert.That(nasSaveLog.IsError, Is.EqualTo(true), $"LogObjectViewModel.IsError hasn't been changed.");
        }
    }
}
