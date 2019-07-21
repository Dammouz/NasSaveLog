using NUnit.Framework;
using SaveFileLogNAS.ViewModel;

namespace SaveFileLogNAS.Tests
{
   [TestFixture]
   public class SaveFileLogNASViewModelTests
   {
      [Test]
      public void ShouldChangeErrorType()
      {
         var vm = new SaveFileLogNASViewModel();
         var saveFileLogNAS = vm.LogObjectViewModel;
         Assert.That(saveFileLogNAS.IsError, Is.EqualTo(false), "Is Error is not equals or initialized to 'false'.");
         vm.IsError = true;
         Assert.That(saveFileLogNAS.IsError, Is.EqualTo(true), $"LogObjectViewModel.IsError hasn't been changed.");
      }
   }
}
