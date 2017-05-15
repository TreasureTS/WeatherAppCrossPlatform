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
    public class Sys
    {
        public Sys() { }
        [JsonProperty("type")]
        public int type
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
        [JsonProperty("message")]
        public double message
        {
            get;
            set;
        }
        [JsonProperty("country")]
        public string country
        {
            get;
            set;
        }
        [JsonProperty("sunrise")]
        public int sunrise
        {
            get;
            set;
        }
        [JsonProperty("sunset")]
        public int sunset
        {
            get;
            set;
        }
    }
}