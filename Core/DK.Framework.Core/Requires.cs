using System;

namespace DK.Framework.Core
{
    /// <summary>
    /// Static set of verification methods.
    /// </summary>
    public static class Requires
    {
        /// <summary>
        /// Verifies that a variable is not null.
        /// </summary>
        /// <param name="item">The variable to check.</param>
        /// <param name="errorMessage">The error message to publish if the variable is null.</param>
        /// <exception cref="ArgumentNullException">Thrown if the variable is null.</exception>
        public static void IsNotNull(object item, string errorMessage)
        {
            if (null == item)
            {
                throw new ArgumentNullException(errorMessage);
            }
        }

        /// <summary>
        /// Checks if a condition is true.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="errorMessage">The error message to publish if the condition isn't true.</param>
        /// <exception cref="ArgumentException">Thrown if the condition is not true.</exception>
        public static void IsTrue(bool condition, string errorMessage)
        {
            if (!condition)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        /// <summary>
        /// Checks if a condition is false.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="errorMessage">The error message to publish if the condition isn't false.</param>
        /// <exception cref="ArgumentException">Thrown if the condition is not false.</exception>
        public static void IsNotTrue(bool condition, string errorMessage)
        {
            if (condition)
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
