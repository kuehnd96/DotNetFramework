using DK.Framework.Core.Interfaces;
using DK.Framework.UWP.Attributes;
using DK.Framework.Store.WinPhone8.Tests.ViewModels;
using System;
using System.ComponentModel;
using System.Composition;

namespace DK.Framework.Store.WinPhone8.Tests.Mocks
{
    /// <summary>
    /// Mock screen for tests.
    /// </summary>
    [Screen(typeof(IScreen<TestViewModel>))]
    [Shared]
    public class MockScreen : IScreen<TestViewModel>
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public TestViewModel ViewModel { get; set; }

        public string Title { get; set; }

        public MockScreen()
        {
            ViewModel = new TestViewModel();
        }

        public void Start(Action completed)
        {
            completed();
        }

        public void End(Action completed)
        {
            completed();
        }

        public Type ScreenType
        {
            get { return typeof(MockScreen); }
        }

        /// <summary>
        /// The relative location of the screen.
        /// </summary>
        public string Location { get { return "Mock.xaml"; } }
    }
}
