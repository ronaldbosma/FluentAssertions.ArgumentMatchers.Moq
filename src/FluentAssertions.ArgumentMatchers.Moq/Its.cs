using System;
using System.Diagnostics;
using FluentAssertions.Equivalency;
using Moq;

namespace FluentAssertions.ArgumentMatchers.Moq
{
    /// <summary>
    /// Contains helper methods that combine fuctionality of Moq and FluentAssertions
    /// to make it easier to work with complex input parameters in mocks.
    /// </summary>
    public static class Its
    {
        /// <summary>
        /// Matches any value that is equivalent to <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="TValue">Type of the argument to check.</typeparam>
        /// <param name="expected">The expected object to match.</param>
        public static TValue EquivalentTo<TValue>(TValue expected)
        {
            return EquivalentTo(expected, config => config);
        }

        /// <summary>
        /// Matches any value that is equivalent to <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="TValue">Type of the argument to check.</typeparam>
        /// <param name="expected">The expected object to match.</param>
        /// <param name="config">
        /// A reference to the <seealso cref="EquivalencyAssertionOptions{TValue}"/>
        /// configuration object that can be used to influence the way the object graphs
        /// are compared. You can also provide an alternative instance of the <seealso cref="EquivalencyAssertionOptions{TValue}"/> class.
        /// The global defaults are determined by the <seealso cref="AssertionOptions"/> class.
        /// </param>
        public static TValue EquivalentTo<TValue>(TValue expected,
            Func<EquivalencyAssertionOptions<TValue>, EquivalencyAssertionOptions<TValue>> config)
        {
            return Match.Create(
                (actual, _) => AreEquivalent(actual, expected, config),
                //this second parameter is used in error messages to display what the expression is
                () => EquivalentTo(expected)
            );
        }

        private static bool AreEquivalent<TValue>(object actual, TValue expected,
            Func<EquivalencyAssertionOptions<TValue>, EquivalencyAssertionOptions<TValue>> config)
        {
            try
            {
                actual.Should().BeEquivalentTo(expected, config);
                return true;
            }
            catch (Exception ex)
            {
                // Although catching an Exception to return false is a bit ugly
                // the great advantage is that we can log the error message of FluentAssertions.
                // This makes it easier to troubleshoot why a Mock was not called with the expected parameters.

                Trace.WriteLine($"Actual and expected of type {typeof(TValue)} are not equal. Details:");
                Trace.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
