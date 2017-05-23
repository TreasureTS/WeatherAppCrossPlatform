﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.Threading.Tasks;
using CloudSDK.Models;

namespace CloudSDK.RESTFulService
{
    public interface IAPIRequest
    {
        /// <summary>
        /// Resposible for getting the weather information from the API
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        Task<OpenWeatherApi> getWeatherConditionInfoAsync(double latitude, double longitude);
        Task<byte[]> getWeatherImage(string code);
    }
}