using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableClassLibrary.Helpers
{
    public class TemperatureConverter
    {
        private static string TAG = "TemperatureConverter";
        /// <summary>
        /// Method handles converting from Kelvin to Celcius
        /// </summary>
        /// <param name="kelvin"></param>
        /// <returns></returns>
        public static double convertToCelcius(double kelvin)
        {
            double newKelvin = 0.0;
            double rounded = 0.0;
            try
            {
                Log.d(TAG, "START | convertToCelcius");
                newKelvin = kelvin - 273.15;
                rounded = Math.Round(newKelvin, 1);
            }
            catch (Exception ex)
            {
                Log.e(TAG, "ERR | Failed to convert to celcius because" + ex.Message);
            }
            return rounded;
        }
    }
}
