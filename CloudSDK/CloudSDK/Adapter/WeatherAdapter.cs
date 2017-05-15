using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CloudSDK.RESTFulService;
using CloudSDK.Helper;
using Android.Graphics;
using System.Threading.Tasks;
using CloudSDK.Models;

namespace CloudSDK.Adapter
{
    public class WeatherAdapter
    {
        private static string TAG = "WeatherAdapter";
        public static async Task<OpenWeatherApi> getWeatherConditionInfoAsync(double latitute, double longitude)
        {
            OpenWeatherApi weatherAPi = null;
            try
            {
                Log.d(TAG, "START | getWeatherConditionInfo Adapter ");
                IAPIRequest api = new APIRequest();
                weatherAPi = await api.getWeatherConditionInfoAsync(latitute, longitude);
                //isThereResponses = await isThereResponse;
                Log.d(TAG, "END | getWeatherConditionInfo Adapter ");
            }
            catch (Exception ex)
            {
                Log.e(TAG, "Failed to get weather info because " + ex.Message);

            }
            return weatherAPi;
        }

        public async static Task getImageBitMapFromURL(string imgIcon)
        {
            try
            {
                IAPIRequest api = new APIRequest();
                Log.d(TAG, "START | getImageBitMapFromURL ");
                await api.getImageBitMapFromURL(imgIcon);
            }
            catch(Exception ex)
            {
                Log.e(TAG, "ERR | getImageBitMapFromURL " + ex.Message);
            }
        }


    }
}