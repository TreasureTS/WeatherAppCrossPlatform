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
using Android.Graphics;

namespace CloudSDK.Models
{
    public class AppState
    {
        private AppState() { }
        private static AppState instance = null;

        public static AppState Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new AppState();
                }
                return instance;
            }
        }

        public Bitmap bitMapImage;
    }
}