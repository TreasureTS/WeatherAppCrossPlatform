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
using PortableClassLibrary.Helpers;
using UnderTheWeatherCrossPlatform.Droid.UnderTheWeatherActivities;
using PortableClassLibrary.Controllers;
using System.Threading.Tasks;
using System.Threading;

namespace UnderTheWeatherCrossPlatform.Droid.Intro
{
    [Activity(Label = "LandingScreenActivity", MainLauncher = true)]
    public class LandingScreenActivity : Activity, View.IOnClickListener
    {
        private string TAG = "LandingScreenActivity";
        private Button btnStart;
        ApplicationInternService app;
        ProgressDialog progressDialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Intent intent = new Intent(this, typeof(ApplicationInternService));
            StartService(intent);
            SetContentView(Resource.Layout.landingScreenLayout);
            app = new ApplicationInternService(this);
            
            btnStart = FindViewById(Resource.Id.btnStart) as Button;
            btnStart.SetOnClickListener(this);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Intent intent = new Intent(this, typeof(ApplicationInternService));
            StartService(intent);
        }

        public void startService()
        {
            try
            {
                Log.d(TAG, "START | startService");
            }
            catch(Exception ex)
            {
                Log.d(TAG, "ERR | Failed to start service " + ex.Message);
            }
        }
        public void OnClick(View v)
        {
            try
            {
                switch (v.Id)
                {
                    case Resource.Id.btnStart:
                        if (AppSingleton.Instance.isLocationOn == false)
                        {
                            AppSingleton.Instance.isLocationOn = false;
                            app.dialogMessage();
                        }
                        else
                        {
                            setProgressDialog();
                            Task.Run(async () =>
                            {
                                try
                                {                               
                                        Log.d(TAG, "START Thread");
                                        Process.SetThreadPriority(Android.OS.ThreadPriority.Background);
                                        await WeatherController.setupWeatherApplication(AppSingleton.Instance.latitude, AppSingleton.Instance.longetude);
                                        await WeatherController.handleGettingImageIcon(AppSingleton.Instance.imgIcon);
                                        progressDialog.Dismiss();
                                    if (AppSingleton.Instance.success && AppSingleton.Instance.latitude != 0 && AppSingleton.Instance.longetude != 0)
                                    {
                                        Intent intent = new Intent(this, typeof(UnderTheWeatherActivity));
                                        StartActivity(intent);
                                    }                                    
                                    else
                                    {
                                        StartActivity(typeof(ErrorPageActivity));
                                    }
                                
                                }
                                catch (Exception ex)
                                {
                                    Log.d(TAG, "ERR | Failed to run thread " + ex.Message);
                                    StartActivity(typeof(ErrorPageActivity));
                                }


                            }, new CancellationToken());

                        }
                        break;
                }
            }
            catch(Exception ex)
            {
                Log.e(TAG, "ERR | " + ex.Message);
                StartActivity(typeof(ErrorPageActivity));
            }
        }

        public void setProgressDialog()
        {
            try
            {
                Log.d(TAG, "START | set progress dialog");
                progressDialog = new ProgressDialog(this);
                progressDialog.SetMessage("Loading...Please wait..");
                progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                progressDialog.Show();

                Log.d(TAG, "END | progress dialog");
            }
            catch (Exception ex)
            {
                Log.e(TAG, "ERR | Failed to load progress bar " + ex.Message);
                StartActivity(typeof(ErrorPageActivity));
            }
        }
    }
}