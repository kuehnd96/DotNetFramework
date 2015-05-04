using System;

namespace DK.Framework.Core
{
    /// <summary>
    /// Houses helper methods for unit tests.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Determines if two dates are the same second in time.
        /// </summary>
        /// <param name="first">The first date time to check.</param>
        /// <param name="second">The second date time to check.</param>
        /// <returns>True if they are the same second in time; Otherwise false.</returns>
        protected bool AreSameSecond(DateTime first, DateTime second)
        {
            return ((first.Year == second.Year) &&
                    (first.Month == second.Month) &&
                    (first.Day == second.Day) &&
                    (first.Hour == second.Hour) &&
                    (first.Minute == second.Minute) &&
                    (first.Second == second.Second));
        }

        /// <summary>
        /// Determines if two nullable dates are the same second in time.
        /// </summary>
        /// <param name="first">The first date time to check.</param>
        /// <param name="second">The second date time to check.</param>
        /// <returns>True if both are null; False if one is null; Otherwise true if they are the same second in time.</returns>
        protected bool AreSameSecond(DateTime? first, DateTime? second)
        {
            if (first.HasValue && second.HasValue)
            {
                return AreSameSecond(first.Value, second.Value);
            }

            // They are the "same" if they are both null
            if (!first.HasValue && !second.HasValue)
            {
                return true;
            }

            return false;
        }
    }
}
