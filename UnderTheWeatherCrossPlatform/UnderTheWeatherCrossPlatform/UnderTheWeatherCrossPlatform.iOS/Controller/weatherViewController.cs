using CoreLocation;
using Foundation;
using PortableClassLibrary.Helpers;
using System;
using UIKit;
using UnderTheWeatherCrossPlatform.iOS.Helper;

namespace UnderTheWeatherCrossPlatform.iOS
{
    public partial class weatherViewController : UIViewController
    {
        public static LocationManager manager;
        private string TAG = "weatherViewController";
        public weatherViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            try
            {
                lblTemp.Text = TemperatureConverter.convertToCelcius(AppSingleton.Instance.temperature).ToString() + "°";
                lblMax.Text = " max " + TemperatureConverter.convertToCelcius(AppSingleton.Instance.maximumTemperature).ToString() + "°";
                lblDescription.Text = AppSingleton.Instance.weatherDescription;
                lblPlaceAndDate.Text = AppSingleton.Instance.nameOfPlace;
                lblDate.Text = DateTime.Now.ToString("dd  MMMM  yyyy");
                lblMin.Text = " min " + TemperatureConverter.convertToCelcius(AppSingleton.Instance.minimumTemparature).ToString() + "°";
                imgWeatherIcon.Image = UIImage.LoadFromData(NSData.FromArray(AppSingleton.Instance.imageByte));
            }
            catch(Exception ex)
            {
                Log.e(TAG, "ERR " + ex.Message);
            }
        }
    }
}