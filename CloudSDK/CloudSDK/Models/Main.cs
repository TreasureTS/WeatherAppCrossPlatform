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
    public class Main
    {
        public Main() { }
        [JsonProperty("temp")]
        public double temp
        {
            get;
            set;
        }
        [JsonProperty("pressure")]
        public int pressure
        {
            get;
            set;
        }
        [JsonProperty("humidity")]
        public int humidity
        {
            get;
            set;
        }
        [JsonProperty("temp_min")]
        public double temp_min
        {
            get;
            set;
        }
        [JsonProperty("temp_max")]
        public double temp_max
        {
            get;
            set;
        }
    }
}