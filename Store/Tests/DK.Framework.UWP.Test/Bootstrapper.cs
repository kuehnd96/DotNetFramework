using DK.Framework.UWP;
using System.Reflection;

namespace DK.Framework.Store.WinPhone8.Tests
{
    /// <summary>
    /// MEF bootstrapper for unit tests.
    /// </summary>
    internal class Bootstrapper
    {
        static bool _isStarted = false;
        static object _syncRoot = new object();

        /// <summary>
        /// Starts composition.
        /// </summary>
        internal static void Startup()
        {
            lock (_syncRoot)
            {
                if (_isStarted)
                {
                    return;
                }

                CompositionStarter starter = new CompositionStarter(null, null);
                starter.Configure(typeof(Bootstrapper).GetTypeInfo().Assembly, typeof(CompositionStarter).GetTypeInfo().Assembly);

                _isStarted = true; 
            }
        }
    }
}
