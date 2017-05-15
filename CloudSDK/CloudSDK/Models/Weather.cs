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
    public class Weather
    {
        public Weather() { }
        [JsonProperty("id")]
        public int id
        {
            get;
            set;
        }
        [JsonProperty("main")]
        public string main
        {
            get;
            set;
        }
        [JsonProperty("description")]
        public string description
        {
            get;
            set;
        }
        [JsonProperty("icon")]
        public string icon
        {
            get;
            set;
        }
    }
}