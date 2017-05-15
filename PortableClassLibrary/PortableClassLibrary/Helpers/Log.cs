using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableClassLibrary.Helpers
{
    public class Log
    {
        /// <summary>
        /// Used when logging errors
        /// </summary>
        /// <param name="TAG"></param>
        /// <param name="message"></param>
        public static void e(string TAG, string message)
        {
            if (PCLSettings.isDebugOn == true)
            {
                Debug.WriteLine(TAG + "  |  " + message);
            }
        }
        /// <summary>
        /// Used for standard debugging
        /// </summary>
        /// <param name="TAG"></param>
        /// <param name="message"></param>
        public static void d(string TAG, string message)
        {
            if (PCLSettings.isDebugOn == true)
            {
                Debug.WriteLine(TAG + "  |  " + message);
            }
        }
    }
}
