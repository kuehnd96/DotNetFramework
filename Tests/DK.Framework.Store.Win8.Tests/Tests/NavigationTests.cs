using DK.Framework.Core.Interfaces;
using DK.Framework.Store.Win8.Tests.Mocks;
using DK.Framework.Store.Win8.Tests.ViewModels;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace DK.Framework.Store.Win8.Tests
{
    [TestClass]
    public class NavigationTests
    {
        INavigationService _navigationService;
        INavigationTarget _navigationTarget;

        [TestInitialize]
        public void Initialize()
        {
            Bootstrapper.Startup();
            
            _navigationService = Initializer.GetSingleExport<INavigationService>();
            _navigationTarget = Initializer.GetSingleExport<INavigationTarget>();
        }

        [TestMethod]
        //[Description("Test to ensure basic navigation works.")]
        public void NaviagationTest()
        {
            _navigationService.Navigate<IScreen<TestViewModel>>();

            Assert.IsTrue(_navigationTarget.Current is MockScreen, "Current content of navigation target is not instance of TestScreen.");
        }

        [TestMethod]
        //[Description("Test to ensure navigation works w/ an initializer.")]
        public void NavigationInitializationTest()
        {
            int count = 2;
            string label = "Go Packers!";

            _navigationService.Navigate<IScreen<TestViewModel>>(screen =>
            {
                screen.ViewModel.Count = count;
                screen.ViewModel.Label = label;
            });

            Assert.IsTrue(_navigationTarget.Current is MockScreen, "Current content of navigation target is not instance of MockScreen.");

            var mockScreen = _navigationTarget.Current as MockScreen;

            Assert.AreEqual<int>(count, mockScreen.ViewModel.Count, "Count was not initialized properly.");
            Assert.AreEqual<string>(label, mockScreen.ViewModel.Label, "Label was not initialized properly.");
        }
    }
}
