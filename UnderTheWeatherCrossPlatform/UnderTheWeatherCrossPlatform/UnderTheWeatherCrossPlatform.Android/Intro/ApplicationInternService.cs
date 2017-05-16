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
using Android.Locations;
using PortableClassLibrary.Helpers;

namespace UnderTheWeatherCrossPlatform.Droid.Intro
{
    [Service]
    public class ApplicationInternService : IntentService,ILocationListener
    {

        //Location manager
        private LocationManager locationManager = null;
        //Provider gps or network
        private string locationProvider = string.Empty;
        //gps status
        private bool gpsStatus = false;
        //Network status
        private bool networkStatus = false;
        //distance
        private int distance = 0;
        //time
        private int time = 500;
        private string TAG = "ApplicationInternService";
        private Context context;
        public ApplicationInternService() : base("myservice")
        {
         
        }
        public ApplicationInternService(Context context)
        {
            this.context = context;
        }
        public override void OnCreate()
        {
            base.OnCreate();
            initializeLocationManager();
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
        }
        protected override void OnHandleIntent(Intent intent) { }
        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            return base.OnStartCommand(intent, flags, startId);
        }

        public void OnLocationChanged(Location location)
        {
            float j = 0;
            //getting the latitude and longetude
            AppSingleton.Instance.latitude = location.Latitude;
            AppSingleton.Instance.longetude = location.Longitude;
            Log.d(TAG, "Latitude " + AppSingleton.Instance.latitude);
            Log.d(TAG, "Longetude " + AppSingleton.Instance.longetude);
            Log.d(TAG, "speed of coordinates " + location.Speed);    
        }

        public void OnProviderDisabled(string provider)
        { 
            AppSingleton.Instance.isLocationOn = false;
        }

        public void OnProviderEnabled(string provider)
        {
            AppSingleton.Instance.isLocationOn = true;
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras){}

        //Method is responsible for checking the status of a provider
        public void initializeLocationManager()
        {
            try
            { 
                Log.d(TAG, "START | locationManagerInitializer");
                locationManager = GetSystemService(LocationService) as LocationManager;
                gpsStatus = locationManager.IsProviderEnabled(LocationManager.GpsProvider);
                networkStatus = locationManager.IsProviderEnabled(LocationManager.NetworkProvider);
                Criteria criteria = new Criteria();
                criteria.Accuracy = Accuracy.Fine;
                if(gpsStatus)
                {
                    locationManager.RequestLocationUpdates(LocationManager.GpsProvider, time, distance,this);
                    AppSingleton.Instance.isLocationOn = true;
                    Log.d(TAG, "Service Provider " + LocationManager.GpsProvider);

                }
                if (networkStatus)
                {
                    locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, time, distance, this);
                    Log.d(TAG, "Service Provider " + LocationManager.NetworkProvider);
             
                }
                Log.d(TAG, "END | locationManagerInitializer");
            
            }
            catch(Exception ex)
            {
                Log.e(TAG, "ERR | Failed to initialize location manager because : " + ex.Message);
            }
        }

        public void dialogMessage()
        {
            try
            {
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
                alertDialog.SetTitle("Turn on location");
                alertDialog.SetMessage("GPS is off, Do you want to turn it on?");
                alertDialog.SetPositiveButton("Okay", (senderAlert, args) =>
                 {
                     Intent intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                     context.StartActivity(intent);
                 });
                alertDialog.SetNegativeButton("Cancel", (sender, args) =>
                {

                    alertDialog.SetCancelable(true);
                });

                alertDialog.Show();
            }
            catch(Exception ex)
            {
                Log.e(TAG, ex.Message);
            }
        }
    }
}