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

namespace UnderTheWeatherCrossPlatform.Droid.UnderTheWeatherActivities
{
    [Activity(Label = "ErrorPageActivity")]
    public class ErrorPageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.erroPageLayout);
            // Create your application here
        }
    }
}