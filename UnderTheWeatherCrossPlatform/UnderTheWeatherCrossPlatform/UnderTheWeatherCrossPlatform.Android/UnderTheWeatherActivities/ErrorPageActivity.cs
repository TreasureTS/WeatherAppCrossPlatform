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
using UnderTheWeatherCrossPlatform.Droid.Intro;

namespace UnderTheWeatherCrossPlatform.Droid.UnderTheWeatherActivities
{
    [Activity(Label = "ErrorPageActivity")]
    public class ErrorPageActivity : Activity
    {
        Button btnStart;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.erroPageLayout);
            // Create your application here
            btnStart = FindViewById(Resource.Id.btnRetry) as Button;

            btnStart.Click += BtnStart_Click;

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(LandingScreenActivity));
        }
    }
}