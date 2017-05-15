using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PortableClassLibrary.Helpers
{
    public class AppSingleton
    {
        private static AppSingleton instance = null;
        private AppSingleton() { }
        public static AppSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppSingleton();
                }
                return instance;
            }
        }

        public bool isLocationOn = false;
        //stores maximum temperature
        public double maximumTemperature = 0.0;
        //stores minimum temperature
        public double minimumTemparature = 0.0;
        //stores the name of the place the temperature is being displayed for.
        public string nameOfPlace = string.Empty;
        //stores temperature
        public double temperature = 0.0;
        //stores weathertype
        public int weatherType = 0;
        public DateTime dateTime;
        //handles image icon
        public string imgIcon = string.Empty;
        public string weatherDescription = string.Empty;
        //latitude
        public double latitude = 0.0;
        //longetude
        public double longetude = 0.0;

        public bool retryApp = false;
  

    }
}
