using DK.Framework.Core.Interfaces;
using DK.Framework.Store.WinPhone8.Tests.Mocks;
using DK.Framework.Store.WinPhone8.Tests.ViewModels;
using DK.Framework.UWP;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.ComponentModel;

namespace DK.Framework.Store.WinPhone8.Tests
{
    //Tests the navigation service.
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
        //Test to ensure basic navigation works
        public void NaviagationTest()
        {
            _navigationService.Navigate<IScreen<TestViewModel>>();

            Assert.IsTrue(_navigationTarget.Current is MockScreen, "Current content of navigation target is not instance of TestPage.");
        }

        [TestMethod]
        //Test to ensure navigation works w/ an initializer
        public void NavigationInitializationTest()
        {
            int count = 2;
            string label = "Go Packers!";
            
            _navigationService.Navigate<IScreen<TestViewModel>>(screen =>
                {
                    screen.ViewModel.Count = count;
                    screen.ViewModel.Label = label;
                });

            Assert.IsTrue(_navigationTarget.Current is MockScreen, "Current content of navigation target is not instance of TestPage.");

            var testScreen = _navigationTarget.Current as MockScreen;

            Assert.AreEqual<int>(count, testScreen.ViewModel.Count, "Count was not initialized properly.");
            Assert.AreEqual<string>(label, testScreen.ViewModel.Label, "Label was not initialized properly.");
        }
    }
}
