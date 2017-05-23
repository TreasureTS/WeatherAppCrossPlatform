using PortableClassLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSDK.Adapter;
using CloudSDK.Models;
using System.Threading;

namespace PortableClassLibrary.Controllers
{
    public class WeatherController 
    {
        private static string TAG = "WeatherAppController";
        private static int numOfRetries = 5;
  
        public static async Task setupWeatherApplication(double latitude, double longitude)
        {
            
            try
            {
                Log.d(TAG,"START | getCurrentWeatherCondition");
                //api call to get the current weather condition
                OpenWeatherApi openWeaherAPI = await WeatherAdapter.getWeatherConditionInfoAsync(latitude, longitude);
                Log.d(TAG, "Success code " + openWeaherAPI.cod);
                if (openWeaherAPI.cod != 0)

                {
                    AppSingleton.Instance.success = true;
                    AppSingleton.Instance.maximumTemperature = openWeaherAPI.main.temp_max;
                    AppSingleton.Instance.minimumTemparature = openWeaherAPI.main.temp_min;
                    AppSingleton.Instance.temperature = openWeaherAPI.main.temp;
                    AppSingleton.Instance.nameOfPlace = openWeaherAPI.name;
                    Log.d(TAG, "Temperature " + AppSingleton.Instance.temperature);
                    //getting the image icon
                    foreach (var i in openWeaherAPI.weather)
                    {
                        AppSingleton.Instance.imgIcon = i.icon;
                        AppSingleton.Instance.weatherDescription = i.description;
                        Log.d(TAG, "Weather ID " + i.id);
                    }
                    AppSingleton.Instance.imageByte = await getImageBytes(AppSingleton.Instance.imgIcon);
                }
                else
                {
                    AppSingleton.Instance.success = false;
                }
                Log.d(TAG, "END | getCurrentWeatherCondition");

            }
            catch (Exception ex)
            {
                Log.e(TAG, "ERR | getCurrentWeatherCondition = " + ex.Message);
            }
        }

        /// <summary>
        /// Method handle getting the image icon
        /// </summary>
        /// <param name="iconId"></param>
        /// <returns></returns>

        public static async  Task<byte[]> getImageBytes(string iconId)
        {
            Byte[] imageBytes = null;
            try
            {
                Log.d(TAG, "START | Get Image Icon");
                if (!string.IsNullOrEmpty(iconId))
                {
                    imageBytes =  await WeatherAdapter.getWeatherImage(iconId);
                    Log.d(TAG, "END | Get Image Icon");
                }

            }
            catch (Exception ex)
            {
                Log.e(TAG, "ERR | getImageICon " + ex.Message);
            }
            return imageBytes;
        }
    }
}
