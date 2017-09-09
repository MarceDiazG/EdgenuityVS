using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pages.Helpers
{
    /// <summary>
    /// SleepHelper is a helper class to manage sleeps in the current thread execution.
    /// </summary>
    public class SleepHelper
    {
        /// <summary>
        /// Sleeps thread execution during the desiarabled seconds.
        /// </summary>
        /// <param name="seconds">the seconds to sleep</param>
        public static void Sleep(int seconds)
        {
            if (Environment.EnvironmentReader.Sleep)
            {
                Thread.Sleep(seconds * 1000);
            }
        }
    }
}
