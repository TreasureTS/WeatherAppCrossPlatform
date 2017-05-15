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
    public class coord
    {
        public coord() { }
        [JsonProperty("lon")]
        public double lon
        {
            get;
            set;
        }
        [JsonProperty("lat")]
        public double lat
        {
            get;
            set;
        }
    }
}