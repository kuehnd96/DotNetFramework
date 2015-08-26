using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.Framework.UWP.Exceptions
{
    /// <summary>
    /// An exception that is thrown from the <see cref="SuspensionManager"/>.
    /// </summary>
    public class SuspensionManagerException : Exception
    {
        public SuspensionManagerException()
        {
        }

        public SuspensionManagerException(Exception e)
            : base("SuspensionManager failed", e)
        {

        }
    }
}
