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
using Newtonsoft.Json;

namespace CloudSDK.Models
{
    public class OpenWeatherApi
    {
        public OpenWeatherApi() { }
        [JsonProperty("coord")]
        public coord coord
        {
            get;
            set;
        }
        [JsonProperty("weather")]
        public List<Weather> weather
        {
            get;
            set;
        }
       
        [JsonProperty("main")]
        public Main main
        {
            get;
            set;
        }
        [JsonProperty("wind")]
        public Wind wind
        {
            get;
            set;
        }
        [JsonProperty("clouds")]
        public Clouds clouds
        {
            get;
            set;
        }
        [JsonProperty("dt")]
        public int dt
        {
            get;
            set;
        }
        [JsonProperty("sys")]
        public Sys sys
        {
            get;
            set;
        }

        [JsonProperty("id")]
        public int id
        {
            get;
            set;
        }
        [JsonProperty("name")]
        public string name
        {
            get;
            set;
        }
        [JsonProperty("cod")]
        public int cod
        {
            get;
            set;
        }
        [JsonProperty("base")]
        public string bases
        {
            get;
            set;
        }

    }
}