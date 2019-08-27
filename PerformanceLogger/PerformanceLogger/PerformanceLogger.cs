using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PerformanceLogger
{
    /// <summary>
    /// Utilty to calculate performance for operation.
    /// </summary>
    public class PerformanceLogger
    {
        /// <summary>
        /// Logs the time taken for particular operation
        /// </summary>
        /// <typeparam name="T">Method Result</typeparam>
        /// <param name="type">Logger Type (use GetType())</param>
        /// <param name="methodName">Method Name</param>
        /// <param name="method">Method to log</param>
        /// <returns></returns>
        public T Log<T>(Type type, string methodName, Func<T> method)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = method();
            stopwatch.Stop();

            return result;
        }

        /// <summary>
        /// Asynchronously logs the time taken for particular operation
        /// </summary>
        /// <typeparam name="T">Method Result</typeparam>
        /// <param name="type">Logger Type (use GetType())</param>
        /// <param name="methodName">Method Name</param>
        /// <param name="method">Method to log</param>
        /// <returns></returns>
        public async Task<T> LogAsync<T>(Type type, string methodName, Func<Task<T>> method)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = await method();
            stopwatch.Stop();

            return result;
        }
    }
}
