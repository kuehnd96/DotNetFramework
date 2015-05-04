using DK.Framework.Core.Interfaces;
using System;
using System.Composition;

namespace DK.Framework.Store.Win8.Tests.Mocks
{
    /// <summary>
    /// Mock navigation target for tests.
    /// </summary>
    [Export(typeof(INavigationTarget))]
    [Shared]
    public class MockNavigationTarget : INavigationTarget
    {
        public void Show(IScreen screen)
        {
            Current = screen;
        }

        public void Show(IScreen screen, Action<IScreen> initAction)
        {
            initAction(screen);
            Current = screen;
        }

        public IScreen Current { get; private set; }

        public void GoHome()
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void GoForward()
        {
            throw new NotImplementedException();
        }

        public bool CanGoBack()
        {
            throw new NotImplementedException();
        }

        public bool CanGoForward()
        {
            throw new NotImplementedException();
        }
    }
}
