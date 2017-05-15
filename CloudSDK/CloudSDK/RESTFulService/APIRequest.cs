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
using CloudSDK.Helper;
using System.Net;
using System.IO;
using CloudSDK.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Android.Graphics;
using System.Threading.Tasks;

namespace CloudSDK.RESTFulService
{
    public class APIRequest : IAPIRequest
    {

        private string TAG = "APIRequest";
        private int retries = 5;
        /// <summary>
        /// Resposible for getting the weather information from the API
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public async Task<OpenWeatherApi> getWeatherConditionInfoAsync(double latitude, double longitude)
        {
            OpenWeatherApi openWeatherObj = null;
            try
            {
                string content = string.Empty;
                int counter = 0;
                Log.d(TAG, "START | ");
                //Base URI
                string URI = Settings.htpp + Settings.BaseURI + "lat=" + latitude + "&lon=" + longitude + "&appid=" + Settings.apiKey;
                openWeatherObj = new OpenWeatherApi();
                //Http client
                using (var client = new WebClient())
                {
                    client.Headers.Add("Authorization", Settings.apiKey);
                    client.Headers.Add("content-type", "application/json");
                    do
                    {
                        //Open stream and reading content from it.
                         content = await client.DownloadStringTaskAsync(URI);
                         Log.d(TAG, "Content " + content);
                         JsonConvert.PopulateObject(content, openWeatherObj);
                         Log.d(TAG, "Object populated");
                         counter++;
                         Log.d(TAG, "Retry " + counter);
                         Log.d(TAG, "Cod " + openWeatherObj.cod);

                    }
                    while (openWeatherObj.cod != 200 && counter  < retries);
                }

                Log.d(TAG, "END | getWeatherConditionInfo");
            }
            catch (Exception ex)
            {
                Log.e(TAG, "Failed to get weather information from the API because " + ex.StackTrace);
                
            }
            return openWeatherObj;
        }

        /// <summary>
        /// Method handles downloading image from URI
        /// </summary>
        /// <param name="iconCode"></param>
        /// <returns></returns>
        async Task IAPIRequest.getImageBitMapFromURL(string iconCode)
        {
            try
            {
                Log.d(TAG, "START | getImageBitMapFromURL");
                string URI = Settings.htpp + Settings.bitMapImageURI + iconCode + ".png";
                Log.d(TAG, "Image URI " + URI);
                WebClient client = new WebClient();
                Log.d(TAG, "URI " + URI);
                var imageBytes = await client.DownloadDataTaskAsync(URI);
                if (imageBytes !=null && imageBytes.Length > 0)
                {
                    AppState.Instance.bitMapImage = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
               
            }
            catch (Exception ex)
            {
                Log.e(TAG, "Failed to get image because : " + ex.Message);
            }
        }

       
    }
}