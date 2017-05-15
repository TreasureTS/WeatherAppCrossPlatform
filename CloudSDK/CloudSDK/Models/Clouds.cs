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
    public class Clouds
    {
        public Clouds() { }
        [JsonProperty("all")]
        public int all
        {
            get;
            set;
        }
    }
}