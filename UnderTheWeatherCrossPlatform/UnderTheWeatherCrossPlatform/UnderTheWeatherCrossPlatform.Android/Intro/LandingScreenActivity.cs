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
    public class LandingScreenActivity : Activity
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
            btnStart.Click += BtnStart_Click;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            getWeatherInformationFromAPI();
        }

        protected override void OnResume()
        {
            base.OnResume();
            Intent intent = new Intent(this, typeof(ApplicationInternService));
            StartService(intent);
        }

        public void getWeatherInformationFromAPI()
        {
        
                Log.d(TAG, "START | Getting information from the api");
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
                       
                    }, new CancellationToken());

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