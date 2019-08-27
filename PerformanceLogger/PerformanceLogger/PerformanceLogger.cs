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
        /// <typeparam name="T">Operation Result</typeparam>
        /// <param name="type">Logger Instance (use GetType())</param>
        /// <param name="operationName">Operation Name</param>
        /// <param name="operation">operation to log</param>
        /// <returns></returns>
        public T Log<T>(Type type, string operationName, Func<T> operation)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = operation();
            stopwatch.Stop();

            return result;
        }

        /// <summary>
        /// Asynchronously logs the time taken for particular operation
        /// </summary>
        /// <typeparam name="T">Operation Result</typeparam>
        /// <param name="type">Logger Instance (use GetType())</param>
        /// <param name="operationName">Operation Name</param>
        /// <param name="operation">Operation to log</param>
        /// <returns></returns>
        public async Task<T> LogAsync<T>(Type type, string operationName, Func<Task<T>> operation)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = await operation();
            stopwatch.Stop();

            return result;
        }
    }
}
