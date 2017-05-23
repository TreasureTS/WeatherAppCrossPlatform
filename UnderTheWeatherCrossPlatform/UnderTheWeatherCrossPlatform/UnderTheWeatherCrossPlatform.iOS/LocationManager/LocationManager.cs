using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreLocation;
using PortableClassLibrary.Helpers;
using System.Threading.Tasks;
using PortableClassLibrary.Controllers;
using System.Threading;

namespace UnderTheWeatherCrossPlatform.iOS.Helper
{
    public class LocationManager
    {
        protected CLLocationManager locationManager = null;
        private string TAG = "Location Manager";
        public event EventHandler<LocationUpdateEventArgs> LocationUpdated = delegate { };
        public LocationManager()
        {
            try
            {
                Log.d(TAG, "START | LocationManage constructor");

                locationManager = new CLLocationManager();
                locationManager.PausesLocationUpdatesAutomatically = false;

                Log.d(TAG, "PausesLocationUpdatesAutomatically is set to false");
                if (UIDevice.CurrentDevice.CheckSystemVersion(8,0))
                {
                    locationManager.RequestAlwaysAuthorization();
                }
                if(UIDevice.CurrentDevice.CheckSystemVersion(9,0))
                {
                    locationManager.AllowsBackgroundLocationUpdates = true;
                }
                Log.d(TAG, "END | LocationManage constructor");
            }

            catch (Exception ex)
            {
                Log.e(TAG, "ERR " + ex.Message);
            }

        }

        public void startLocationUpdates()
        {
            try
            {
                Log.d(TAG, "START | startLocationUpdate");
                if(CLLocationManager.LocationServicesEnabled)
                {
                    locationManager.DesiredAccuracy = 1;

                    locationManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
                    {
                        Log.d(TAG, "START | LocationManager_LocationsUpdated");
                        LocationUpdated(this, new LocationUpdateEventArgs(e.Locations[e.Locations.Length - 1]));
                        Log.d(TAG, "END | LocationManager_LocationsUpdated");
                    };
                    locationManager.StartUpdatingLocation();

                }
                Log.d(TAG, "END | startLocationUpdate");
                LocationUpdated += LocationManager_LocationUpdated;
            }
            catch(Exception ex)
            {
                Log.e(TAG, "ERR " + ex.Message);
            }
        }

        private void LocationManager_LocationUpdated(object sender, LocationUpdateEventArgs e)
        {
            try
            {
                Log.d(TAG, "START | LocationManager_LocationUpdated");
                AppSingleton.Instance.latitude = e.location.Coordinate.Latitude;
                AppSingleton.Instance.longetude = e.location.Coordinate.Longitude;
                Log.d(TAG, "Latitude " + AppSingleton.Instance.latitude);
                Log.d(TAG, "Longitude " + AppSingleton.Instance.longetude);
            }
            catch (Exception ex)
            {
                Log.e(TAG, ex.Message);
            }
        }
    }

}